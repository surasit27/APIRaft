// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace APIRaft.Data
{
    public partial class Promotion
    {
        public Promotion()
        {
            Order = new HashSet<Order>();
        }

        public string PromotionId { get; set; }
        public string PromotionName { get; set; }
        public string PromotionImage { get; set; }
        public string PromotionDetails { get; set; }
        public int? PromotionDiscoun { get; set; }
        public DateTime? PromotionStartdate { get; set; }
        public DateTime? PromotionLastdate { get; set; }
        public int? PromotionStatusId { get; set; }
        public string ProBusinessId { get; set; }

        public virtual Business ProBusiness { get; set; }
        public virtual StatusPromotion PromotionStatus { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}