using CheckMateQA.DataAccess.Data;
using CheckMateQA.DataAccess.Repository.Interfaces;
using CheckMateQA.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMateQA.DataAccess.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationContext _context;

        public CompanyRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Company entity)
        {
            await _context.Companies.AddAsync(entity);
        }

        public async Task<Company> GetAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task UpdateAsync(Company entity)
        {
            await Task.Run(() =>
            {
                _context.Companies.Update(entity);
            });
        }

        public async Task DeleteAsync(int id)
        {
            Company company = await GetAsync(id);

            if(company != null)
            {
                _context.Companies.Remove(company);
            }
        }

        public async Task DeleteAsync(Company entity)
        {
            await Task.Run(() =>
            {
                _context.Companies.Remove(entity);
            });
        }

        public async Task<bool> ExitsAsync(int id)
        {
            return await _context.Companies.AnyAsync(x => x.Id == id);
        }

        public async Task<int> SaveASync()
        {
            return await _context.SaveChangesAsync();                    
        }

    }
}
