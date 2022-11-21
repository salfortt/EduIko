using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Abstract
    {
        public string FixDateToSQL(string date)
        {
            string returnDate = "";

            if (date != null)
            {
                string[] holdDate = date.Split('/');

                returnDate = holdDate[2].ToString() + "-" + holdDate[0].ToString() + "-" + holdDate[1].ToString();
            }

            return returnDate;
        }
    }
}
