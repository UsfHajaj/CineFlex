﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public string UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public ApplicationUser User { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
