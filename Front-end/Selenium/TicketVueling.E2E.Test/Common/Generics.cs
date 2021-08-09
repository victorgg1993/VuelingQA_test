using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TicketVueling.E2E.Test
{

    public class Generics
    {
        private IWebDriver webDriver;
        public readonly int COOKIE_TIMEOUT = 2; // seconds
        public readonly int DEFAULT_TIMEOUT = 4; // seconds
        public readonly int LONG_TIMEOUT = 15; // seconds

        public enum Trip
        {
            ROUNDTRIP = 0,
            ONEWAY,
        };

        public enum Place
        {
            ORIGIN = 0,
            DESTINATION,
        };

        public enum FindElement
        {
            ID = 0,
            XPATH,
        };

        public enum Plan
        {
            BASIC = 0,
            OPTIMA,
            TIMEFLEX,
        };



//   ------- Public
        public Generics(string url, IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            this.webDriver.Url = url;
        }

        public void AcceptCookies(int timeout)
        {
            string xpath = "//banner-cookies/div/div/div/button";

            WebDriverWait wait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(timeout));
            wait.Until(driver => driver.FindElement(By.XPath(xpath)));

            var button = this.webDriver.FindElement(By.XPath(xpath));

            if (button.Displayed)
            {
                button.Click();
            }
        }

        public void ChooseTrip(Trip typeTrip, int timeout)
        {
            string xpath_oneWay = "//vy-market-selector/span[1]";
            string xpath_roundTrip = "//vy-market-selector/span[2]";
            string _xpath = (typeTrip == Trip.ROUNDTRIP) ? xpath_roundTrip : xpath_oneWay;
            
            this.ClickOnButton(_xpath, timeout);
        }

        public void ChoosePlace(Place origin_destin, string placeName, int timeout)
        {
            string xpath_search = "//vy-stations/div[1]/div/span[2]/input";
            string xpath_origin = "//vy-airport-selector/span/span[1]";
            string xpath_destiny= "//vy-airport-selector/span/span[3]";
            string xpath_or_dest  = xpath_origin;
            string xpath_optionOriginPlace = "//vy-stations/div[2]/div/div[2]/div";
            string xpath_optionDestinyPlace = "//vy-stations/div[4]/div/div[2]/div/span[1]/span[2]";
            string _or_dest = (origin_destin == Place.ORIGIN) ? xpath_optionOriginPlace : xpath_optionDestinyPlace;

            if (origin_destin == Place.DESTINATION)
            {
                 xpath_or_dest = xpath_destiny;
            }

            if (origin_destin == Place.ORIGIN)
            {
                this.ClickOnButton(xpath_or_dest, timeout); // (origin - destiny) button
            }

            this.ClickOnButton(xpath_search, timeout); // search bar
            this.WriteBox(xpath_search, placeName, 450);
            
            Task.Delay(1000).Wait(); // pending to fix

            this.ClickOnButton(_or_dest, timeout); // click on Barcelona or Madrid

            Task.Delay(1000).Wait(); // pending to fix
        }

        public void ChooseDate(Place origin_destin, string date, int timeout) // ----- to-do 
        {
            string xpath_originDate = "//vy-market-date-selector/span/span[1]/span[2]";
            string xpath_destinationDate = "//vy-market-date-selector/span/span[2]/span[2]";
            
            String[] dateParts = date.Split("/");
            int dateMonth = int.Parse(dateParts[1]);
            int dateDay = int.Parse(dateParts[2]);


            var _orig_dest = (origin_destin == Place.ORIGIN) ? xpath_originDate : xpath_destinationDate;
            this.ClickOnButton(_orig_dest, timeout);
            Task.Delay(700).Wait(); // pending to fix

            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript($"document.querySelectorAll('[data-full=\"2021 - {dateMonth} - {dateDay}\"]')[0].getElementsByClassName('mbsc-cal-cell-i mbsc-cal-day-i')[0].click()");
        }

        public void ChooseNumberOfAdults(int num, int timeout)
        {
            string xpath_passengersButton = "//vy-passenger-selector/div/span[2]";
            string xpath_addPasenger = "//*[@id=\"plusadultsAmount\"]/i";
            string xpath_accept = "//*[@id=\"content\"]/div[2]/span";

            this.ClickOnButton(xpath_passengersButton, timeout); // select num of passengers 

            if(num != 1)
            {
                for(int i = 1 ; i < num ; i++)
                {
                    this.ClickOnButton(xpath_addPasenger, timeout); // + adults
                }
            }

            this.ClickOnButton(xpath_accept, timeout); // accept
        }

        public void SearchFlies(int timeout)
        {
            string xpath = "//vy-searcher/div/common-button/button";
            ClickOnButton(xpath, timeout);
        }

        public List<Fly> GetFliesList(Place origin_destin, int timeout) // ---- to-do
        {
            List<Fly> flies = new List<Fly>();
            //flies[0].price = 0;
            return flies;
        }

        public void SelectFly(Place origin_destin, int timeout) // --- to-do
        {
            // origin_destin => not needed but helps visually
            string xpath = "//stv-flight-card[1]/mat-card";
            this.ClickOnButton(xpath, timeout);
        }

        public void SelectFare(Plan plan, int timeout)
        {
            string xpath_basic = "//outline-button/div/button";
            string xpath_optima = "//common-button/button";
            //string xpath_timeFlex = "//outline-button/div/button";
            string _xpath = "";

            switch(plan)
            {
                case Plan.BASIC:
                    _xpath = xpath_basic;
                    break;
                case Plan.OPTIMA:
                    _xpath = xpath_optima;
                    break;
                //case Plan.TIMEFLEX:
                //    _xpath = xpath_timeFlex;
                //break;
            }

            this.ClickOnButton(_xpath, timeout);
        }

        public void TypeName(string name, int timeout)
        {
            string xpath_name = "//*[@id=\"mat-input-22\"]";
            this.ClickOnButton(xpath_name, timeout);
            this.WriteBox(xpath_name, name, timeout);
        }

        public void TypeSurname(string name, int timeout)
        {
            string xpath_name = "//*[@id=\"mat-input-21\"]";
            this.ClickOnButton(xpath_name, timeout);
            this.WriteBox(xpath_name, name, timeout);
        }

        //   ------- Private
        private void ClickOnButton(string xpath, int timeout)
        {
            new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(timeout))
            .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
            .ElementToBeClickable(By.XPath(xpath)));

            this.webDriver.FindElement(By.XPath(xpath)).Click();
        }

        private void WriteBox(string xpath, string place, int timeout)
        {
            this.webDriver.FindElement(By.XPath(xpath)).SendKeys(place);

            //Thread.Sleep(timeout); // pending to fix
            //Task.Delay(timeout).Wait();
            //this.webDriver.FindElement(By.XPath(xpath)).SendKeys(Keys.Tab);
        }
    }
}

