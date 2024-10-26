using Common.L2.Application;

namespace CoreModule.Application.Course.Episodes.Accept;

public record AcceptCourseEpisodeCommand(Guid CourseId, Guid EpisodeId) : IBaseCommand;