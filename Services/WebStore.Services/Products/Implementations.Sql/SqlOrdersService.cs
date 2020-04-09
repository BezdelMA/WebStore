using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Implementations.Sql
{
    public class SqlOrdersService : IOrderService
    {
        readonly WebStoreContext _context;
        readonly UserManager<User> _userManager;

        public SqlOrdersService(WebStoreContext db, UserManager<User> userManager)
        {
            _context = db;
            _userManager = userManager;
        }
        public IEnumerable<Order> GetUserOrders(string UserName) => _context.Orders
           .Include(order => order.User)
           .Include(order => order.OrderItems)
           .Where(order => order.User.UserName == UserName)
           .AsEnumerable();

        public Order GetOrderById(int id) => _context.Orders
           .Include(order => order.OrderItems)
           .FirstOrDefault(order => order.Id == id);

        public Order CreateOrder(OrderViewModel OrderModel, CartViewModel Cart, string UserName)
        {
            if (UserName != null)
            {
                var user = _userManager.FindByNameAsync(UserName).Result;
            
                using (var transaction = _context.Database.BeginTransaction())
                {
                    var order = new Order
                    {
                        Address = OrderModel.Address,
                        Phone = OrderModel.Phone,
                        User = user,
                        Date = DateTime.Now
                    };

                    _context.Orders.AddAsync(order);

                    foreach (var (product_model, quantity) in Cart.Items)
                    {
                        var product = _context.Products.FirstOrDefault(p => p.Id == product_model.Id);
                        if (product is null)
                            throw new InvalidOperationException($"Товар с id:{product_model.Id} в базе данных на найден!");

                        var order_item = new OrderItem
                        {
                            Order = order,
                            Price = product.Price,
                            Quantity = quantity,
                            Product = product
                        };

                        _context.OrderItems.AddAsync(order_item);
                    }

                    _context.SaveChanges();
                    transaction.Commit();

                    return order;
                }
            }
            else throw new InvalidOperationException("Зарегистрируйтесь на сайте или войдите в личный кабинет");
        }
    }
}
