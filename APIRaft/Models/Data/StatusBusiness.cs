// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace APIRaft.Data
{
    public partial class StatusBusiness
    {
        public StatusBusiness()
        {
            Business = new HashSet<Business>();
        }

        public int StatusBId { get; set; }
        public string StatusBName { get; set; }

        public virtual ICollection<Business> Business { get; set; }
    }
}