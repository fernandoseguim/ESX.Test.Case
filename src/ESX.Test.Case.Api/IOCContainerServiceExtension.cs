using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ESX.Test.Case.Domain.Commands.Request;
using ESX.Test.Case.Domain.Handlers;
using ESX.Test.Case.Domain.Repositories;
using ESX.Test.Case.Infra;
using ESX.Test.Case.Infra.Repositories;
using ESX.Test.Case.Shared.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
			services.AddTransient<ICommandHandler<UserCommand>, CreateUserHandler>();

			return services;
		}
	}
}
