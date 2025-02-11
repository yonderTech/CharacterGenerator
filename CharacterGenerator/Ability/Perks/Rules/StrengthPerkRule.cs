using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator
{
    public class StrengthPerkRule : BaseRuleLine<StrengthPerkRule>
    {
        public StrengthPerkRule() : base(AbilityType.STR)
        {

        }

        public override List<StrengthPerkRule> Load()
        {
            return base.Load();
        }

        public int ScoreMin { get; set; }
        public int ScoreMax { get; set; }
        public int D100Min { get; set; }
        public int D100Max { get; set; }
        public int HitProb { get; set; }
        public int DamageAdjust { get; set; }
        public int WeightAllow { get; set; }
        public int MaxPress { get; set; }
        public int OpenDoors { get; set; }
        public string? BendBarsLiftGates { get; set; }

    }
}
