using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace AlloyAdvanced.Business.Validation
{
    public class StrongPasswordAttribute : ValidationAttribute
    {
        public string SpecialCharacters { get; set; } = "!@#$&*";
        public int MinimumTotalCharacters { get; set; } = 8;
        public int MinimumUppercaseCharacters { get; set; } = 1;
        public int MinimumLowercaseCharacters { get; set; } = 1;
        public int MinimumDigitCharacters { get; set; } = 1;
        public int MinimumSpecialCharacters { get; set; } = 1;

        public override bool IsValid(object value)
        {
            ErrorMessage = $"Passwored must have : " +
                $"{MinimumDigitCharacters} digits, " +
                $"{MinimumSpecialCharacters} speicla, " +
                $"etc";
            string input = value as string;

            var builder = new StringBuilder();

                builder.Append("^");
            if (MinimumUppercaseCharacters > 0)
            {
                builder.Append("(?=");
                for (int i = 0; i < MinimumUppercaseCharacters; i++)
                {
                    builder.Append(".*[A-Z]");
                }
                builder.Append(")");
            } 
            if (MinimumLowercaseCharacters > 0)
            {
                builder.Append("(?=");
                for (int i = 0; i < MinimumLowercaseCharacters; i++)
                {
                    builder.Append(".*[a-z]");
                }
                builder.Append(")");
            }
            if (MinimumDigitCharacters > 0)
            {
                builder.Append("(?=");
                for (int i = 0; i < MinimumDigitCharacters; i++)
                {
                    builder.Append(".*[0-9]");
                }
                builder.Append(")");
            }

            builder.Append(".{");
            builder.Append(MinimumTotalCharacters);
            builder.Append(",}$");

            return Regex.IsMatch(input, builder.ToString());
        }
    }
}