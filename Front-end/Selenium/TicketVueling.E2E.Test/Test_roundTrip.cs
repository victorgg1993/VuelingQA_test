using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

namespace TicketVueling.E2E.Test
{
    [TestClass]
    public class Test_roundTrip
    {
        static IWebDriver driver;
        static string url = "https://m.vueling.com/";
        static string placeOrigin = "Barcelona";
        static string placeDestination = "Madrid";
        static int genericTimeout = 5000;
        string originDate = "12/08/21"; // pending to fix
        string destinationDate = "15/08/21";

        [ClassInitialize]
        public static void TestSetup(TestContext _context)
        {
            //url = _context.Properties["targetURL"].ToString();
            //placeOrigin = _context.Properties["originPlace"].ToString();
            //placeDestination = _context.Properties["destinyPlace"].ToString();
        }

        [TestMethod]
        public void RoundTripPurchase()
        {
            driver = new ChromeDriver();
            Generics generic = new Generics(url, driver);
            
            generic.AcceptCookies(genericTimeout);
            generic.ChooseTrip(Generics.Trip.ROUNDTRIP, genericTimeout);
            generic.ChoosePlace(Generics.Place.ORIGIN, placeOrigin, genericTimeout);
            generic.ChoosePlace(Generics.Place.DESTINATION, placeDestination, genericTimeout);

            generic.ChooseNumberOfAdults(1, genericTimeout);

            generic.ChooseDate(Generics.Place.ORIGIN, originDate, generic.DEFAULT_TIMEOUT);
            generic.ChooseDate(Generics.Place.DESTINATION, destinationDate, generic.DEFAULT_TIMEOUT);
            
            generic.SearchFlies(genericTimeout);

            //var orig_FliesList = generic.GetFliesList(Generics.Place.ORIGIN, genericTimeout);
            generic.SelectFly(Generics.Place.ORIGIN, genericTimeout);

            //var dest_FliesList = generic.GetFliesList(Generics.Place.DESTINATION, genericTimeout);
            generic.SelectFly(Generics.Place.DESTINATION, genericTimeout);

            // var origin_json = GenerateFlyJSON(orig_FliesList);
            // var destiny_json = GenerateFlyJSON(dest_FliesList);

            generic.SelectFare(Generics.Plan.BASIC, genericTimeout);
            generic.TypeName("Pedro", genericTimeout);
            generic.TypeSurname("Duque", genericTimeout);

// ---------------------------------------------------------------------------
            //Assert.IsTrue(1==1);
        }

        [TestCleanup]
        [DoNotParallelize]
        public void TearDown()
        {
            //driver.Close();
            //driver.Quit(); 
        }
    }
}
