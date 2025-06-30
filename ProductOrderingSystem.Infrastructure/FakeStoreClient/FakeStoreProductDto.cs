using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductOrderingSystem.Infrastructure.FakeStoreClient;

public class FakeStoreProductDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }

}
