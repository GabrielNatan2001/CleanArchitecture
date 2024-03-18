using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infra.Data.Repositories
{
    public class ProductRepostory : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepostory(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            //return await _context.Products.FindAsync(id);
            return await _context.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        //public async Task<Product> GetProductCategoryAsync(int? id)
        //{
        //    //eagler loading
        //    return await _context.Products
        //        .Include(x => x.Category)
        //        .FirstOrDefaultAsync(x=> x.Id == id);
        //}

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
