using System.ComponentModel.DataAnnotations;

namespace WebApplication.Utilities
{
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        private readonly string _allowedDomain;

        public ValidEmailDomainAttribute(string allowedDomain)
        {
            _allowedDomain = allowedDomain;
        }
        
        public override bool IsValid(object value)
        {
            string[] split = value.ToString().Split('@');

            return split[1].ToUpper() == _allowedDomain.ToUpper();
        }
    }
}