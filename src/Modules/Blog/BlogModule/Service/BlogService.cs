using AutoMapper;
using BlogModule.Context;
using BlogModule.Domain;
using BlogModule.Repositories.Categories;
using BlogModule.Repositories.Posts;
using BlogModule.Service.DTOs.Command;
using BlogModule.Service.DTOs.Query;
using BlogModule.Utils;
using Common.L2.Application;
using Common.L2.Application.FileUtil.Interfaces;
using Common.L2.Application.SecurityUtil;
using Microsoft.EntityFrameworkCore;

namespace BlogModule.Service;

public class BlogService : IBlogService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;
    private readonly BlogContext _context;

    public BlogService(ICategoryRepository categoryRepository, IMapper mapper, IPostRepository postRepository, IFileService fileService, BlogContext context)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _postRepository = postRepository;
        _fileService = fileService;
        _context = context;
    }

    public async Task AddPostVisit(Guid id)
    {
        var post = await _postRepository.GetAsync(id);
        if (post != null)
        {
            post.Visit += 1;
            _postRepository.Update(post);
            await _context.SaveChangesAsync();
        }

    }

    public async Task<OperationResult> CreateCategory(CreateBlogCategoryCommand command)
    {
        var category = _mapper.Map<Category>(command);

        if(await _categoryRepository.ExistsAsync(c=>c.Slug == category.Slug))
            return OperationResult.Error("اسلاگ تکراری است.");

        _categoryRepository.Add(category);
        await _categoryRepository.Save();
        return OperationResult.Success();
    }

    public async Task<OperationResult> EditCategory(EditBlogCategoryCommand command)
    {
        var category = await _categoryRepository.GetAsync(command.Id);

        if(category == null)
            return OperationResult.Error();

        if (category.Slug != command.Slug)
        {
            if (await _categoryRepository.ExistsAsync(c => c.Slug == command.Slug))
                return OperationResult.Error("اسلاگ تکراری است.");
        }

        category.Slug = command.Slug;
        category.Title = command.Title;

        _categoryRepository.Update(category);
        await _categoryRepository.Save();
        return OperationResult.Success();
    }

    public async Task<OperationResult> DeleteCategory(Guid categoryId)
    {
        var category = await _categoryRepository.GetAsync(categoryId);
        if(category == null) 
            return OperationResult.Error();

        if (await _postRepository.ExistsAsync(p => p.CategoryId == categoryId))
        {
            return OperationResult.Error("این دسته دارای پست است لطفا ابتدا پست را حذف کنید و دوباره امتحان کنید.");
        }
        _categoryRepository.Delete(category);
        await _categoryRepository.Save();
        return OperationResult.Success();
    }

    public async Task<List<BlogCategoryDto>> GetAllCategories()
    {
        var categories = await _categoryRepository.GetAll();

        return _mapper.Map<List<BlogCategoryDto>>(categories);
    }

    public async Task<BlogCategoryDto> GetCategoryById(Guid id)
    {
        var category = await _categoryRepository.GetAsync(id);
        return _mapper.Map<BlogCategoryDto>(category);
    }

    public async Task<OperationResult> CreatePost(CreatePostCommand command)
    {
        var post = _mapper.Map<Post>(command);
        if(await _postRepository.ExistsAsync(p=>p.Slug == post.Slug))
            return OperationResult.Error("اسلاگ تکراری است.");

        if (command.ImageFile.IsImage() == false)
            return OperationResult.Error("عکس نامعتبر است.");

        var imageName = await _fileService.SaveFileAndGenerateName(command.ImageFile, BlogDirectories.PostImage);
        post.ImageName = imageName;
        post.Visit = 1;
        post.Description.SanitizeText();

        _postRepository.Add(post);
        await _postRepository.Save();
        return OperationResult.Success();
    }

    public async Task<OperationResult> EditPost(EditPostCommand command)
    {
        var post = await _postRepository.GetTracking(command.Id);

        if(post == null)
            return OperationResult.NotFound();

        if (post.Slug != command.Slug)
        {
            if (await _postRepository.ExistsAsync(p => p.Slug == post.Slug))
                return OperationResult.Error("اسلاگ تکراری است.");
        }

        if (command.ImageFile != null)
        {
            if (command.ImageFile.IsImage() == false)
                return OperationResult.Error("عکس نامعتبر است.");
            else
            {
                var imageName = await _fileService.SaveFileAndGenerateName(command.ImageFile, BlogDirectories.PostImage);
                post.ImageName = imageName;
            }
        }

        post.Description = command.Description.SanitizeText();
        post.Author = command.Author;
        post.Title = command.Title;
        post.CategoryId = command.CategoryId;
        post.Slug = command.Slug;

        await _postRepository.Save();
        return OperationResult.Success();
    }

    public async Task<OperationResult> DeletePost(Guid postId)
    {
        var post = await _postRepository.GetAsync(postId);
        if (post == null) return OperationResult.NotFound();

        _postRepository.Delete(post);
        await _postRepository.Save();
        _fileService.DeleteFile(BlogDirectories.PostImage, post.ImageName);
        return OperationResult.Success();
    }

    public async Task<BlogPostDto?> GetPostById(Guid postId)
    {
        var post = await _postRepository.GetAsync(postId);
        if (post == null)
            return null;

        return _mapper.Map<BlogPostDto>(post);
    }

    public async Task<BlogPostFilterResult> GetPostsByFilter(BlogPostFilterParams filterParams)
    {
        var result = _context.Posts.OrderByDescending(d => d.CreationDate)
            .Include(c => c.Category).AsQueryable();


        if (string.IsNullOrWhiteSpace(filterParams.Search) == false)
            result = result.Where(r =>
                r.Title.Contains(filterParams.Search) || r.Description.Contains(filterParams.Search));


        if (string.IsNullOrWhiteSpace(filterParams.CategorySlug) == false)
            result = result.Where(r => r.Category.Slug == filterParams.CategorySlug);


        var skip = (filterParams.PageId - 1) * filterParams.Take;
        var model = new BlogPostFilterResult()
        {
            Data = await result.Skip(skip).Take(filterParams.Take).Select(s => new BlogPostFilterItemDto
            {
                CreationDate = s.CreationDate,
                Id = s.Id,
                UserId = s.UserId,
                Title = s.Title,
                Author = s.Author,
                Description = s.Description,
                Slug = s.Slug,
                Visit = s.Visit,
                ImageName = s.ImageName,
                Category = new BlogCategoryDto()
                {
                    Title = s.Category.Title,
                    Id = s.CategoryId,
                    Slug = s.Category.Slug
                }
            }).ToListAsync()
        };

        model.GeneratePaging(result, filterParams.Take, filterParams.PageId);
        return model;

    }

    public async Task<BlogPostFilterItemDto?> GetPostBySlug(string slug)
    {
        var post = await _context.Posts.Include(c => c.Category).FirstOrDefaultAsync(f => f.Slug == slug);
        if (post == null)
            return null;

        return new BlogPostFilterItemDto
        {
            CreationDate = post.CreationDate,
            Id = post.Id,
            UserId = post.UserId,
            Title = post.Title,
            Author = post.Author,
            Description = post.Description,
            Slug = post.Slug,
            Visit = post.Visit,
            ImageName = post.ImageName,
            Category = new BlogCategoryDto()
            {
                Title = post.Category.Title,
                Id = post.CategoryId,
                Slug = post.Category.Slug
            }
        };
    }
}