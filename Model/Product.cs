using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOBasics.Model
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public float Rating { get; set; }

        public override string ToString()
        {
            return $"ID::{ProductId}\t Name::{ProductName}\t Price::{Price}\t CategoryId::{CategoryId}\t Rating::{Rating}";
        }
    }
}
