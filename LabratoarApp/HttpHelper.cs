using PaymentStationApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Business
{
    public class HttpHelper
    {
        public static CookieContainer Post(string urlPath, string data)
        {
            var dataStream = Encoding.UTF8.GetBytes(data);
            var webRequest = WebRequest.Create(urlPath);
            webRequest.Method = "POST";
            ServicePointManager.ServerCertificateValidationCallback =
                new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = dataStream.Length;
            Stream newStream = webRequest.GetRequestStream();
            CookieContainer cookieContainer = new CookieContainer();
            if (webRequest is HttpWebRequest)
            {
                (webRequest as HttpWebRequest).CookieContainer = cookieContainer;
            }

            // Send the data.
            newStream.Write(dataStream, 0, dataStream.Length);
            newStream.Close();
            WebResponse response = webRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            var result = reader.ReadToEnd();
            return (webRequest as HttpWebRequest).CookieContainer;
        }

        public string GetNetworkData(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Credentials = new NetworkCredential("admin", "admin");
            request.AutomaticDecompression = DecompressionMethods.GZip;
            ServicePointManager.ServerCertificateValidationCallback =
                new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);


            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private static bool AcceptAllCertifications(object sender,
            System.Security.Cryptography.X509Certificates.X509Certificate certification,
            System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        
        public static string baseURL = "https://78.157.33.182:8443/nafis-web-4/services/ipg";
        
        static HttpClient client = new HttpClient();

        public static string Get(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                var responseTask = client.GetAsync(url);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var students = readTask.Result;
                    return students;
                }
            }
            return string.Empty;
        }

        public async static Task<ServiceResult> GetAsync(string url, Dictionary<string,string> parameters, CancellationToken cancellationToken)
        {
            try
            {
                url += "?";

                foreach (var param in parameters)
                {
                    if(!string.IsNullOrEmpty(param.Value))
                        url += string.Format("{0}={1}&",Uri.EscapeDataString(param.Key),Uri.EscapeDataString(param.Value));
                }

                /*
                var getTask = 
                getTask.Wait(cancellationToken);
                */
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ServiceResult>();
                    readTask.Wait();

                    var resultService = readTask.Result;
                    return new ServiceResult()
                    {
                        RefNo = resultService.RefNo,
                        ClientRefNo = resultService.ClientRefNo,
                        Date = resultService.Date,
                        Message = resultService.Message,
                        Status = resultService.Status,
                        Time = resultService.Time,
                    };
                }
            }
            catch (Exception ex)
            {
             
            }

            return null;
        }

        public static ServiceResult Post<T>(string url, T parameters, CancellationToken cancellationToken) 
        {
            try
            {
                var postTask = client.PostAsJsonAsync<T>(url, parameters);
                postTask.Wait(cancellationToken);

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ServiceResult>();
                    readTask.Wait();

                    var resultService = readTask.Result;
                    return new ServiceResult()
                    {
                        RefNo = resultService.RefNo,
                        ClientRefNo = resultService.ClientRefNo,
                        Date = resultService.Date,
                        Message = resultService.Message,
                        Status = resultService.Status,
                        Time = resultService.Time
                    };
                }
            }
            catch (Exception)
            {
            }

            return null;
        }
    }
}
