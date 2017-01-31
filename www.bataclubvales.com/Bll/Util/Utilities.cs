using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data;
namespace www.bataclubvales.com.Bll
{
    public class Utilities
    {
        public static void logout(HttpSessionState session, System.Web.HttpResponse response)
        {
            string url = FormsAuthentication.LoginUrl;
            session.Clear();
            session.Abandon();
            FormsAuthentication.SignOut();
            response.Redirect(url, true);
        }
        public static DataTable getFilterObject(object dtObj, string f1, string f2, string f3,string f4,string f5,string f6,
          string fieldValue1, string fieldValue2, string fieldValue3,string fieldValue4,string fieldValue5,string fieldValue6)
        {
            try
            {
                DataTable ds = (DataTable)dtObj;
                var result = (from x in ds.AsEnumerable()
                              where 
                              (x.Field<string>(f1).ToUpper().Contains((!string.IsNullOrEmpty(fieldValue1) ? fieldValue1.ToUpper() : string.Empty))
                              ||
                              (!string.IsNullOrEmpty(Convert.ToString(x[f2])) ? Convert.ToString(x[f2]) : string.Empty).Contains((!string.IsNullOrEmpty(fieldValue2) ? fieldValue2.ToUpper() : string.Empty))
                              ||
                              (!string.IsNullOrEmpty(Convert.ToString(x[f3]).ToUpper()) ? Convert.ToString(x[f3]).ToUpper() : string.Empty).Contains((!string.IsNullOrEmpty(fieldValue3.ToUpper()) ? fieldValue3.ToUpper() : string.Empty))
                              ||
                              (!string.IsNullOrEmpty(Convert.ToString(x[f4])) ? Convert.ToString(x[f4]) : string.Empty).Contains((!string.IsNullOrEmpty(fieldValue4) ? fieldValue4.ToUpper() : string.Empty))
                              ||
                              (!string.IsNullOrEmpty(Convert.ToString(x[f5])) ? Convert.ToString(x[f5]) : string.Empty).Contains((!string.IsNullOrEmpty(fieldValue5) ? fieldValue5.ToUpper() : string.Empty))
                              ||
                              (!string.IsNullOrEmpty(Convert.ToString(x[f6])) ? Convert.ToString(x[f6]) : string.Empty).Contains((!string.IsNullOrEmpty(fieldValue6) ? fieldValue6.ToUpper() : string.Empty))
                              //x.Field<string>(f5).ToUpper().Contains((!string.IsNullOrEmpty(fieldValue5) ? fieldValue5.ToUpper() : string.Empty))
                              //||
                              //x.Field<string>(f6).ToUpper().Contains((!string.IsNullOrEmpty(fieldValue6) ? fieldValue6.ToUpper() : string.Empty))
                              )
                              
                              //where x.Field<string>(f1).ToUpper().Contains((!string.IsNullOrEmpty(fieldValue1) ? fieldValue1.ToUpper() : string.Empty)) 
                              //orderby x.Field<string>(fieldOrder)
                              select x).CopyToDataTable();
                return result;
            }
            catch(Exception exc)
            {
                return new DataTable();
            }
        }
    }
}