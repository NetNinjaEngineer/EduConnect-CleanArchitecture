using EduConnect.Application.DTOs.Course;
using EduConnect.Application.Features.Courses.Requests.Commands;
using EduConnect.Application.Features.Courses.Requests.Queries;
using EduConnect.Application.Helpers;
using EduConnect.Application.RequestParameters.Course;
using EduConnect.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EduConnect.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CoursesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<Course>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<Course>>> GetCoursesWithoutSpecification()
    {
        return Ok(await _mediator.Send(new GetCoursesQuery()));
    }

    [HttpGet]
    [Route("CoursesWithTopics")]
    [ProducesResponseType(typeof(Pagination<CourseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<CourseDto>>> GetCoursesWithTopics([FromQuery] CourseRequestParameters parameters)
    {
        var pagedResult = await _mediator.Send(new GetCoursesWithTopicsQuery() { Parameters = parameters });
        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));
        return Ok(pagedResult);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CourseForListDto), StatusCodes.Status201Created)]
    public async Task<ActionResult<CourseForListDto>> CreateNewCourse([FromBody] CourseForCreateDto model)
    {
        var course = await _mediator.Send(new CreateCourseCommand { Course = model });
        //return CreatedAtRoute("GetCourseByGuidId", new { id = course.Id }, course);
        return Accepted();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Unit>> UpdateTopic([FromRoute] Guid id, CourseForUpdateDto updateModel)
    {
        await _mediator.Send(new UpdateCourseCommand(id, updateModel));
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Unit>> DeleteCourse([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteCourseCommand(id));
        return NoContent();
    }


}
