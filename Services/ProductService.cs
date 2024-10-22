using backapi.Context;
using backapi.Models;
using Microsoft.EntityFrameworkCore;

namespace backapi.Services
{
    public class ProductService : InterfaceProductService
    {
        private readonly DBContext _dbContext;


        public ProductService(DBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            return await _dbContext.ObjectProduct.ToListAsync();
        }
        public async Task UpdateStock(int productId, int amount)
        {
            var product = await _dbContext.ObjectProduct.FindAsync(productId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            if (amount > 0)
            {
                product.Stock_remain -= amount;
                product.Modified_Date = DateTime.Now; // อัปเดต modified_date เป็นวันที่และเวลาปัจจุบัน
            }
            await _dbContext.SaveChangesAsync();

        }
    }
}
