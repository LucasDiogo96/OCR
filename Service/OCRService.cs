using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Service
{
    public class OCRService
    {
        public  ResponseOCR InitializeOCR(Document document)
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

                return JsonConvert.DeserializeObject<ResponseOCR>("");
            }
            catch (Exception)
            {

                throw;
            }

        }
        #region Private Methods
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

            return String.Concat((document.FileExtension != "PDF" ? "data:image/png;base64," : "data:application/pdf;base64,"), document.Content);
        }
        #endregion


    }
}
