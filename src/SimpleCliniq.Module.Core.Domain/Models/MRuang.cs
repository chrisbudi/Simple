﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SimpleCliniq.Module.Core.Domain.Models;

public partial class MRuang
{
    public long IdRuang { get; set; }

    public string KodeRuangan { get; set; }

    public string Nama { get; set; }

    public string NoRuang { get; set; }

    public char Kelompok { get; set; }

    public string Kamar { get; set; }

    public string KodeInventory { get; set; }

    public long? KodeInventoryGudangObat { get; set; }

    public string KodeRequestObat { get; set; }

    public long? KodeRequestGudangObat { get; set; }

    public string KodeTarif { get; set; }

    public bool? IsAktif { get; set; }

    public bool? IsTarif { get; set; }

    public string GdgPaket { get; set; }

    public string GdgRetur { get; set; }

    public string GdgPenerimaan { get; set; }

    public string KdInhealth { get; set; }

    public string LynInhealth { get; set; }

    public virtual MGudang KodeInventoryGudangObatNavigation { get; set; }

    public virtual MGudang KodeRequestGudangObatNavigation { get; set; }

    public virtual ICollection<MJadwalDokter> MJadwalDokter { get; set; } = new List<MJadwalDokter>();

    public virtual ICollection<MMap> MMap { get; set; } = new List<MMap>();

    public virtual ICollection<MUser> MUser { get; set; } = new List<MUser>();
}