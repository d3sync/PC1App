﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC1
{
    class AssignedtoModel
    { //ParcelBarcode,InvBarcode,VoucherBarcode,Name,Address,Price,Driver,regDate
        public int id { get; set; }
        public string ParcelBarcode { get; set; }
        public string InvBarcode { get; set; }
        public string VoucherBarcode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Price { get; set; }
        public string Driver { get; set; }
        public string regDate { get; set; }
    }
}