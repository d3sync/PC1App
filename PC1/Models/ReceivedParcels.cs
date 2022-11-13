using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PC1.Models;

[Table("ReceivedParcels")]
public class ReceivedParcels
{
    [Key] public Guid id { get; set; } = new();
    public string? ParcelBarcode { get; set; }
    public string? InvBarcode { get; set; }
    public string? VoucherBarcode { get; set; }
    public string Name { get; set; }
    public string? Address { get; set; }
    public string Price { get; set; } = "0";
    public string? Phone { get; set; }
    public string? Phone2 { get; set; }
    public string? Comments { get; set; }
    public string ArrivalDate { get; set; } = DateTime.Now.ToString("dd/MM/yy");
    public int? IsCompleted { get; set; } = 0;
}