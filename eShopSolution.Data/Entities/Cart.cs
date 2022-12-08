using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Cart
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
        public int Quatity { set; get; }
        public decimal Price { set; get; }
        public Product Product { get; set; }
    }
}
