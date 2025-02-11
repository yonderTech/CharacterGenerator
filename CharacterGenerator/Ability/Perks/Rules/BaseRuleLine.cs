using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator
{
    public abstract class BaseRuleLine<T>()
    {
        protected BaseRuleLine(AbilityType abilityType) : this()
        {
            AbilityType = abilityType;
        }

        [CsvHelper.Configuration.Attributes.Ignore]
        public AbilityType AbilityType { get; set; }

        public virtual List<T> Load()
        {
            var cultureInfo = new CultureInfo("en-US", false);

            var config = new CsvConfiguration(cultureInfo)
            {
                Delimiter = "\t",
                Encoding = Encoding.ASCII
            };

            var fileName = AbilityType == AbilityType.CON ? "cons" : AbilityType.ToString().ToLower();
            using (var reader = new StreamReader(@$"Ability\Perks\Rules\Scores\{fileName}.tsv.txt"))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<T>();
                return records.ToList();
            };
        }
    }
}
