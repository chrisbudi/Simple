﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SimpleCliniq.Module.Core.Domain.Models;

public partial class MDiagnosa
{
    public long IdDiagnosa { get; set; }

    public string KdDiagnosa { get; set; }

    public string NmDiagnosa { get; set; }

    public bool? Ispenyakit { get; set; }

    public long? IdDtd { get; set; }

    public string KdDtd { get; set; }

    public bool? IsAktif { get; set; }

    public virtual ICollection<MMorfologi> MMorfologi { get; set; } = new List<MMorfologi>();

    public virtual MDtd MDtdNavigation { get; set; }
}