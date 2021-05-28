using ShoppingUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingUI.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);
    }
}
