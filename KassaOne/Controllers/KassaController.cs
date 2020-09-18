using System;
using System.Collections.Generic;
using KassaOne.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public IActionResult Index(CreditViewModel creditModel)
        {
            creditModel.CreditTime *= creditModel.OptionValue;
            var showModel = ParseToShowModel(creditModel);
            var showTable = AnnualPaymentSchedule(creditModel.CreditSum,
                creditModel.RatePerYear,
                creditModel.CreditTime,
                double.Parse(showModel.MonthlyPayment));

            var obj = new ResultViewModel (showModel,showTable );
            return View($"Index2",obj);
        }

        protected List<ShowTable> AnnualPaymentSchedule(double creditSum, double ratePerYear, double creditTime, double payment) // Метод расчета Аннуитетного платежа
        {
            var tableLst = new List<ShowTable>();
            for (int i = 0; i < creditTime; ++i)
            {
                var percentage = creditSum * (ratePerYear / 100) / 12;
                var monthNum = i+1 ; //номер платежа 
                creditSum -= payment - percentage;
                var monthlyPayment = payment.ToString("N2"); //Ежемесячный платеж
                var payMain = (payment - percentage).ToString("N2"); //Платеж за основной долг
                var payPercent = percentage.ToString("N2"); //Платеж процента
                var remainingAmount = creditSum.ToString("N2"); //Основной остаток
                tableLst.Add(new ShowTable(monthNum, monthlyPayment, payMain, payPercent, remainingAmount));
            }
            return tableLst;
        }
        public ShowModel ParseToShowModel(CreditViewModel creditModel)
        {
            var showModel = new ShowModel();
            var annuityCoefficient = CalculateAnnuity(creditModel);
            showModel.PurchasePrice = creditModel.CreditSum.ToString("N2");
            showModel.CreditTime = creditModel.CreditTime.ToString();
            showModel.MonthlyPayment = annuityCoefficient.ToString("N2");
            showModel.CreditSum = (creditModel.CreditTime * annuityCoefficient).ToString("N2");
            showModel.TotalOverpayment = ((creditModel.CreditTime * annuityCoefficient) - double.Parse(showModel.PurchasePrice)).ToString("N2");
            return showModel;
        }
        public double CalculateAnnuity(CreditViewModel creditModel)
        {
            double monthlyRate = (creditModel.RatePerYear / 12) / 100;
            double periodNum = creditModel.CreditTime;
            double annuityCoefficient = (monthlyRate * Math.Pow((1 + monthlyRate), periodNum)) / (Math.Pow((1 + monthlyRate), periodNum) - 1);
            double monthlyAnnuityPayment = annuityCoefficient * creditModel.CreditSum;
            return monthlyAnnuityPayment;
        }

    }
}
