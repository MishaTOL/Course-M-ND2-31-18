using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Models
{
    public class AmountValidateAttribute : ValidationAttribute, IClientValidatable
    {
        public string AmountProperty
        {
            get;
            set;
        }

        public string DiscountProperty
        {
            get;
            set;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "amount",
                ErrorMessage = "Amount should be greater than Discount."                
            };

            rule.ValidationParameters.Add("amountproperty", AmountProperty);
            rule.ValidationParameters.Add("discountproperty", DiscountProperty);

            yield return rule;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var amount = (decimal?)validationContext.ObjectType.GetProperty(AmountProperty).GetValue(validationContext.ObjectInstance);
            var discount = (decimal?)validationContext.ObjectType.GetProperty(DiscountProperty).GetValue(validationContext.ObjectInstance);

            if(amount - discount < 0)
            {
                return new ValidationResult("Amount should be greater than Discount.");
            }

            return ValidationResult.Success;
        }
    }
}