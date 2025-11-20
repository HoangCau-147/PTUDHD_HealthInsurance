using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Crmf;
using Service.Contracts.Payments;
using Shared.EntityDtos.Payment.Momo.Request;
using Shared.Helper.Momo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Payment.Momo
{
    public class MomoService : IMomoService
    {
        private IConfiguration _configuration;
        public MomoService(IConfiguration configuration) { 
            this._configuration = configuration;
        }
        private string sendPaymentRequest(string endpoint, string postJsonString)
        {

            try
            {
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(endpoint);

                var postData = postJsonString;

                var data = Encoding.UTF8.GetBytes(postData);

                httpWReq.ProtocolVersion = HttpVersion.Version11;
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/json";
                httpWReq.Headers.Add("charset", "UTF-8");

                httpWReq.ContentLength = data.Length;
                httpWReq.ReadWriteTimeout = 30000;
                httpWReq.Timeout = 15000;
                Stream stream = httpWReq.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();

                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();

                string jsonresponse = "";

                using (var reader = new StreamReader(response.GetResponseStream()))
                {

                    string temp = null;
                    while ((temp = reader.ReadLine()) != null)
                    {
                        jsonresponse += temp;
                    }
                }


                //todo parse it
                return jsonresponse;
                //return new MomoResponse(mtid, jsonresponse);

            }
            catch (WebException e)
            {
                return e.Message;
            }
        }

        public string PaymentRequest(MomoOneTimePaymentRequestDto paymentRequestDto)
        {
            string endpoint = _configuration["Momo:PaymentUrl"];
            string partnerCode = _configuration["Momo:PartnerCode"];
            string accessKey = _configuration["Momo:AccessKey"];
            string serectkey = _configuration["Momo:SecretKey"];
            string returnUrl = _configuration["Momo:ReturnUrl"];
            string notifyurl = "https://4c8d-2001-ee0-5045-50-58c1-b2ec-3123-740d.ap.ngrok.io/Home/SavePayment"; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test

            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";
            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                paymentRequestDto.amount + "&orderId=" +
                paymentRequestDto.orderId + "&orderInfo=" +
                paymentRequestDto.orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            //sign signature SHA256
            string signature = MomoSecurity.signSHA256(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", paymentRequestDto.amount },
                { "orderId", paymentRequestDto.orderId },
                { "orderInfo", paymentRequestDto.orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }
            };

            string responseFromMomo = sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);
            return jmessage["payUrl"].ToString();
        }
    }
}
