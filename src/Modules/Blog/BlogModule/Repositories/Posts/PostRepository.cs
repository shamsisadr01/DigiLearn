using BlogModule.Context;
using BlogModule.Domain;
using Common.L3.Infrastructure.Repository;

namespace BlogModule.Repositories.Posts;

class PostRepository : BaseRepository<Post, BlogContext>, IPostRepository
{
    public PostRepository(BlogContext context) : base(context)
    {
    }

    public void Delete(Post post)
    {
        Context.Posts.Remove(post);
    }
}