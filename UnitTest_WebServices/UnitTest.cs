
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest_WebServices
{
    [TestClass]
    public class WebServices
    {
        WebMedicalServicesLib.Main a = new WebMedicalServicesLib.Main();


        [TestMethod]
        public async System.Threading.Tasks.Task TestMethod_SuggestDrugAsync()
        {
            var t = await a.SuggestDrugAsync("hep");
            Assert.IsNotNull(t);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestMethod_DrugDoseAsync()
        {
            var t = await a.DrugDoseAsync("reserpine");
            Assert.IsNotNull(t);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestMethod_DrugActiveIngredientsAsync()
        {
            var t = await a.DrugActiveIngredientsAsync("Hepatolite");
            Assert.IsNotNull(t);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestMethod_DrugInfoAsync()
        {
            var t = await a.GetDrugInfoAsync("198440");
            Assert.IsNotNull(t);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestMethod_DrugInteractionsAsync()
        {
            var t = await a.GetDrugInteractionsAsync("341248");
            Assert.IsNotNull(t);
        }


        [TestMethod]
        public async System.Threading.Tasks.Task TestMethod_ConvertFromNDC2RxAsync()
        {
            var t = await a.ConvertFromNDC2RxAsync("morphine");
            Assert.IsNotNull(t);
        }
    }
}
