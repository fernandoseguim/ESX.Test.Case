using ESX.Test.Case.Domain.Commands.Request;
using ESX.Test.Case.Domain.Handlers;
using ESX.Test.Case.Domain.Repositories;
using ESX.Test.Case.Infra;
using ESX.Test.Case.Infra.Repositories;
using ESX.Test.Case.Shared.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using ESX.Test.Case.Domain.Queries.Response;

namespace ESX.Test.Case.Api
{
	public static class IOCContainerServiceExtension
	{
		public static IServiceCollection AddIOCConteiner(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddTransient<IDbConnection>(connection
				=> new SqlConnection(configuration.GetConnectionString("EsxTestCaseDatabaseContext")));

			services.AddTransient<IDatabaseContext, EsxTestCaseDatabaseContext>();
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<ICommandHandler<UserCommand>, UserHandler>();
			services.AddTransient<IUserQueryHandler, UserQueryHandler>();

			return services;
		}
	}
}
