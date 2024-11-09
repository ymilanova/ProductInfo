using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductInfo
{
    public class Category
    {
        public string? CategoryName { get; set; }
        public List<Product>? Products { get; set; }
    }
}
