﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SimpleCliniq.Module.Core.Domain.Models;

public partial class MTarifnonmedisGroup
{
    public int IdGroupNonMedis { get; set; }

    public string Nmgroupnonmedis { get; set; }

    public string Kdakun { get; set; }

    public virtual ICollection<MTarifNonMedis> MTarifNonMedis { get; set; } = new List<MTarifNonMedis>();
}