using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Entities;

namespace Common
{
    public class Search
    {
        //public static List<SearchIndex> SearchOnListNews(List<SearchIndex> listSI,PublishSearch ps)
        //{
        //    string fixDateStart = string.Empty;
        //    string fixDateFinish = string.Empty;
        //    DateTime dtStart = new DateTime();
        //    DateTime dtFinish = new DateTime();
        //    IFormatProvider culture = new System.Globalization.CultureInfo("tr-TR", true);

        //    if (ps.DPStartDate != null)
        //    {
        //        fixDateStart = ps.DPStartDate.Split('/')[1] + "." + ps.DPStartDate.Split('/')[0] + "." + ps.DPStartDate.Split('/')[2];
        //        dtStart = DateTime.Parse(fixDateStart, culture, System.Globalization.DateTimeStyles.AssumeLocal);
        //    }
        //    if (ps.DPFinishData != null)
        //    {
        //        fixDateFinish = ps.DPFinishData.Split('/')[1] + "." + ps.DPFinishData.Split('/')[0] + "." + ps.DPFinishData.Split('/')[2];
        //        dtFinish = DateTime.Parse(fixDateFinish, culture, System.Globalization.DateTimeStyles.AssumeLocal);
        //    }
        //    else { dtFinish = DateTime.Now; }

        //    listSI = listSI.Where(
        //                          q => q.CreatedDate > dtStart &&
        //                          q.CreatedDate < dtFinish && 
        //                          q.FK_Category == ((ps.SBCategory==0) ? q.FK_Category : ps.SBCategory) &&
        //                          q.ContentHeader.Contains(ps.SearchValue.Trim()) //&&
        //                          //(q.FK_ContentType == ps.FotoHaber || q.FK_ContentType == ps.MetinHaber || q.FK_ContentType == ps.VideoHaber || q.FK_ContentType == ps.YazarHaber
        //                          //|| (ps.FotoHaber == 0 && ps.MetinHaber == 0 && ps.VideoHaber == 0 && ps.YazarHaber ==0) ? true : false )
                                  
        //                          ).ToList();

        //    return listSI;
        //}
    }
}
