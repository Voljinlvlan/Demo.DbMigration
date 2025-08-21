using System;
using System.Collections.Generic;

namespace Demo.DbMigration.Models.DatabaseC;

public partial class Inventory
{
    public int Id { get; set; }

    public string ProductCode { get; set; } = null!;

    public int Quantity { get; set; }

    public DateTime? LastUpdated { get; set; }
}
