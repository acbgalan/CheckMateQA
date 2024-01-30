using CheckMateQA.DataAccess.Data;
using CheckMateQA.DataAccess.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using CheckMateQA.Models;

namespace CheckMateQA.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IActionResult> Index()
        {
            var companies = await _companyRepository.GetAllAsync();

            return View(companies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company)
        {
            if (!ModelState.IsValid)
            {
                return View(company);
            }

            await _companyRepository.AddAsync(company);
            int saveResult = await _companyRepository.SaveASync();

            if (saveResult > 0)
            {
                TempData["success"] = "Empresa creado con exito";
            }
            else
            {
                TempData["error"] = "Error al crear nueva empresa";
            }

            return RedirectToAction("Index", "Company");
        }


    }
}
