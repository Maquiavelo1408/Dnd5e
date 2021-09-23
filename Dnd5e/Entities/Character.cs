using Dnd5e.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnd5e.Entities
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public virtual Classes Classes { get; set; }
        //public int IdSubClass { get; set; }
        public int StrengthScore { get; set; }
        public int  DexterityScore { get; set; }
        public int ConstitutionScore { get; set; }
        public int IntelligenceScore { get; set; }
        public int WisdomScore { get; set; }
        public int CharismaScore { get; set; }
        public int HitPoints { get; set; }
        public int WalkingSpeed { get; set; }
        public int FlyingSpeed { get; set; }
        public int SwimingSpeed { get; set; }
        public Aligment Aligment { get; set; }
    }
}
