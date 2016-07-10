using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScienceJourney.ExceptionHandling;
using System.Reflection;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void ExceptionHandlingFailCallBackIleCalisiyorMu()
        {
            string error = "";

            ExceptionManager.getInstance().TryCatch(() =>
            {
                UnitTest1.IslemYap();
            }, MethodBase.GetCurrentMethod(), null,
                i =>
                {
                    error = ExceptionManager.getInstance().HandleTheError(i, "Benim Başlağım 1");
                }, false);
            Assert.AreNotEqual(error, "");
        }
    }
}
