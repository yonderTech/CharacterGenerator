using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CharacterGenerator
{
    public static class AbilityBuilder
    {
        public static void Build(Character character)
        {

            Random rnd = new Random();

            foreach (AbilityType abilityType in Enum.GetValues(typeof(AbilityType)))
            {
                IAbility ability = new Ability(abilityType);
                character.Abilities.Add(ability);

                if (abilityType == AbilityType.STR)
                {
                    var records = new StrengthPerkRule().Load();

                    var d100 = rnd.Next(1, 101);
                    var d20 = rnd.Next(1, 21);
                    
                    var line = records.SingleOrDefault(x => 
                        (ability.Value != 18 && ability.Value >= x.ScoreMin && ability.Value <= x.ScoreMax) || 
                        (ability.Value == 18 && ability.Value >= x.ScoreMin && ability.Value <= x.ScoreMax && d100 >= x.D100Min && d100 <= x.D100Max))!;
                    
                    if (line == null)
                    {
                        throw new Exception($"Could not find STR perk rule line for value: {abilityType}");
                    }

                    CharacterAbilityPerk perk = new CharacterAbilityPerk(abilityType);
                    perk.Add("Hit Probability", line.HitProb, PerkValueType.Number);
                    perk.Add("DMG Ajust", line.DamageAdjust, PerkValueType.Number);
                    perk.Add("Weight (Carry)", line.WeightAllow, PerkValueType.Number);
                    perk.Add("Maximum Press", line.MaxPress, PerkValueType.Number);
                    perk.Add("Open Doors", line.OpenDoors, PerkValueType.Number);
                    perk.Add("Bend Bars & Lift Gates", line.BendBarsLiftGates!, PerkValueType.Pct);

                    character.AbilityPerks.Add(perk);
                }
            };

            new RaceModifier(character).Apply();
        }

    }
}
