using CoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _context;

        public ProductRepository(AppDBContext context)
        {
            _context = context;
        }

        public Product Add([FromBody] Product product)
        {
            _context.Database.ExecuteSqlRaw ("spInsert {0},{1},{2}", 
                                product.PCode, 
                                product.Description, 
                                product.Category);
            return product;
        }

        public void Delete(int id)
        {
            _context.Database.ExecuteSqlRaw("spDelete {0}", id);           
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products
                            .FromSqlRaw<Product>("SELECT * FROM Products")
                            .ToList();
        }

        public Product GetById(int id)
        {
            SqlParameter parameter = new SqlParameter("@Id", id);
            return _context.Products
                            .FromSqlRaw<Product>("spGetById @Id", parameter)
                            .ToList()
                            .FirstOrDefault();
        }

        public Product Update([FromBody]Product productChanges)
        {
            _context.Database.ExecuteSqlRaw("spUpdate {0},{1},{2},{3}",
                                    productChanges.PCode,
                                    productChanges.Description,
                                    productChanges.Category,
                                    productChanges.Id);
            return productChanges;
        }
    }
}
