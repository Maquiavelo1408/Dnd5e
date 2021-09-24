using Dnd5e.Enums;
using Microsoft.Data.SqlClient.DataClassification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnd5e.Entities
{
    public class CharacterSkill
    {
        public int CharacterId { get; set; }
        public int SkillId { get; set; }
        public SkillBonusType SkillBonusType { get; set; } 
        public Character Character { get; set; }
        public Skill Skill { get; set; }
    }
}
