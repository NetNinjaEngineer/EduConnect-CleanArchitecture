using EduConnect.Application.Abstractions;
using EduConnect.Application.Abstractions.Interfaces.Persistence.Models;
using EduConnect.Application.DTOs.Topic;
using EduConnect.Application.Features.Topics.Requests.Commands;
using EduConnect.Application.Features.Topics.Requests.Queries;
using EduConnect.Application.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EduConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<TopicDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<TopicDto>>> GetAllTopics()
        {
            Result<IReadOnlyList<TopicDto>> topicsResult = await mediator.Send(new GetAllTopicsQuery());
            return Ok(topicsResult.Value);
        }

        [HttpGet("{id:guid}", Name = "GetTopicByGuidId")]
        [ProducesResponseType(typeof(IReadOnlyList<TopicDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TopicDto>> GetTopic([FromRoute] Guid id)
        {
            return Ok(await mediator.Send(new GetTopicQuery(id)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(TopicDto), StatusCodes.Status201Created)]
        public async Task<ActionResult<IReadOnlyList<TopicDto>>> CreateNewTopic([FromBody] TopicForCreationDto model)
        {
            var createTopicCommand = new CreateTopicCommand { Topic = model };
            Result<TopicDto> createTopicResult = await mediator.Send(createTopicCommand);
            return CreatedAtRoute("GetTopicByGuidId", new { id = createTopicResult.Value.Id }, createTopicResult.Value);
        }

        [HttpGet]
        [Route("pagination")]
        [ProducesResponseType(typeof(Pagination<TopicDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<Pagination<TopicDto>>> GetPaginatedTopics(
            [FromQuery] TopicRequestParams topicRequestParams)
        {
            Result<Pagination<TopicDto>> pagedResult = await mediator.Send(
                new GetAllTopicsWithParamsQuery { TopicRequestParams = topicRequestParams });

            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagedResult.Value.MetaData));

            return Ok(pagedResult.Value);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Unit>> DeleteTopic([FromRoute] Guid id)
        {
            await mediator.Send(new DeleteTopicCommand(id));
            return NoContent();
        }

        [HttpGet]
        [Route("topicWithRelatedCourses/{topicId:guid}")]
        [ProducesResponseType(typeof(TopicWithRelatedCoursesDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<TopicWithRelatedCoursesDto>> TopicWithRelatedCourses([FromRoute] Guid topicId)
        {
            return Ok(await mediator.Send(new GetTopicWithRelatedCoursesQuery() { TopicId = topicId }));
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(IReadOnlyList<TopicWithRelatedCoursesDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<Unit>> UpdateTopic(Guid id, TopicForUpdateDto updateModel)
        {
            await mediator.Send(new UpdateTopicCommand(id, updateModel));
            return NoContent();
        }
    }
}
