﻿using Common.L2.Application;
using CoreModule.Application.Course.Create;
using CoreModule.Application.Course.Edit;
using CoreModule.Application.Course.Sections.Add;
using CoreModule.Query.Course._DTOs;
using CoreModule.Query.Course.GetByFilter;
using CoreModule.Query.Course.GetById;
using MediatR;

namespace CoreModule.Facade.Course;

class CourseFacade : ICourseFacade
{
    private readonly IMediator _mediator;

    public CourseFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Create(CreateCourseCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditCourseCommand command)
    {
        return await _mediator.Send(command);
    }

     public async Task<OperationResult> AddSection(AddCourseSectionCommand command)
    {
        return await _mediator.Send(command);
    }

    /*public async Task<OperationResult> AddEpisode(AddCourseEpisodeCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> AcceptEpisode(AcceptCourseEpisodeCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> DeleteEpisode(DeleteCourseEpisodeCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditEpisode(EditEpisodeCommand command)
    {
        return await _mediator.Send(command);

    }*/

    public async Task<CourseFilterResult> GetCourseFilter(CourseFilterParams param)
    {
        return await _mediator.Send(new GetCoursesByFilterQuery(param));

    }

    public async Task<CourseDto?> GetCourseById(Guid id)
    {
        return await _mediator.Send(new GetCourseByIdQuery(id));

    }

    /*public async Task<CourseDto?> GetCourseBySlug(string slug)
    {
        return await _mediator.Send(new GetCourseBySlugQuery(slug));

    }

    public async Task<EpisodeDto?> GetEpisodeById(Guid id)
    {
        return await _mediator.Send(new GetEpisodeByIdQuery(id));

    }*/
}