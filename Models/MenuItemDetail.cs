using System;
using System.Collections.Generic;

namespace BrewBlissInfo.Models;

public partial class MenuItemDetail
{
    public int Id { get; set; }
    public string NameItem { get; set; } = null!;
    public string? Ingredients { get; set; }
    public int? Calories { get; set; }
    public bool? Vegan { get; set; }
}
