﻿using System;
using System.Collections.Generic;

namespace Progra620241_Assets_JosueVargasM2.Models;

public partial class UserRole
{
    public int UserRoleId { get; set; }

    public string UserRoleDescription { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
