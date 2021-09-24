using System;
using System.Collections.Generic;
using System.Text;

namespace Dnd5e.Entities
{
    public class AttributeSkill
    {
        public int AttributeId { get; set; }
        public int SkillId { get; set; }
        public int Quantity { get; set; }
        public CharacterAttribute CharacterAttribute { get; set; }
        public Skill Skill { get; set; }
    }
}
