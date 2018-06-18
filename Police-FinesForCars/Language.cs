using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Police_FinesForCars
{
    public enum Lang{RU = 0, AZ, EN }
    class RZLanguage
    {
        public RZLanguage()
        {
        }
        public RZLanguage(string rUS, string aZE, string eNG)
        {
            RUS = rUS;
            AZE = aZE;
            ENG = eNG;
        }

        public string RUS { get; set; }
        public string AZE { get; set; }
        public string ENG { get; set; }

        public string RetLang(int lang)
        {
            if (lang == 0)
            {
                return RUS;
            }
            else if (lang == 1)
            {
                return AZE;
            }
            else return ENG;
        }

        public void CreateDictionary(ref Dictionary<string, RZLanguage> dictionary)
        {
            RZLanguage lang1 = new RZLanguage
            {
                RUS = "Новая персона",
                AZE = "Yeni şəxs",
                ENG = "New person"
            };
            dictionary.Add("menyu 1", lang1);

            RZLanguage lang2 = new RZLanguage
            {
                RUS = "Новая машина",
                AZE = "Yeni maşın",
                ENG = "New car"
            };
            dictionary.Add("menyu 2", lang2);

            RZLanguage lang3 = new RZLanguage
            {
                RUS = "Новый документ",
                AZE = "Yeni sənəd",
                ENG = "New document"
            };
            dictionary.Add("menyu 3", lang3);

            RZLanguage lang4 = new RZLanguage
            {
                RUS = "Новый штраф",
                AZE = "Yeni cərimə",
                ENG = "New fine"
            };
            dictionary.Add("menyu 4", lang4);
        }
    }
}
