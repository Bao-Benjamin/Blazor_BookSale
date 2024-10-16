using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorBookSale.Models;

public partial class Booksale
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? SaleId { get; set; }
    [StringLength(50)]
    public string? Title { get; set; }

    public int? Quantity { get; set; }

    public double? Price { get; set; }
}
