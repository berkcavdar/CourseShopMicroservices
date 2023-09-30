using Course.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Course.Services.Order.Domain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public DateTime CreatedDate { get; private set; }
        public Address Address { get; private set; }
        public string BuyerId { get; private set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems { get { return _orderItems; } }

        public Order()
        {
            
        }

        public Order(Address adress, string buyerId)
        {
            CreatedDate = DateTime.Now;
            _orderItems = new List<OrderItem>();
            BuyerId = buyerId;
            Address = adress;
        }

        public void AddOrderItem(string productId, string productName,string productUrl, decimal price)
        {
            var existProduct = _orderItems.Any(x => x.ProductId == productId);
            if(!existProduct)
            {
                var newOrderItem = new OrderItem(productId, productName, productUrl, price);
                _orderItems.Add(newOrderItem);
            }
        }

        public decimal GetTotalPrice => _orderItems.Sum(x => x.Price);
    }
}
