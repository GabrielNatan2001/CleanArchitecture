using CleanArchitecture.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class Category: Entity
    {
        public string Name { get; private set; }
        public Category(string name)
        {
            ValidadteDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            Id = id;
            ValidadteDomain(name);
        }


        public void Update(string name)
        {
            ValidadteDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        public void ValidadteDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");

            Name = name;
        }
    }
}
