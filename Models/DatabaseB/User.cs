using System;
using System.Collections.Generic;

namespace Demo.DbMigration.Models.DatabaseB;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Department { get; set; }

    public DateTime? CreatedDate { get; set; }
}
