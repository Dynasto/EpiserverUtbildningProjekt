using AlloyAdvanced.Models.Pages;
using EPiServer.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace AlloyAdvanced.Business.Validation
{
    public class StartPageValidator : IValidate<StartPage>
    {
        public IEnumerable<ValidationError> Validate(StartPage instance)
        {
            var errors = new List<ValidationError>();

            if (instance.StartDate < DateTime.Today || instance.StartDate > instance.EndDate)
            {
                errors.Add(new ValidationError { 
                    ErrorMessage = "Startdatum is wrong", 
                    RelatedProperties = new string[] { "EndDate"}, 
                    Severity = ValidationErrorSeverity.Error 
                });
            }

            return errors;
        }
    }
}