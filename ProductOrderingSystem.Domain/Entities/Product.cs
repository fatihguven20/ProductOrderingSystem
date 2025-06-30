using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOrderingSystem.Domain.Entities;

public class Product
{
    public string ProductCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Stock { get; set; } 
    public int Threshold { get; set; } // Kritik stok eşiği
    public decimal Price { get; set; }
}
