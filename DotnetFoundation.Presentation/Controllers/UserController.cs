using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DotnetFoundation.Application.UserUseCase.CreateUser;
using DotnetFoundation.Application.UserUseCase.GetUser;
using DotnetFoundation.Presentation.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotnetFoundation.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;

        }

        [HttpPost]
        [Route("create")]
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
                _logger.LogError("Error creating user");
                return StatusCode(500, new APIResponce(500, "Internal Server Error")); // Or return a custom error message
            }
        }

        [HttpGet]
        [Route("get/{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            try
            {
                // You might have a separate query handler to retrieve the user details
                var user = await _mediator.Send(new GetUserQuery { UserId = userId });

                if (user == null)
                {
                    return NotFound(new APIResponce(404, "User not found"));
                }

                return Ok(user); // Return the user as JSON
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Error getting user");
                return StatusCode(500, new APIResponce(500, "Internal Server Error"));
                // Or return a custom error message
            }
        }
    }
}