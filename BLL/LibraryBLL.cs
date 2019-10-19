using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace BLL
{
    public class LibraryBLL
    {
        public static ResponseOCR InitializeOCR(Document document)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(GetEndpoint());

                NameValueCollection outgoingQueryString = HttpUtility.ParseQueryString(String.Empty);
                outgoingQueryString.Add("language", "por");
                outgoingQueryString.Add("isOverlayRequired", "true");
                outgoingQueryString.Add("base64Image", GetApplication(document));
                outgoingQueryString.Add("iscreatesearchablepdf", "false");
                outgoingQueryString.Add("issearchablepdfhidetextlayer", "false");
                outgoingQueryString.Add("OCREngine", GetEngine(document));
                outgoingQueryString.Add("filetype", document.FileExtension);

                string postdata = outgoingQueryString.ToString();

                var data = Encoding.ASCII.GetBytes(postdata);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.Headers.Add("apikey", "API-KEY");
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream());

                return JsonConvert.DeserializeObject<ResponseOCR>(responseString.ReadToEnd());
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        private static string GetEndpoint()
        {
            return "https://api.ocr.space/parse/image";
        }
        private static string GetEngine(Document document)
        {
            return ((document.FileExtension != "PDF") ? "2" : "1");
        }
        private static string GetApplication(Document document)
        {

            return String.Concat((document.FileExtension != "PDF" ? "data:image/png;base64," : "data:application/pdf;base64,"),document.Content);
        }
        public static string RemoveSpecialCharacters(ref string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
