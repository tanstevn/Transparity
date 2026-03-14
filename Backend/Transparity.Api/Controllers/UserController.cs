using Microsoft.AspNetCore.Mvc;
using Transparity.Application.Abstractions;
using Transparity.Application.Users.Commands;
using Transparity.Shared.Models;

namespace Transparity.Api.Controllers {
    [Route("api/user")]
    public class UserController : BaseController {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Result<CreateUserCommandResult>> CreateUser([FromBody] CreateUserCommand command) {
            return await _mediator.SendAsync(command);
        }
    }
}
