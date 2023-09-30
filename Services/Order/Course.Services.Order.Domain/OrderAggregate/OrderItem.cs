using Course.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Services.Order.Domain.OrderAggregate
{
    public class OrderItem : Entity
    {
        public string ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string ProductUrl { get; private set; }
        public decimal Price { get; private set; }

        public OrderItem()
        {

        }

        public OrderItem(string productId, string productName, string productUrl, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            ProductUrl = productUrl;
            Price = price;
        }

        public void UpdateOrderItem(string productName, string pictureUrl, decimal price)
        {
            ProductName = productName;
            ProductUrl = pictureUrl;
            Price = price;
        }
    }
}
