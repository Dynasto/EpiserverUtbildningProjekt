using AlloyTraining.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyTraining.Models.Validation
{
    public class TestsidaValidator : IValidate<Testsida>
    {
        public IEnumerable<ValidationError> Validate(Testsida page)
        {
            var errors = new List<ValidationError>();

            if(page.MyProperty2 > page.MyProperty)
            {
                errors.Add(new ValidationError()
                {
                    ErrorMessage="vafan g;r du",
                    Severity=ValidationErrorSeverity.Warning,
                    RelatedProperties = new[] {"MyProperty2"}
                });
            }

            var loader = ServiceLocator.Current.GetInstance<IContentLoader>();

            var pages = loader.GetChildren<PageData>(ContentReference.StartPage);

            return errors;
        }
    }
}