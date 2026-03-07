using FluentAssertions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;
using Transparity.Application.Abstractions;
using Transparity.Data;
using Transparity.Infrastructure.Mediator;

namespace Transparity.Tests.Integration.Abstractions {
    public abstract class BaseIntegrationTest<TTestClass, TRequest,
        TResponse, TRequestHandler> : IAsyncLifetime
        where TTestClass : BaseIntegrationTest<TTestClass, TRequest, TResponse, TRequestHandler>
        where TRequest : IRequest<TResponse>
        where TRequestHandler : class, IRequestHandler<TRequest, TResponse> {
        private readonly PostgreSqlContainer _postgres;

        private ApplicationDbContext _dbContext = default!;
        private IMediator _mediator = default!;

        private TRequest _request = default!;
        private TResponse _result = default!;
        private Exception _exception = default!;

        protected BaseIntegrationTest() {
            _postgres = new PostgreSqlBuilder("postgres:17-alpine")
                .WithDatabase("neon_test")
                .WithUsername("postgres")
                .WithPassword("postgres")
                .Build();
        }

        public async Task InitializeAsync() {
            await _postgres.StartAsync();

            var services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(_postgres.GetConnectionString()));

            services.AddMediatorFromAssembly(typeof(IMediator).Assembly);
            services.AddValidatorsFromAssembly(typeof(IMediator).Assembly);

            var provider = services.BuildServiceProvider();

            _dbContext = provider.GetRequiredService<ApplicationDbContext>();
            _mediator = provider.GetRequiredService<IMediator>();
        }

        public async Task DisposeAsync() {
            await _dbContext.Database.EnsureDeletedAsync();
            await _postgres.StopAsync();
        }

        public TTestClass Arrange(Action<TRequest> arrange) {
            _request = Activator.CreateInstance<TRequest>();
            arrange(_request);

            return (TTestClass)this;
        }

        public TTestClass Act() {
            try {
                _result = _mediator.SendAsync(_request)
                    .GetAwaiter()
                    .GetResult();
            }
            catch (Exception ex) {
                _exception = ex;
            }

            return (TTestClass)this;
        }

        public void Assert(Action<TResponse> assertion) {
            assertion(_result);
        }

        public void AssertThrows<TException>(Action<TException> assertion)
            where TException : Exception {
            ArgumentNullException.ThrowIfNull(_exception);

            _exception.Should()
                .BeOfType<TException>();

            assertion((TException)_exception);
        }
    }
}
