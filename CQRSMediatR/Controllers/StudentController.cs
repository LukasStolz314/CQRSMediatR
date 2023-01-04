using CQRSMediatR.Application.Command;
using CQRSMediatR.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatR.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{

    private readonly ILogger<StudentController> _logger;
    private readonly IMediator _mediator;

    public StudentController(ILogger<StudentController> logger,
        IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> GetStudentById(Int32 id)
    {
        var query = new StudentGetByIdQuery(id);
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> CreateStudent(String name, Int32 age)
    {
        var command = new StudentCreateCommand(name, age);
        await _mediator.Send(command);
        return Ok();
    }
}

