using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Media
{
    [ContentType(DisplayName = "AnyFile", GUID = "9b241b80-ddda-40c5-9919-e5d3ed2c0998", Description = "")]
    public class AnyFile : MediaData
    {

    }
}