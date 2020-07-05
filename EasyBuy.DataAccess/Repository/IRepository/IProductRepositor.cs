using EasyBuy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBuy.DataAccess.Repository.IRepository
{
    public interface IProductRepository:IRepository<Product>
    {
        void Update(Product product);
    }
}
