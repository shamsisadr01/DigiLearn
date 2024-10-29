using Common.L2.Application;
using CoreModule.Application.Course.Create;
using CoreModule.Application.Course.Edit;
using CoreModule.Application.Course.Episodes.Accept;
using CoreModule.Application.Course.Episodes.Add;
using CoreModule.Application.Course.Episodes.Delete;
using CoreModule.Application.Course.Episodes.Edit;
using CoreModule.Application.Course.Sections.Add;
using CoreModule.Query.Course._DTOs;

namespace CoreModule.Facade.Course;

public interface ICourseFacade
{
    Task<OperationResult> Create(CreateCourseCommand command);
    Task<OperationResult> Edit(EditCourseCommand command);
    Task<OperationResult> AddSection(AddCourseSectionCommand command);
    Task<OperationResult> AddEpisode(AddCourseEpisodeCommand command);
    Task<OperationResult> AcceptEpisode(AcceptCourseEpisodeCommand command);
    Task<OperationResult> DeleteEpisode(DeleteCourseEpisodeCommand command);
    Task<OperationResult> EditEpisode(EditEpisodeCommand command);


    Task<CourseFilterResult> GetCourseFilter(CourseFilterParams param);
    Task<CourseDto?> GetCourseById(Guid id);
    Task<CourseDto?> GetCourseBySlug(string slug);
    Task<EpisodeDto?> GetEpisodeById(Guid id);
}