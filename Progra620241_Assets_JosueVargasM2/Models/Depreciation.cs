﻿using System;
using System.Collections.Generic;

namespace Progra620241_Assets_JosueVargasM2.Models;

public partial class Depreciation
{
    public int DepreciationId { get; set; }

    public string DepreciationName { get; set; } = null!;

    public bool? ByYear { get; set; }

    public bool? ByMonth { get; set; }

    public decimal Percentage { get; set; }

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
}
