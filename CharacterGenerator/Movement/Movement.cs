using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator
{
    public class Movement
    {
        public Movement(Character character)
        {
            switch (character.Race.RaceType)
            {
                case RaceTypes.Dwarf:
                    Value = 6;
                    break;
                case RaceTypes.Elf:
                    Value = 12;
                    break;
                case RaceTypes.HalfElf:
                    Value = 12;
                    break;
                case RaceTypes.Halfling:
                    Value = 6;
                    break;
                case RaceTypes.Human:
                    Value = 12;
                    break;
                case RaceTypes.Gnome:
                    Value = 6;
                    break;
            }
        }

        public int Value { get; set; }
    }

}
