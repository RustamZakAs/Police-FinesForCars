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
                RUS = "Просмотреть все ",
                AZE = "Hamısına baxmaq ",
                ENG = "Show all     ",
                KOR = "모두 보이기"
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

            RZLanguage lang19 = new RZLanguage
            {
                RUS = "Удалить персону ",
                AZE = "Şəxsi sil ",
                ENG = "Delete person",
                KOR = "사람 삭제"
            };
            dictionary.Add("delper", lang19);

            RZLanguage lang20 = new RZLanguage
            {
                RUS = "Изменить персональные данные ",
                AZE = "Şəxsi məlumatı düzəliş et    ",
                ENG = "Change person information    ",
                KOR = "개인 데이터 편집"
            };
            dictionary.Add("changeper", lang20);

            RZLanguage lang21 = new RZLanguage
            {
                RUS = "Работа с персональными данными ",
                AZE = "Şəxsi məlumatla işlər          ",
                ENG = "Work whis personal information ",
                KOR = "개인 데이터 사용"
            };
            dictionary.Add("workperinfo", lang21);

            RZLanguage lang22 = new RZLanguage
            {
                RUS = "Удаление информации о транспортном средстве ",
                AZE = "Maşın üzrə məlumatın silinməsi              ",
                ENG = "Delete car information                      ",
                KOR = "차량 정보 삭제"
            };
            dictionary.Add("delcar", lang22);

            RZLanguage lang23 = new RZLanguage
            {
                RUS = "Изменение информации о транспортном средстве ",
                AZE = "Maşın üzrə məlumatın düzəlişi                ",
                ENG = "Change car information                      ",
                KOR = "차량 정보 수정"
            };
            dictionary.Add("changecar", lang23);

            RZLanguage lang24 = new RZLanguage
            {
                RUS = "Введите регистрационный номер ",
                AZE = "Sənədin qeydiyyat nömrəsini yazın            ",
                ENG = "Insert registration code                      ",
                KOR = "등록 번호를 입력하십시오"
            };
            dictionary.Add("insertregkod", lang24);

            RZLanguage lang25 = new RZLanguage
            {
                RUS = "Введите регистрационный номер машины",
                AZE = "Maşının qeydiyyat nömrəsini yazın            ",
                ENG = "Insert car serial number                      ",
                KOR = "기기 등록 번호를 입력하십시오"
            };
            dictionary.Add("insertcarsernum", lang25);

            RZLanguage lang26 = new RZLanguage
            {
                RUS = "Работа с данными по машинам",
                AZE = "Maşınlar üzrə işlər",
                ENG = "Work whis car information ",
                KOR = "머신 데이터로 작업하기"
            };
            dictionary.Add("workcarinfo", lang26);

            RZLanguage lang27 = new RZLanguage
            {
                RUS = "Работа с документами",
                AZE = "Sənədlər üzrə işlər",
                ENG = "Work whis documents",
                KOR = "문서 작업"
            };
            dictionary.Add("workdocinfo", lang27);

            RZLanguage lang28 = new RZLanguage
            {
                RUS = "Работа со штрафами   ",
                AZE = "Cərimələr üzrə işlər ",
                ENG = "Work whis fines      ",
                KOR = "벌금과 함께 일하십시오"
            };
            dictionary.Add("workfineinfo", lang28);

            RZLanguage lang29 = new RZLanguage
            {
                RUS = "Удалить штраф",
                AZE = "Cəriməni sil",
                ENG = "Delete fine",
                KOR = "패널티 삭제"
            };
            dictionary.Add("delfine", lang29);

            RZLanguage lang30 = new RZLanguage
            {
                RUS = "Изменить штраф",
                AZE = "Cərimədə düzəliş et",
                ENG = "Change fine",
                KOR = "페널티에 대한 정보 수정"
            };
            dictionary.Add("changefine", lang30);

            RZLanguage lang31 = new RZLanguage
            {
                RUS = "Закрыть штраф",
                AZE = "Cəriməni bağla",
                ENG = "Close fine",
                KOR = "페널티를 닫다"
            };
            dictionary.Add("closefine", lang31);

            RZLanguage lang32 = new RZLanguage
            {
                RUS = "",
                AZE = "",
                ENG = "",
                KOR = ""
            };
            dictionary.Add("  ", lang32);

            RZLanguage lang33 = new RZLanguage
            {
                RUS = "",
                AZE = "",
                ENG = "",
                KOR = ""
            };
            dictionary.Add("   ", lang33);

            RZLanguage lang34 = new RZLanguage
            {
                RUS = "",
                AZE = "",
                ENG = "",
                KOR = ""
            };
            dictionary.Add("    ", lang34);

            RZLanguage lang35 = new RZLanguage
            {
                RUS = "",
                AZE = "",
                ENG = "",
                KOR = ""
            };
            dictionary.Add("", lang35);
        }
    }
}
