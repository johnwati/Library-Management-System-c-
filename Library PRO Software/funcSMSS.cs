using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
namespace School_Software
{
    class funcSMSS
    {
        public void SMSFunc(string st1, string st2, string st3)
        {
            st3 = st3.Replace("@MobileNo", st1).Replace("@Message", st2);
            HttpWebRequest request = default(HttpWebRequest);
            HttpWebResponse response = null;
            Uri myUri = new Uri(st3);
            request = (HttpWebRequest)WebRequest.Create(myUri);
            response = (HttpWebResponse)request.GetResponse();
        }
    }
}
