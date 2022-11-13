﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PC1.Models;

[Table("Delivered")]
public class DeliveredModel
{
    //parcelno,general_numeration,procDate,name,price,dc_type,regDate
    public int id { get; set; }
    public string parcelno { get; set; }
    public string general_numeration { get; set; }
    public string procDate { get; set; }
    public string name { get; set; }
    public string price { get; set; }
    public string dc_type { get; set; }
    public string regDate { get; set; }
}