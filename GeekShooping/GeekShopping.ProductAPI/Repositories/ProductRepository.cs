using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Create(ProductVO product)
        {
            var prod = _mapper.Map<Product>(product);
            _context.Add(prod);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(prod);
        }

        public async Task<ProductVO> Update(ProductVO product)
        {
            var prod = _mapper.Map<Product>(product);
            _context.Products.Update(prod);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(prod);
        }
        public async Task<bool> Delete(long id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null) return false;
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
