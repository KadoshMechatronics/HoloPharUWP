using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;    // to read a local text file
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebMedicalServicesLib.JSONClasses.NDFRT;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using WebMedicalServicesLib.JSONClasses.MAPI;
using WebMedicalServicesLib.JSONClasses.rxnav;
using System.Collections.ObjectModel;
using HoloPharUWP.Models;

namespace WebMedicalServicesLib
{
    public class Main
    {
        /// <summary>
        /// اقتراح أسماء الأدوية بناء على الأحرف
        /// </summary>
        /// <param name="p1"></param>
        /// <returns></returns>
        public async Task<List<string>> SuggestDrugAsync(string p1 = "penicillin")
        {
            var res = await ReadJSON("http://mapi-us.iterar.co/api/autocomplete?query={0}", p1);
            var result = JsonConvert.DeserializeObject<MAPI>(res);
            return result.suggestions;
        }



        /// <summary>
        /// جلب جرعات الدواء بناء على الاسم
        /// </summary>
        /// <param name="p1"></param>
        /// <returns></returns>
        public async Task<ObservableCollection<SubMenu>> DrugDoseAsync(string p1 = "Heparin")
        {
            var res = await ReadJSON("http://mapi-us.iterar.co/api/{0}/doses.json", p1);
            JArray a = JArray.Parse(res);
            ObservableCollection<SubMenu> li = new ObservableCollection<SubMenu>();
        
            return li;
        }


        /// <summary>
        /// Get drug doses based on it's name
        /// </summary>
        /// <param name="p1"></param>
        /// <returns></returns>
        public async Task<List<string>> DrugActiveIngredientsAsync(string p1 = "Heparin")
        {
            var res = await ReadJSON("http://mapi-us.iterar.co/api/{0}/substances.json", p1);
            JArray a = JArray.Parse(res);
            List<string> li = new List<string>();
            foreach (var c in a)
            {
                li.Add(c.ToString());
            }
            return li;
        }


        /// <summary>
        /// جلب تفاصيل الدواء
        /// </summary>
        /// <param name="p1">رقم الدواء</param>
        /// <returns></returns>
        public async Task<RxtermsProperties> GetDrugInfoAsync(string p1 = "")
        {
            var res = await ReadJSON("https://rxnav.nlm.nih.gov/REST/RxTerms/rxcui/{0}/allinfo.json", p1);
            var result = JsonConvert.DeserializeObject<RxtermsProperties>(res);
            return result;
        }



        /// <summary>
        /// عرض تداخلات دواء معين
        /// </summary>
        /// <param name="p1"></param>
        /// <returns></returns>
        public async Task<RxInteraction> GetDrugInteractionsAsync(string p1 = "aspirin")
        {
            var res = await ReadJSON("https://rxnav.nlm.nih.gov/REST/interaction/interaction.json?rxcui={0}", p1);
            var result = JsonConvert.DeserializeObject<RxInteraction>(res);
            return result;
        }


        /// <summary>
        /// تحول الدواء من رقم معروف الى رقم خاص
        /// </summary>
        /// <param name="p1"></param>
        /// <returns></returns>
        public async Task<Converter> ConvertFromNDC2RxAsync(string p1 = "")
        {
            var res = await ReadJSON("https://rxnav.nlm.nih.gov/REST/rxcui.json?idtype=NDC&id={0}", p1);
            var result = JsonConvert.DeserializeObject<Converter>(res);
            return result;
        }


        /// <summary>
        /// تعيد هذه الدالة جيسون من الرابط المرسل
        /// </summary>
        /// <param name="url"></param>
        /// <param name="p1"></param>
        /// <returns></returns>
        private async Task<string> ReadJSON(string url, string p1 = "")
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(String.Format(url, p1));
            var jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }

    }
}
