﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SimpleCliniq.Module.Core.Domain.Models;

public partial class MRadiologiRekanan
{
    public long IdRadrekanan { get; set; }

    public string KdPemeriksaanRad { get; set; }

    public long? IdPemeriksaanRad { get; set; }

    public long? RekananId { get; set; }

    public bool? IsAktif { get; set; }

    public virtual MRadiologi IdPemeriksaanRadNavigation { get; set; }

    public virtual MRekanan Rekanan { get; set; }
}