using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaiduInMetro.Controllers
{
    public class ProxyController : ApiController
    {
        // GET api/proxy
        public string Get()
        {
            return "This is cross-domain AJAX proxy, request with URL to get resource.";
        }

        public string GetByUrl(string Url)
        {
            //string strURL = "http://www.baidu.com";
            String strUrl = Url;
            String result;
            WebResponse objResponse;
            WebRequest objRequest;
            StreamReader sr;
            
            try {
                objRequest = HttpWebRequest.Create(strUrl);
                
                // Send request and wait for response
                objResponse = objRequest.GetResponse();

                // Get charset name
                string CharSet = "";
                string strType = objResponse.Headers["Content-Type"].ToString();
                if (!string.IsNullOrEmpty(strType))
                {
                    int strIndex = strType.IndexOf("charset=");
                    if (strIndex > 0)
                        CharSet = strType.Substring(strIndex + 8);
                    else
                        CharSet = "utf-8";
                }

                sr = new StreamReader(objResponse.GetResponseStream(), System.Text.Encoding.GetEncoding(CharSet));
                result = sr.ReadToEnd();

                sr.Close();
                objResponse.Close();
            }
            catch (Exception ex){
                return ex.Message;
            }
   
            return result;
        }

    }
}
