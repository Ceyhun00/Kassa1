using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KassaOne.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.VisualBasic.CompilerServices;

namespace KassaOne.Controllers
{
    public class KassaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }

        public ShowModel ParseModel(CreditViewModel creditModel)
        {
            ShowModel showModel = new ShowModel();
            var a = CalculateShowModel(creditModel);
            showModel.PurchasePrice = creditModel.CreditSum.ToString("N2");
            showModel.CreditTime = creditModel.CreditTime.ToString();
            showModel.MonthlyPayment = a.ToString("N2");
            showModel.CreditSum = (creditModel.CreditTime * a).ToString("N2");
            showModel.TotalOverpayment = ((creditModel.CreditTime * a) - double.Parse(showModel.PurchasePrice)).ToString("N2");
            return showModel;
        }
        public double CalculateShowModel(CreditViewModel creditModel)
        {

            double s = creditModel.CreditSum;
            double i = (creditModel.RatePerYear / 12) / 100;
            double n = creditModel.CreditTime;
            double k = (i * Math.Pow((1 + i), n)) / (Math.Pow((1 + i), n) - 1);
            double a = k * s;
            return a;
        }

        [HttpPost]
        public IActionResult Index(CreditViewModel creditModel)
        {
            creditModel.CreditTime *= creditModel.OptionValue;
            var showModel = ParseModel(creditModel);
            var showTable = PaymentScheduleAnnuitet(creditModel.CreditSum,
                creditModel.RatePerYear,
                creditModel.CreditTime,
                double.Parse(showModel.MonthlyPayment));
            var obj = new ResultViewModel (showModel,showTable );
            return View("Index2",obj);
        }

        protected List<ShowTable> PaymentScheduleAnnuitet(double creditSum, double ratePerYear, double creditTime, double payment) // Метод расчета Аннуитетного платежа
        {
            var interestRateMonth = ratePerYear / 12;
            var tableLst = new List<ShowTable>();
            for (int i = 0; i < creditTime; ++i)
            {
                var percentage = creditSum * (ratePerYear / 100) / 12;
                var monthNum = i + 1; //номер платежа 
                if (monthNum == 1)
                {
                    tableLst.Add(new ShowTable(monthNum, payment.ToString("N2"),
                        payment.ToString("N2"),
                        percentage.ToString("N2"),
                        creditSum.ToString("N2")));
                    continue;
                }
                creditSum -= payment - percentage;
                var monthlyPayment = payment.ToString("N2"); //Ежемесячный платеж
                var payMain = (payment - percentage).ToString("N2"); //Платеж за основной долг
                var payPercent = percentage.ToString("N2"); //Платеж процента
                var remainingSum = creditSum.ToString("N2"); //Основной остаток
                tableLst.Add(new ShowTable(monthNum, monthlyPayment, payMain, payPercent, remainingSum));

            }
            return tableLst;
        }
     

    }
}
