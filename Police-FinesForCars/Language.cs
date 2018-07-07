using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Police_FinesForCars
{
    public enum Lang{RU = 0, AZ, EN, KO }
    class RZLanguage
    {
        public RZLanguage()
        {
        }
        public RZLanguage(string rUS, string aZE, string eNG, string kOR)
        {
            RUS = rUS;
            AZE = aZE;
            ENG = eNG;
            KOR = kOR;
        }

        public string RUS { get; set; }
        public string AZE { get; set; }
        public string ENG { get; set; }
        public string KOR { get; set; }

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
            else if (lang == 2)
            {
                return ENG;
            }
            else return KOR;
        }

        public void CreateDictionary(ref Dictionary<string, RZLanguage> dictionary)
        {
            RZLanguage lang1 = new RZLanguage
            {
                RUS = "Новая персона ",
                AZE = "Yeni şəxs     ",
                ENG = "New person    ",
                KOR = "새로운 사람"
            };
            dictionary.Add("newper", lang1);

            RZLanguage lang2 = new RZLanguage
            {
                RUS = "Новая машина  ",
                AZE = "Yeni maşın    ",
                ENG = "New car       ",
                KOR = "새 차"
            };
            dictionary.Add("newcar", lang2);

            RZLanguage lang3 = new RZLanguage
            {
                RUS = "Новый документ",
                AZE = "Yeni sənəd    ",
                ENG = "New document  ",
                KOR = "새 문서"
            };
            dictionary.Add("newdoc", lang3);

            RZLanguage lang4 = new RZLanguage
            {
                RUS = "Новый штраф  ",
                AZE = "Yeni cərimə  ",
                ENG = "New fine     ",
                KOR = "새로운 페널티"
            };
            dictionary.Add("newfine", lang4);

            RZLanguage lang5 = new RZLanguage
            {
                RUS = "Просмотреть  ",
                AZE = "Baxış        ",
                ENG = "Show         ",
                KOR = "보기"
            };
            dictionary.Add("showall", lang5);

            RZLanguage lang6 = new RZLanguage
            {
                RUS = "Введите имя      ",
                AZE = "Adını daxil edin ",
                ENG = "İnsert name      ",
                KOR = "이름 입력"
            };
            dictionary.Add("insertname", lang6);

            RZLanguage lang7 = new RZLanguage
            {
                RUS = "Введите фамилию     ",
                AZE = "Soyadını daxil edin ",
                ENG = "İnsert surname      ",
                KOR = "성을 입력하십시오"
            };
            dictionary.Add("insertsurname", lang7);

            RZLanguage lang8 = new RZLanguage
            {
                RUS = "Введите отчество     ",
                AZE = "Ata adını daxil edin ",
                ENG = "İnsert patronime     ",
                KOR = "중간 이름 입력"
            };
            dictionary.Add("insertpatronime", lang8);

            RZLanguage lang9 = new RZLanguage
            {
                RUS = "Выход ",
                AZE = "Çıxış ",
                ENG = "Exit  ",
                KOR = "출구"
            };
            dictionary.Add("exit", lang9);

            RZLanguage lang10 = new RZLanguage
            {
                RUS = "Поиск   ",
                AZE = "Axtar   ",
                ENG = "Search  ",
                KOR = "검색"
            };
            dictionary.Add("search", lang10);

            RZLanguage lang11 = new RZLanguage
            {
                RUS = "Новый протокол ",
                AZE = "Yeni protokol  ",
                ENG = "New protocol   ",
                KOR = "새로운 프로토콜"
            };
            dictionary.Add("newprot", lang11);

            RZLanguage lang12 = new RZLanguage
            {
                RUS = "Номер протокола  ",
                AZE = "Protolun nömrəsi ",
                ENG = "Protocol number  ",
                KOR = "프로토콜 번호"
            };
            dictionary.Add("protnum", lang12);

            RZLanguage lang13 = new RZLanguage
            {
                RUS = "Дата протокола  ",
                AZE = "Protolun tarixi ",
                ENG = "Protocol date   ",
                KOR = "프로토콜 날짜"
            };
            dictionary.Add("protdate", lang13);

            RZLanguage lang14 = new RZLanguage
            {
                RUS = "Адресс ",
                AZE = "Ünvan  ",
                ENG = "Adress ",
                KOR = "드레스"
            };
            dictionary.Add("protadress", lang14);

            RZLanguage lang15 = new RZLanguage
            {
                RUS = "Тип штрафа     ",
                AZE = "Cərimənin növü ",
                ENG = "Fine type      ",
                KOR = "페널티 유형"
            };
            dictionary.Add("prottype", lang15);

            RZLanguage lang16 = new RZLanguage
            {
                RUS = "Сумма штрафа      ",
                AZE = "Cərimənin məbləği ",
                ENG = "Fine amount       ",
                KOR = "벌금 액수"
            };
            dictionary.Add("protamount", lang16);

            RZLanguage lang17 = new RZLanguage
            {
                RUS = "Оштрафованное транспортное средство ",
                AZE = "Cərimələnən maşın                   ",
                ENG = "Fine car                            ",
                KOR = "벌금이 부과 된 차량"
            };
            dictionary.Add("protcar", lang17);

            RZLanguage lang18 = new RZLanguage
            {
                RUS = "Штраф оплачен       ",
                AZE = "Cərimə ödənilmişdir ",
                ENG = "Fine paid           ",
                KOR = "유료"
            };
            dictionary.Add("protpaid", lang18);
        }
    }
}
