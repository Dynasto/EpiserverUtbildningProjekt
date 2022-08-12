using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlloyTraining.Models.Validation
{
    public class CustomNumberValidation : ValidationAttribute
    {
        public CustomNumberValidation()
        {
            ErrorMessage = "Du har gjort fel";
        }

        public override bool IsValid(object value)
        {
            if (!(value is int)) return false;
            return (int)value != 666;
        }
    }
}