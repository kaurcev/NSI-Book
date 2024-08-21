using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace NSI.Classes
{
    internal class Tools
    {
        public static string NSIServer = "nsi.rosminzdrav.ru";
        public static string userKey = "2b6a3146-9b41-4d0a-a3b0-51d294cf2e03";
        public static string Fetch(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    string responseJson = reader.ReadToEnd();
                    return responseJson;
                }
            }
            catch (WebException ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
                return "";
            }
        }
    }
}
