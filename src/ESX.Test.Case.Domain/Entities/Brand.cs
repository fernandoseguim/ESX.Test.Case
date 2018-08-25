using ESX.Test.Case.Shared;
using System;

namespace ESX.Test.Case.Domain.Entities
{
	public sealed class Brand : Entity
	{
		public Brand(string name)
		{
			this.Name = name;
			if(string.IsNullOrWhiteSpace(this.Name)) 
				throw new ArgumentNullException($"The brand name can not be null or whitespace");
		}

		public string Name { get; }
	}
}
