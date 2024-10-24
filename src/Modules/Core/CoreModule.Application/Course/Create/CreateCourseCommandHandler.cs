using Common.L2.Application;
using Common.L2.Application.FileUtil;
using Common.L2.Application.FileUtil.Interfaces;
using CoreModule.Application._Utilities;
using CoreModule.Domain.Course.DomainService;
using CoreModule.Domain.Course.Repository;

namespace CoreModule.Application.Course.Create;

class CreateCourseCommandHandler : IBaseCommandHandler<CreateCourseCommand>
{
    private readonly IFtpFileService _ftpFileService;
    private readonly IFileService _fileService;
    private readonly ICourseRepository _repository;
    private readonly ICourseDomainService _domainService;
    public CreateCourseCommandHandler(IFtpFileService fileService, ICourseDomainService domainService, ICourseRepository repository, IFileService fileService1)
    {
        _ftpFileService = fileService;
        _domainService = domainService;
        _repository = repository;
        _fileService = fileService1;
    }

    public async Task<OperationResult> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, CoreModuleDirectories.CourseImage);


        string videoPath = null;
        Guid courseId = Guid.NewGuid();
        if (request.VideoFile != null)
        {
            if (request.VideoFile.IsValidMp4File() == false)
            {
                return OperationResult.Error("فایل وارد شده نامعتبر است");
            }

            videoPath = await _ftpFileService.SaveFileAndGenerateName(request.VideoFile, CoreModuleDirectories.CourseDemo(courseId));
        }


        var course = new Domain.Course.Models.Course(request.Title, request.TeacherId, request.Description, imageName, videoPath,
            request.Price,
             request.CourseLevel, request.CategoryId, request.SubCategoryId, request.Slug, request.Status, _domainService)
        {
            Id = courseId
        };

        _repository.Add(course);
        await _repository.Save();
        return OperationResult.Success();
    }
}