using System.ComponentModel.DataAnnotations;

namespace EventEase.Attributes
{
    public class FutureDataAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime date)
            {
                return date > DateTime.Now;
            }
            return false;
        }
    }
}