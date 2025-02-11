using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator
{
    public class Race(RaceTypes race) : IRace
    {
        public RaceTypes RaceType { get; set; } = race;
    }

    public interface IRace
    {
        RaceTypes RaceType { get; set; }
    }

    public enum RaceTypes
    {
        Human,
        Dwarf,
        Elf,
        HalfElf,
        Gnome,
        Halfling
    }
}
