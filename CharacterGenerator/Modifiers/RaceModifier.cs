using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator
{
    public class RaceModifier : IRaceModifier
    {

        public RaceModifier(Character character)
        {
            Character = character;
        }

        public Character Character { get; set; }

        public void Apply()
        {
            var race = Character.Race.RaceType;

            if (race != RaceTypes.Human && race != RaceTypes.HalfElf)
            {
                foreach (var ability in Character.Abilities)
                {
                    switch (race)
                    {
                        case RaceTypes.Elf:
                            if (ability.AbilityType == AbilityType.DEX) ability.Value++;
                            if (ability.AbilityType == AbilityType.CON) ability.Value--;
                            break;
                        case RaceTypes.Halfling:
                            if (ability.AbilityType == AbilityType.DEX) ability.Value++;
                            if (ability.AbilityType == AbilityType.STR) ability.Value--;
                            break;
                        case RaceTypes.Dwarf:
                            if (ability.AbilityType == AbilityType.CON) ability.Value++;
                            if (ability.AbilityType == AbilityType.CHR) ability.Value--;
                            break;
                        case RaceTypes.Gnome:
                            if (ability.AbilityType == AbilityType.INT) ability.Value++;
                            if (ability.AbilityType == AbilityType.WIS) ability.Value--;
                            break;
                    }
                }
            }
        }

    }

    public interface IRaceModifier
    {
        void Apply();
        Character Character { get; set; }

    }
}
