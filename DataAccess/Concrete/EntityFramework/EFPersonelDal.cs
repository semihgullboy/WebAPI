using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFPersonelDal : IPersonelDal
    {
        private readonly ApplicationContext _context;

        public EFPersonelDal(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Personel entity)
        {
            await _context.Personels.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Personel entity)
        {
            _context.Personels.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Personel>> GetAllAsync()
        {
            return await _context.Personels.ToListAsync();
        }

        public async Task<Personel> GetByIdAsync(int id)
        {
            return await _context.Personels.FindAsync(id);
        }

        public async Task UpdateAsync(Personel entity)
        {
            _context.Personels.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
