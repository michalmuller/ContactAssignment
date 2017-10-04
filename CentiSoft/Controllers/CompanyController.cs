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
        // GET: List of Companies
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

        // GET: Single Company
        public ActionResult Show(int id)
        {
            CompanyRepository companyRepository = new CompanyRepository();
            Company company = companyRepository.LoadCompany(id);

            CompanyVM model = new CompanyVM();
            model.Id = company.Id;
            model.Name = company.Name;
            model.Description = company.Description;
            model.PhoneNumber = company.PhoneNumber;

            return View(model);

        }
    }
}