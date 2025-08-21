using System;
using System.Collections.Generic;

namespace Demo.DbMigration.Models.DatabaseB;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int? CategoryId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Category? Category { get; set; }
}
