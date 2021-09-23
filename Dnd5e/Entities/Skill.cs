using Dnd5e.Enums;
using Microsoft.Data.SqlClient.DataClassification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnd5e.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Description { get; set; }
        public AbilityScores AbilityType { get; set; }
    }
}
