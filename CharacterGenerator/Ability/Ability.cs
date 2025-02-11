using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator
{
    public class Ability : IAbility
    {
        public AbilityType AbilityType { get; set; }
        public int Value { get; set; }
        
        public Ability(AbilityType abilityType)
        {
            AbilityType = abilityType;
            var rnd = new Random();
            int[] dices = { rnd.Next(1, 7), rnd.Next(1, 7), rnd.Next(1, 7) };
            Value = dices.Sum();
        }
    }

    public interface IAbility
    {
        AbilityType AbilityType { get; set; }
        int Value { get; set; }
    }

    public enum AbilityType
    {
        STR,
        DEX,
        CON,
        INT,
        WIS,
        CHR
    }
}
