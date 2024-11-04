using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductInfo
{
    class Category
    {
       public string? Name { get; set; }

        public List<Product> products = new List<Product>();

    }
}
