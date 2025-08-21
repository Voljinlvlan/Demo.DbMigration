using System;
using System.Collections.Generic;

namespace Demo.DbMigration.Models.DatabaseA;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual User User { get; set; } = null!;
}
