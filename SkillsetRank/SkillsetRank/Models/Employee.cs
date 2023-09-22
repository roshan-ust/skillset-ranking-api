using System;
using System.Collections.Generic;

namespace SkillsetRank.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Uid { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Account { get; set; } = null!;

    public string ReportingManager { get; set; } = null!;

    public string Skillsets { get; set; } = null!;
}
