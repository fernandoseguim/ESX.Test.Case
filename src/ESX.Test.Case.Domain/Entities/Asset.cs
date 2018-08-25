using System;
using ESX.Test.Case.Shared;

namespace ESX.Test.Case.Domain.Entities
{
	public sealed class Asset : Entity
	{
		public Asset(string name, Brand brand)
		{
			this.Name = name;
			if(string.IsNullOrWhiteSpace(this.Name)) 
				throw new ArgumentNullException($"The asset name can not be null or whitespace");

			this.Brand = brand ?? throw new ArgumentNullException($"The asset brand can not be null");
			this.GenerateassetRegisterNumber();
		}

		public string Name { get; }
		public Brand Brand { get; }
		public string Description { get; private set; }
		public string Registry { get; private set; }

		public void AddDescription(string description) 
			=> this.Description = description;

		private void GenerateassetRegisterNumber() 
			=> this.Registry = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
	}
}
