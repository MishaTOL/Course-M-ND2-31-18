using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class AmountModelValidateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var order = (Order)value;

            if(order.Amount - order.Discont < 0)
            {
                return false;
            }

            return true;
        }
    }
}