using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SucculentShop.Utilities
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime Date)
        {
            PersianCalendar persianCalendar=new PersianCalendar();
            return persianCalendar.GetYear(Date) + "/" + persianCalendar.GetMonth(Date).ToString("00") + "/" +
                   persianCalendar.GetDayOfMonth(Date).ToString("0");
        }
    }
}