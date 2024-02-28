using System.ComponentModel.DataAnnotations;

namespace crud_system.validations
{
    public class NameValAttribute:ValidationAttribute
    {
       
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string Name = (string) value;
            if(Name != null)
            {
              for(char i='1';i<='9';i++)
                {
                    if (Name.StartsWith(i))
                        return new ValidationResult("Name cannot start with numbers");
                }
            }


            return ValidationResult.Success;
        }
    }
}
