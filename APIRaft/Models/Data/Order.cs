// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace APIRaft.Data
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
            OrderServices = new HashSet<OrderServices>();
        }

        public string OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? OrderLastdate { get; set; }
        public int? OrderPrice { get; set; }
        public string OrderImageDeposit { get; set; }
        public int? OrderDeposit { get; set; }
        public string OrderImagePay { get; set; }
        public int? OrderPay { get; set; }
        public int? OrderStatusId { get; set; }
        public string OrderUserId { get; set; }
        public string OrderPromotionId { get; set; }

        public virtual Promotion OrderPromotion { get; set; }
        public virtual StatusOrder OrderStatus { get; set; }
        public virtual User OrderUser { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<OrderServices> OrderServices { get; set; }
    }
}