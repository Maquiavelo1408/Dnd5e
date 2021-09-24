using Dnd5e.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnd5e.Entities
{
    public class CharacterAttribute
    {
        public int CharacterAttributeId { get; set; }
        public string Name { get; set; }
        public AttributeType AttributeType { get; set; }
        public string Prerequisite { get; set; }
    }
}
