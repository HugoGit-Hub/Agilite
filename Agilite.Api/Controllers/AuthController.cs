﻿using Agilite.Api.Messaging.Commands.AuthCommands.Login;
using Agilite.DataTransferObject.DTOs;
using Agilite.Services.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;

        public AuthController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            try
            {
                var authentication = await _sender.Send(new LoginCommand(login));
                return Ok(authentication);
            }
            catch (WrongCredentialsException)
            {
                return Unauthorized();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
