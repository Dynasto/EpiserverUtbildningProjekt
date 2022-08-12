using EPiServer.Core;
using EPiServer.PlugIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyTraining.Models.Properties
{
    [PropertyDefinitionTypePlugIn(DisplayName = "Hejsan tjosan PErson list", Description = "beskrivningen lol")]
    public class PropertyPersonClassList : PropertyList<PersonClass>
    {
    }
}