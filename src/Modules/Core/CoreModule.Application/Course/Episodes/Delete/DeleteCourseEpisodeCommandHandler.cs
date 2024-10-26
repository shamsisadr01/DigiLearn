using Common.L2.Application;
using Common.L2.Application.FileUtil.Interfaces;
using CoreModule.Application._Utilities;
using CoreModule.Domain.Course.Repository;

namespace CoreModule.Application.Course.Episodes.Delete;

class DeleteCourseEpisodeCommandHandler : IBaseCommandHandler<DeleteCourseEpisodeCommand>
{
    private readonly ICourseRepository _repository;
    private readonly IFileService _fileService;
    public DeleteCourseEpisodeCommandHandler(ICourseRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(DeleteCourseEpisodeCommand request, CancellationToken cancellationToken)
    {
        var course = await _repository.GetTracking(request.CourseId);
        if (course == null)
        {
            return OperationResult.NotFound();
        }

        var episode = course.DeleteEpisode(request.EpisodeId);
        await _repository.Save();
        _fileService.DeleteDirectory(CoreModuleDirectories.CourseEpisode(course.Id, episode.Token));
        return OperationResult.Success();
    }
}