using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Last.Models
{
    public class Car
    {
            public Guid Id { get; set; } = Guid.Empty;
            public string Brand { get; set; }

            public string Model { get; set; }

            public int Price { get; set; }

            public BaseModelValidationResult Validate()
            {
                var validationResult = new BaseModelValidationResult();

                if (string.IsNullOrWhiteSpace(Brand)) validationResult.Append($"Name cannot be empty");
                if (string.IsNullOrWhiteSpace(Model)) validationResult.Append($"Surname cannot be empty");
                if (!(0 < Price)) validationResult.Append($"Price {Price} is out of range 0...");

                if (!string.IsNullOrEmpty(Brand) && !char.IsUpper(Brand.FirstOrDefault())) validationResult.Append($"Name {Brand} should start from capital letter");
                if (!string.IsNullOrEmpty(Model) && !char.IsUpper(Model.FirstOrDefault())) validationResult.Append($"Surname {Model} should start from capital letter");

                return validationResult;
            }

            public override string ToString()
            {
                return $"{Brand} {Model} cost {Price} rubles";
            }
    }
}
