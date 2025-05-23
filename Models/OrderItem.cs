﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class OrderItem
    {
        [Key]
        public int ID { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int MovieID { get; set; }
        [ForeignKey("MovieID")]
        public Movie Movie { get; set; }

        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public Order Order { get; set; }
    }
}
