﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace APIRaft.Data
{
    public partial class StatusPromotion
    {
        public StatusPromotion()
        {
            Promotion = new HashSet<Promotion>();
        }

        public int SpromotionId { get; set; }
        public string SpromotionName { get; set; }

        public virtual ICollection<Promotion> Promotion { get; set; }
    }
}