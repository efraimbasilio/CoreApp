using CoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        Product GetById(int id);

        Product Add(Product product);

        Product Delete(int id);

        Product Update(Product productChanges);
    }
}
