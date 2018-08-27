using ESX.Test.Case.Shared;
using System;
using ESX.Test.Case.Shared.Entities;

namespace ESX.Test.Case.Domain.Entities
{
	public sealed class Brand : Entity
	{
		public const int MINIMUM_NAME_SIZE = 10;
		public const int MAXIMUM_NAME_SIZE = 20;

		public Brand(string name)
		{
			this.Name = name;
			if(string.IsNullOrWhiteSpace(this.Name)) 
				throw new ArgumentNullException($"The brand name can not be null or whitespace");
		}

		public string Name { get; }
	}
}
