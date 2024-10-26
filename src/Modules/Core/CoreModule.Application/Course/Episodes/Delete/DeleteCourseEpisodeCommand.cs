using Common.L2.Application.FileUtil.Services;
using Common.L2.Application;

namespace CoreModule.Application.Course.Episodes.Delete;

public record DeleteCourseEpisodeCommand(Guid CourseId, Guid EpisodeId) : IBaseCommand;