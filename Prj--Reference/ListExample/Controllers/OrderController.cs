using ListExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Linq;
using ListExample.Models.ViewModels;

namespace ListExample.Controllers
{
    public class OrderController : Controller
    {

        private readonly OrdersContext _context;

        public OrderController(OrdersContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(
      string sortOrder,
      string currentFilterCustomer,
      string currentFilterNumber,
      string searchStringCustomer,
      string searchStringNumber,
      int? goToPageNumber,
      int pageSize,
      int? pageNumber)
        {
            // 1.搜尋邏輯
            var query = from a in _context.Orders
                        join b in _context.Customers on a.CustomerNumber equals b.Number
                        into result1
                        from ab in result1.DefaultIfEmpty()
                        select new OrderIndexViewModel
                        {
                            Number = a.Number,
                            ShippingAddress = a.ShippingAddress,
                            ShippingDate = a.ShippingDate,
                            CustomerSignature = a.CustomerSignature,
                            Total = a.Total,
                            CustomerNumber = a.CustomerNumber,
                            CustomerName = ab.Name,
                            CustomerTel = ab.Tel
                        };

            // 2.條件過濾
            if (searchStringCustomer != null || searchStringNumber != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchStringCustomer = currentFilterCustomer;
                searchStringNumber = currentFilterNumber;
            }

            ViewData["CurrentFilterCustomer"] = searchStringCustomer;
            ViewData["CurrentFilterNumber"] = searchStringNumber;

            if (!String.IsNullOrEmpty(searchStringCustomer))
            {
                query = query.Where(s => s.CustomerName.Contains(searchStringCustomer));
            }
            if (!String.IsNullOrEmpty(searchStringNumber))
            {
                query = query.Where(s => s.Number.Contains(searchStringNumber));
            }

            // 3.排序依據
            ViewData["CurrentSort"] = sortOrder;

            switch (sortOrder)
            {
                case "1":
                    query = query.OrderByDescending(s => s.ShippingDate);
                    break;
                case "2":
                    query = query.OrderBy(s => s.ShippingDate);
                    break;
                case "3":
                    query = query.OrderByDescending(s => s.Total);
                    break;
                case "4":
                    query = query.OrderBy(s => s.Total);
                    break;
                default:
                    query = query.OrderByDescending(s => s.ShippingDate);
                    break;
            }

            // 4.前往頁數
            if (goToPageNumber != null)
            {
                pageNumber = goToPageNumber;
            }

            // 5.每頁筆數
            if (pageSize == 0)
            {
                pageSize = 10;
            }
            ViewData["pageSize"] = pageSize;
            
            // 6.返回結果
            return View(await PaginatedList<OrderIndexViewModel>.CreateAsync(query.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

    }
}
