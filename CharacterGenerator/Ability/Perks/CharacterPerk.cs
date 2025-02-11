using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator
{
    public class CharacterAbilityPerk
    {
        public CharacterAbilityPerk(AbilityType abilityType)
        {
            AbilityType = abilityType;
        }

        public AbilityType AbilityType { get; set; }
        public List<Perk> Perks { get; set; } = [];

        public void Add(string title, object value, PerkValueType perkValueType)
        {   
            Perks.Add(new Perk { Title = title, Value = value, PerkValueType = perkValueType});
        }
    }

    public class Perk
    {
        public object? Value { get; set; }
        public PerkValueType PerkValueType { get; set; }
        public string? Title { get; set; }

    }

    public enum PerkValueType
    {
        Number,
        Pct,
        Text
    }
}
