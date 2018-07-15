using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Police_FinesForCars
{
    public class Search
    {

        public Search()
        {

        }

        public static int FindCount(ref List<Owner> owners, 
                             string insert_name = "",
                             string insert_surname = "",
                             string insert_patronime = "",
                             DateTime? insert_dateofbirdth = null,
                             string insert_reg_ser = "",
                             string insert_reg_kod = "",
                             string insert_car_serial_number = "")
        {
            if (insert_dateofbirdth == null)
            {
                insert_dateofbirdth = new DateTime(1900, 01, 01);
            }

            var xxx = owners.Find(u => u.Name == insert_name);
            return 0;

            //return owners
            //  //.GroupBy(l => l.Date)
            //  .Select(g => new
            //  {
            //      insert_name = g.Name,
            //      insert_surname = g.Surname,
            //      insert_patronime = g.Patronime,
            //      insert_dateofbirdth = g.BirtDay
            //  }).Count();

            //return owners.Count(select );
        }

        public Search(ref List<Owner> owners)
        {

        }
        // 88888 - base is empty - база пуста
        // 99999 - base in exist info those. repeat - в базе есть подобная инфа т.е. повтор
        // 77777 - base in not this info - в базе нет такой информации
        // 66666 - 
        // index - base in exist info (1 piece) - в базе есть инфа (1 шт)
        public static int SearchWhisInfo(ref List<Owner> owners, string insert_name = "",
            string insert_surname = "",
            string insert_patronime = "",
            DateTime? insert_dateofbirdth = null,
            string insert_reg_ser = "",
            string insert_reg_kod = "",
            string insert_car_serial_number = "")
        {
            if (owners.Count == 0) return 88888;
            if (insert_name.Length > 0 & 
                !owners.Exists(x => x.Name == insert_name))
            {
                return 77777;
            }
            if (insert_surname.Length > 0 & 
                !owners.Exists(x => x.Surname == insert_surname))
            {
                return 77777;
            }
            if (insert_patronime.Length > 0 & 
                !owners.Exists(x => x.Patronime == insert_patronime))
            {
                return 77777;
            }
            if (insert_dateofbirdth == null)
            {
                insert_dateofbirdth = new DateTime(1900, 01, 01);
            }
            if (insert_dateofbirdth != DateTime.Parse("01.01.1900") &
                !owners.Exists(x => x.BirtDay == insert_dateofbirdth))
            {
                return 77777;
            }
            if (insert_reg_ser.Length > 0 &
                !owners.Exists(x => x.MyDocuments.Exists(y => y.RegistrationKod.Seriya == insert_reg_ser)))
            {
                return 77777;
            }
            if (insert_patronime.Length > 0 &
                !owners.Exists(x => x.MyDocuments.Exists(y => y.RegistrationKod.Number == insert_reg_kod)))
            {
                return 77777;
            }
            if (insert_car_serial_number.Length > 0 &
                !owners.Exists(x => x.MyDocuments.Exists(y => y.CarSerialNumber.Exists(z => z == insert_car_serial_number))))
            {
                return 77777;
            }

            List<int> xindex = new List<int>();

            for (int i = 0; i < owners.Count; i++)
            {
                if (insert_name.Length > 0)
                {
                    if (owners[i].Name.Equals(insert_name))
                    {
                        xindex.Add(i);
                    }
                }
                if (insert_surname.Length > 0)
                {
                    if (owners[i].Surname.Equals(insert_surname))
                    {
                        xindex.Add(i);
                    }
                }
                if (insert_patronime.Length > 0)
                {
                    if (owners[i].Patronime.Equals(insert_patronime))
                    {
                        xindex.Add(i);
                    }
                }
                if (insert_reg_ser.Length > 0)
                {
                    if (owners[i].MyDocuments.Exists(x => x.RegistrationKod.Seriya == insert_reg_ser))
                    {
                        xindex.Add(i);
                    }
                }
                if (insert_reg_kod.Length > 0)
                {
                    if (owners[i].MyDocuments.Exists(x => x.RegistrationKod.Number == insert_reg_kod))
                    {
                        xindex.Add(i);
                    }
                }
                if (insert_car_serial_number.Length > 0)
                {
                    foreach (var owdoc in owners[i].MyDocuments)
                    {
                        if (owdoc.Equals(insert_car_serial_number))
                        {
                            xindex.Add(i);
                        }
                    }
                }
            }
            Dictionary<int, int> xsxs = new Dictionary<int, int>();
            for (int r = 0; r < xindex.Count; r++)
            {
                if (xsxs.ContainsKey(xindex[r]))
                {
                    xsxs[xindex[r]]++;
                }
                else
                {
                    xsxs.Add(xindex[r], 1);
                }
            }
            int indexMaxCount = 0;
            for (int i = 0; i < xsxs.Count; i++)
            {
                int LastCount = xsxs.Keys.ElementAt(i);
                int result = xsxs.Values.Count(x => x == LastCount);
                if (result > 1) return 99999;
                if (result == 1) return xsxs.Keys.ElementAt(0);

                indexMaxCount = result;
            }

            //int maxCount = 0;
            //int indexMaxCount = 0;
            //for (int i = 0; i < xsxs.Count; i++)
            //{
            //    int LastCount = xsxs.Keys.ElementAt(i);
            //    if (xsxs[xindex[i]] > maxCount)
            //    {
            //        indexMaxCount = i;
            //        maxCount = 0;
            //    }
            //}
            //int replayIndex = 0;
            //for (int i = 0; i < xsxs.Count; i++)
            //{
            //    if (indexMaxCount == xsxs[i])
            //    {
            //        replayIndex++;
            //    }
            //}
            //if (replayIndex > 1) return 99999;
            //for (int i = 0; i < xsxs.Count; i++)
            //{
            //    for (int j = 0; j < xindex.Count; j++)
            //    {
            //        if (xsxs[i] == xindex[j]) xcount++;
            //    }
            //    if (xcount > maxCount)
            //    {
            //        maxCount = xcount;
            //        indexMaxCount = i;
            //    }
            //    xcount = 0;
            //}

            //int[] rezult = new int[1] { indexMaxCount };

            //int[] rezult = new int[xindex.Count == 0 ? 1 : xindex.Count];
            //for (int i = 0; i < xindex.Count; i++)
            //{
            //    rezult[i] = xindex[i];
            //}
            //if (xindex.Count == 0) rezult[0] = 99999;
            return indexMaxCount;
        }
    }
}
