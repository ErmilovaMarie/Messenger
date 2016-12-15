using Messenger.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Messenger.Services
{
    public class DataService
    {
        private static readonly DataService _dataService = new DataService();

        private readonly HttpClient _httpClient = new HttpClient
        {
            DefaultRequestHeaders = { IfModifiedSince = DateTimeOffset.Now }
        };

        private readonly string _baseUrl = "http://192.168.43.80:9000/";

        protected DataService()
        {

        }

        public static DataService GetInstance ()
        {
            return _dataService;
        }

        public async Task<HttpStatusCode> LoginAsync(string userName, string password)
        {
            try
            {
                // Объявляем пространства имён
                XNamespace defaultNamespace = "http://schemas.servicestack.net/types";
                XNamespace instanceNamespace = "http://www.w3.org/2001/XMLSchema-instance";

                // Создаём корневой элемент с атрибутами и добавляем в документ
                var xmlDocument = new XDocument();
                var auth = new XElement(defaultNamespace + "Auth");
                auth.Add(new XAttribute(XNamespace.Xmlns + "i", instanceNamespace));
                auth.Add(new XElement(defaultNamespace + "UserName", userName));
                auth.Add(new XElement(defaultNamespace + "Password", password));
                xmlDocument.Add(auth);

                var xml = xmlDocument.ToString();

                return (await _httpClient.PostAsync(new Uri($"{_baseUrl}/auth/credentials"),
                    new StringContent (xml, Encoding.UTF8, "application/xml"))).StatusCode;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return HttpStatusCode.SeeOther;
            }
        }
        public async Task<List<ContactModel>> LoadContactsAsync()
        {
            try
            {
                var json = await _httpClient.GetStringAsync(new Uri($"{_baseUrl}/contacts.json"));
                var jObj = JObject.Parse(json);
                return JsonConvert.DeserializeObject<List<ContactModel>>(jObj["Contacts"].ToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new List<ContactModel>();
            }
        }
    }
}
