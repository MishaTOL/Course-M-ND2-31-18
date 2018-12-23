using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validation;

namespace Models
{

    //[AmountModelValidate]
    public class Order : IValidatableObject
    {
        public int Id
        {
            get;
            set;
        }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        [RegularExpression(@"[A-aZ-z \d-.]+")]
        [StringLength(20, MinimumLength = 3)]
        [Remote("ValidateTitle", "Order")]
        public string Title
        {
            get;
            set;
        }

        [Range(typeof(decimal), "10", "100")]
        [AmountValidate(AmountProperty = nameof(Amount), DiscountProperty =nameof(Discont))]
        public decimal? Amount
        {
            get;
            set;
        }

        [Range(typeof(decimal), "1", "20")]
        public decimal? Discont
        {
            get;
            set;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            //if(Amount - Discont < 0)
            //{
            //    result.Add(new ValidationResult("Amount should be Discount."));
            //}

            return result;
        }
    }
}