using CentiSoft.DAL;
using CentiSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentiSoft.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            CompanyRepository companyRepository = new CompanyRepository();
            List<Company> companies = companyRepository.LoadAllCompanies();
            List<CompanyVM> companyVMs = new List<CompanyVM>();
            foreach (Company c in companies)
            {
                CompanyVM companyVM = new CompanyVM();
                companyVM.Id = c.Id;
                companyVM.Name = c.Name;
                companyVM.Description = c.Description;
                companyVM.PhoneNumber = c.PhoneNumber;
                companyVMs.Add(companyVM);
            }
            CompanyVM model = new CompanyVM();
            model.companies = companyVMs;
            return View(model);
        }
    }
}