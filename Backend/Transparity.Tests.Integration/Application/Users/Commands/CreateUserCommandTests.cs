using Transparity.Application.Users.Commands;
using Transparity.Shared.Models;
using Transparity.Tests.Integration.Abstractions;
using Transparity.Tests.Integration.Fixtures;

namespace Transparity.Tests.Integration.Application.Users.Commands {
    public class CreateUserCommandTests : BaseIntegrationTest<CreateUserCommandTests,
        CreateUserCommand, Result<CreateUserCommandResult>, CreateUserCommandHandler> {
        public CreateUserCommandTests(PostgresFixture fixture) : base(fixture) { }
    }
}
