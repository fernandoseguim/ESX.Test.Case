﻿using System;
using ESX.Test.Case.Domain.Commands.Request;
using ESX.Test.Case.Domain.Commands.Response;
using ESX.Test.Case.Domain.Handlers;
using ESX.Test.Case.Domain.Repositories;
using ESX.Test.Case.Domain.ValueObjects;
using ESX.Test.Case.Shared.Commands;
using Flunt.Notifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;

namespace ESX.Test.Case.Tests.Domain.Handlers
{
	[TestClass]
	public partial class UserHandlerTests : UnitTestBase
	{
		private const string NOT_FOUND_USER_ID = "07F28933-A0BE-4C18-847A-346A92497362";
		private readonly IUserRepository repository;
		private readonly ICommandHandler<UserCommand> createUserHandler;
		private readonly UserCommand userCommand;

		public UserHandlerTests()
		{
			this.userCommand = new UserCommand();
			this.repository = Substitute.For<IUserRepository>();
			this.createUserHandler = new UserHandler(this.repository);
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
			this.repository.Delete(Arg.Any<Guid>()).Returns(true);
			this.repository.Delete(Arg.Is<Guid>(id => id.Equals(new Guid(NOT_FOUND_USER_ID)))).Returns(false);
		}

		[TestMethod]
		[Description("Given that I trying create user, " +
		             "when check if email already exists and email exists" +
		             "then should contains bad request status code in command result")]
		public void Should_contains_bad_request_status_code_in_command_result_when_email_already_exists_in_database()
		{
			this.userCommand.Email = $"teste@gmail.com";
			var commandResult = this.createUserHandler.Create(this.userCommand);

			Assert.AreEqual(StatusCodeResult.BadRequest, commandResult.StatusCode);
		}

		[TestMethod]
		[Description("Given that I trying create user, " +
		             "when check if email already exists and email exists" +
		             "then should contains notification in command result")]
		public void Should_contains_notification_in_command_result_when_email_already_exists_in_database()
		{
			this.userCommand.Email = $"teste@gmail.com";
			var commandResult = this.createUserHandler.Create(this.userCommand);

			var notifications = (List<Notification>) commandResult.Data;

			Assert.IsTrue(notifications.First().Property.Equals("email"));
		}

		[TestMethod]
		[Description("Given that user command is invalid, " +
		             "when handle user" +
		             "then should contains noticiations in command result")]
		public void Should_contains_notifications_command_result_when_user_comand_is_invalid()
		{
			var commandResult = this.createUserHandler.Create(new UserCommand());

			var notifications = (List<Notification>)commandResult.Data;

			Assert.IsTrue(notifications.Any());
		}

		[TestMethod]
		[Description("Given that user command is invalid, " +
		             "when handle user" +
		             "then should contains bad request status code in command result")]
		public void Should_contains_bad_request_status_code_in_command_result_when_user_comand_is_invalid()
		{
			var commandResult = this.createUserHandler.Create(new UserCommand());

			Assert.AreEqual(StatusCodeResult.BadRequest, commandResult.StatusCode);
		}

		[TestMethod]
		[Description("Given that user command is valid and email not exists, " +
		             "when handle user ans save user on database" +
		             "then should return successful command result")]
		public void Should_contains_success_status_code_in_command_result_when_user_comand_is_valid()
		{
			var commandResult = this.createUserHandler.Create(this.userCommand);

			Assert.AreEqual(StatusCodeResult.Success, commandResult.StatusCode);
		}
	}
}
