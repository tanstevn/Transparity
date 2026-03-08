using FluentAssertions;
using FluentValidation;
using Transparity.Application.Examples;
using Transparity.Shared.Models;
using Transparity.Tests.Integration.Abstractions;
using Transparity.Tests.Integration.Fixtures;

namespace Transparity.Tests.Integration.Infrastructure.Mediator {
    [Trait("Category", "Integration")]
    public class MediatorQueryTests : BaseIntegrationTest<MediatorQueryTests,
        ExampleMediatorQuery, Result<object>, ExampleMediatorQueryHandler> {
        public MediatorQueryTests(PostgresFixture fixture) : base(fixture) { }

        [Fact]
        public async Task ExampleMediatorQuery_Runs_Successfully() {
            Arrange(request => { })
            .Act()
            .Assert(result => {
                result.Successful
                    .Should()
                    .BeTrue();

                var expected = new {
                    Successful = true
                };

                result.Data
                    .Should()
                    .NotBeNull();
            });
        }
    }

    [Trait("Category", "Integration")]
    public class MediatorCommandTests : BaseIntegrationTest<MediatorCommandTests,
        ExampleMediatorCommand, Result<object>, ExampleMediatorCommandHandler> {
        public MediatorCommandTests(PostgresFixture fixture) : base(fixture) { }

        [Fact]
        public async Task ExampleMediatorCommand_Runs_Successfully() {
            Arrange(request => { })
            .Act()
            .Assert(result => {
                result.Successful
                    .Should()
                    .BeTrue();

                var expected = new {
                    Successful = true
                };

                result.Data
                    .Should()
                    .NotBeNull();
            });
        }
    }

    [Trait("Category", "Integration")]
    public class MediatorCommandWithValidatorTests : BaseIntegrationTest<MediatorCommandWithValidatorTests,
        ExampleMediatorCommandWithValidator, Result<object>, ExampleMediatorCommandWithValidatorHandler> {
        public MediatorCommandWithValidatorTests(PostgresFixture fixture) : base(fixture) { }

        [Fact]
        public async Task ExampleMediatorCommandWithValidator_Runs_Successfully() {
            Arrange(request => {
                request.Id = 1;
            })
            .Act()
            .Assert(result => {
                result.Successful
                    .Should()
                    .BeTrue();

                var expected = new {
                    Successful = true
                };

                result.Data
                    .Should()
                    .NotBeNull();
            });
        }

        [Fact]
        public async Task ExampleMediatorCommandWithValidator_Validate_Required_Param_Throws_ValidationException() {
            Arrange(request => {
                request.Id = 0;
            })
            .Act()
            .AssertThrows<ValidationException>(ex => {
                ex.Errors
                    .Should()
                    .HaveCountGreaterThan(0);
            });
        }
    }
}
