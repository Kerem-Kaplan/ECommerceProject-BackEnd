using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Application.Abstraction
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}
