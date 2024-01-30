using CheckMateQA.DataAccess.Data;
using CheckMateQA.DataAccess.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    }
}
