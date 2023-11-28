using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DotnetFoundation.Application.UserUseCase.CreateUser;
using DotnetFoundation.Application.UserUseCase.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotnetFoundation.Presentation.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand createUserCommand)
        {
            try
            {
                var userId = await _mediator.Send(createUserCommand);

                // You might return the user's Id or a link to the newly created resource
                return CreatedAtAction(nameof(GetUserById), new { userId }, null);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error"); // Or return a custom error message
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            try
            {
                // You might have a separate query handler to retrieve the user details
                var user = await _mediator.Send(new GetUserQuery { UserId = userId });

                if (user == null)
                {
                    return NotFound(); // User not found
                }

                return Ok(user); // Return the user as JSON
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error"); // Or return a custom error message
            }
        }
    }
}