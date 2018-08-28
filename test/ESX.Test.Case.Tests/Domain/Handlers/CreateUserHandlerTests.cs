using System;
using System.Collections.Generic;
using System.Linq;
using ESX.Test.Case.Domain.Commands.Request;
using ESX.Test.Case.Domain.Commands.Response;
using ESX.Test.Case.Domain.Entities;
using ESX.Test.Case.Domain.Handlers;
using ESX.Test.Case.Domain.Repositories;
using ESX.Test.Case.Domain.ValueObjects;
using ESX.Test.Case.Shared.Commands;
using Flunt.Notifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Extensions;

namespace ESX.Test.Case.Tests.Domain.Handlers
{
	[TestClass]
	public class CreateUserHandlerTests : UnitTestBase
	{
		private readonly IUserRepository repository;
		private readonly ICommandHandler<UserCommand> createUserHandler;
		private readonly UserCommand userCommand;

		public CreateUserHandlerTests()
		{
			this.userCommand = new UserCommand();
			this.repository = Substitute.For<IUserRepository>();
			this.createUserHandler = new CreateUserHandler(this.repository);
		}

		[TestInitialize]
		public void Setup()
		{
			this.userCommand.FirstName = this.MockString();
			this.userCommand.LastName = this.MockString();
			this.userCommand.Email = $"{this.MockString()}@teste.com";
			this.userCommand.Password = this.MockString();
			
			this.repository.CheckEmail(Arg.Is<Email>(email => email.ToString().Equals("teste@gmail.com"))).Returns(true);
			this.repository.CheckEmail(Arg.Is<Email>(email => !email.ToString().Equals("teste@gmail.com"))).Returns(false);
		}

		[TestMethod]
		[Description("Given that I handle user, " +
		             "when check if email already exists and email exists" +
		             "then should return unsuccessful command result")]
		public void Should_return_unsuccessful_command_result_when_already_exists_email_in_database()
		{
			this.userCommand.Email = $"teste@gmail.com";
			var commandResult = this.createUserHandler.Handle(this.userCommand);

			Assert.IsInstanceOfType(commandResult, typeof(UnsuccessfulCommandResult));
		}

		[TestMethod]
		[Description("Given that I handle user, " +
		             "when check if email already exists and email exists" +
		             "then should contains bad request status code in command result")]
		public void Should_contains_bad_request_status_code_in_command_result_when_email_already_exists_in_database()
		{
			this.userCommand.Email = $"teste@gmail.com";
			var commandResult = this.createUserHandler.Handle(this.userCommand);

			Assert.AreEqual(StatusCodeResult.BadRequest, commandResult.StatusCode);
		}

		[TestMethod]
		[Description("Given that I handle user, " +
		             "when check if email already exists and email exists" +
		             "then should contains notification in command result")]
		public void Should_contains_notification_in_command_result_when_email_already_exists_in_database()
		{
			this.userCommand.Email = $"teste@gmail.com";
			var commandResult = this.createUserHandler.Handle(this.userCommand);

			var notifications = (List<Notification>) commandResult.Data;

			Assert.IsTrue(notifications.First().Property.Equals("email"));
		}

		[TestMethod]
		[Description("Given that user command is invalid, " +
		             "when handle user" +
		             "then should return unsuccesfull command result")]
		public void Should_return_unsuccessful_command_result_when_user_comand_is_invalid()
		{
			var commandResult = this.createUserHandler.Handle(new UserCommand());

			Assert.IsInstanceOfType(commandResult, typeof(UnsuccessfulCommandResult));
		}

		[TestMethod]
		[Description("Given that user command is invalid, " +
		             "when handle user" +
		             "then should contains noticiations in command result")]
		public void Should_contains_notifications_command_result_when_user_comand_is_invalid()
		{
			var commandResult = this.createUserHandler.Handle(new UserCommand());

			var notifications = (List<Notification>)commandResult.Data;

			Assert.IsTrue(notifications.Any());
		}

		[TestMethod]
		[Description("Given that user command is invalid, " +
		             "when handle user" +
		             "then should contains bad request status code in command result")]
		public void Should_contains_bad_request_status_code_in_command_result_when_user_comand_is_invalid()
		{
			var commandResult = this.createUserHandler.Handle(new UserCommand());

			Assert.AreEqual(StatusCodeResult.BadRequest, commandResult.StatusCode);
		}

		[TestMethod]
		[Description("Given that user command is valid and email not exists, " +
		             "when handle user ans save user in database" +
		             "then should return successful command result")]
		public void Should_return_successful_command_result_when_user_comand_is_valid()
		{
			var commandResult = this.createUserHandler.Handle(this.userCommand);

			Assert.IsInstanceOfType(commandResult, typeof(SuccessfulCommandResult));
		}

		[TestMethod]
		[Description("Given that user command is valid and email not exists, " +
		             "when handle user ans save user in database" +
		             "then should return successful command result")]
		public void Should_contains_success_status_code_in_command_result_when_user_comand_is_valid()
		{
			var commandResult = this.createUserHandler.Handle(this.userCommand);

			Assert.AreEqual(StatusCodeResult.Success, commandResult.StatusCode);
		}
	}
}
