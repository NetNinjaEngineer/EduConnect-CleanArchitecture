using EduConnect.Application.Abstractions;
using EduConnect.Application.DTOs.Topic;
using EduConnect.Application.Features.Topics.Requests.Commands;
using EduConnect.Application.Features.Topics.Requests.Queries;
using EduConnect.Application.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EduConnect.API.Controllers
{
    [Route("api/topics")]
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

        [HttpPost]
        [ProducesResponseType(typeof(TopicDto), StatusCodes.Status201Created)]
        public async Task<ActionResult<IReadOnlyList<TopicDto>>> CreateNewTopic([FromBody] TopicForCreationDto model)
        {
            var createTopicCommand = new CreateTopicCommand { Topic = model };
            Result<TopicDto> createTopicResult = await mediator.Send(createTopicCommand);
            return Accepted(createTopicResult.Value);
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
    }
}
