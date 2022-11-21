using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SmsServices
{
   public   class SendSms
    {



        private   string sURL= " https://api.1sms.com.tr/api/smspost/v1";
        //   string sResponse=GetResponse(sURL, createXml());




        private string userName = "Gurkan";
        private string userSecretKey = "98eeb1a2388ed4c866ef669ffdea7bd9";
        private string messageHeader = "IKO";
        private string validity = "2880";//Mesajın geçerlilik süresi. 

        //  //rapor ID  http://panel.1sms.com.tr:8080/api/dlr/v1?username=Gurkan&password=98eeb1a2388ed4c866ef669ffdea7bd9&id=10166159 
        public string SendOneMessageMultiPhone(string message, List<string> phones,string sendDateTime)
        {



            StringBuilder sb = new StringBuilder();
            StringWriterWithEncoding stringWriter = new StringWriterWithEncoding(sb, Encoding.UTF8);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.CloseOutput = true;
            settings.Indent = true;
            settings.IndentChars = ("   ");

            if(!string.IsNullOrEmpty(message) &&  phones != null && phones.Count > 0) { 

            using (XmlWriter writer = XmlWriter.Create(stringWriter, settings))
            {
                
                writer.WriteStartElement("sms");
                writer.WriteElementString("username", userName);
                writer.WriteElementString("password", userSecretKey);
                writer.WriteElementString("header", messageHeader);
                // if (!string.IsNullOrEmpty(sendDateTime))
                //writer.WriteElementString("sendDateTime", sendDateTime);
                writer.WriteElementString("validity", validity);
                writer.WriteStartElement("message");


                writer.WriteStartElement("gsm");
                foreach (var item in phones)
                    writer.WriteElementString("no", item);//Numaraları ekliyoruz
                
                writer.WriteEndElement();//gsm
                writer.WriteStartElement("msg");
                writer.WriteCData(message);
                writer.WriteEndElement();//msg
                writer.WriteEndElement();//message
                writer.WriteEndElement();// sms
                writer.Flush();
            }



                return GetResponse(sURL, stringWriter.ToString());

            }


            return "Mesaj ya da gönderi Listesi Yok";
        }



        private string GetResponse(string sURL, string sXml)
        {
            //string result = "";
            //string tt = "";
            try
            {
                HttpWebRequest request = WebRequest.Create(new Uri(sURL)) as HttpWebRequest;
                request.Method = "POST";
                request.Accept = "application/json";// ;odata=verbose";
                request.ContentType = "application/json; charset=utf-8";
                request.Timeout = 5000;
               
                byte[] data = UTF8Encoding.UTF8.GetBytes(sXml);
                request.ContentLength = data.Length;
               



                //result = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);

                //return result;



                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(data, 0, data.Length);
                }
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           // return "";
        }

        public class StringWriterWithEncoding : StringWriter
        {
            public StringWriterWithEncoding(StringBuilder sb, Encoding encoding)
                : base(sb)
            {
                this.m_Encoding = encoding;
            }
            private readonly Encoding m_Encoding;
            public override Encoding Encoding
            {
                get
                {
                    return this.m_Encoding;
                }
            }
        }

    }
}
 