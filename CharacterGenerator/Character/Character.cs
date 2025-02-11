using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator
{
    public class Character
    {
        public Character(RaceTypes race)
        {
            Race = new Race(race);
            AbilityBuilder.Build(this);
            Movement = new Movement(this);
        }

        public List<IAbility> Abilities { get; set; } = [];
        public IRace Race { get; set; }
        public Movement Movement { get; set; }
        public List<CharacterAbilityPerk> AbilityPerks { get; set; } = [];


    }
}
