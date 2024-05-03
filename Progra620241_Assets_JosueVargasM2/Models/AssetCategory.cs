using System;
using System.Collections.Generic;

namespace Progra620241_Assets_JosueVargasM2.Models;

public partial class AssetCategory
{
    public int AssetCategoryId { get; set; }

    public string AssetCategoryDescription { get; set; } = null!;

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
}
