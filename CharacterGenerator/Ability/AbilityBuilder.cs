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

                    var line = records.SingleOrDefault(x => x.Score == ability.Value.ToString() ||
                        Regex.Match(x.Score!, $"{ability.Value}--[0-9]+|[0-9]+--{ability.Value}").Length > 0 ||
                        x.Score == "18" && x.D100Min >= d100 && x.D100Max <= d100 && x.D20Min >= d20 && x.D20Max <= d20
                    );
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
