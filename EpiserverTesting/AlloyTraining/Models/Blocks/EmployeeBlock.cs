using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Blocks
{
    [ContentType(DisplayName = "Employee", GUID = "bdfb13ec-4bd0-45d7-84cb-52765bb9f1a5", Description = "Employee")]
    public class EmployeeBlock : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "FirstName",
            Description = "Name field's description",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string FirstName { get; set; }
        [CultureSpecific]
        [Display(
            Name = "LastName",
            Description = "Name field's description",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual string LastName { get; set; }
        [CultureSpecific]
        [Display(
            Name = "HireDate",
            Description = "Name field's description",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual DateTime HireDate{ get; set; }

    }
}