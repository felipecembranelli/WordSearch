using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace WordSearch
{
    public class DictionaryRepository : IDictionary
    {
        const string SERVICE_END_POINT = "http://teste.way2.com.br/dic/api/words/{0}";

        public string GetWordFromDictionary(long index)
        {
            try
            {
                string url = string.Format(SERVICE_END_POINT,index);

                return CallRestService(url);

            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                    return null;
                else
                    throw ex;
            }
        }

        private string CallRestService(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();

            if (webresponse.StatusCode == HttpStatusCode.NotFound)
            {
                throw new WebException("Word not found", null, WebExceptionStatus.ProtocolError, webresponse);
            }

            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");

            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            
            string result = string.Empty;

            result = responseStream.ReadToEnd();

            webresponse.Close();

            return result;
        }

    }
}
