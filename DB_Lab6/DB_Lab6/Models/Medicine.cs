using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy_Project.Models;

public partial class Medicine
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ShortDescription { get; set; } = null!;

    public string ActiveSubstance { get; set; } = null!;

    public int ProducerId { get; set; }

    public string UnitMeasurement { get; set; } = null!;

    public int Count { get; set; }

    public string StorageLocation { get; set; } = null!;

    
    public virtual Producer? Producer { get; set; } 
}
