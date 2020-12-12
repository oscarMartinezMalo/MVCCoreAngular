using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCCoreAngular.Data;
using MVCCoreAngular.Data.Entities;
using MVCCoreAngular.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MVCCoreAngular.Controllers
{
    [Route("api/order/{orderId}/items")]
    public class OrderItemController : Controller
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrderItemController> logger;

        public OrderItemController(IRepository repository, IMapper mapper,
            ILogger<OrderItemController> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Get(int orderId)
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var order = repository.GetOrderById(userName, orderId);

            if (order != null) return Ok(mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemViewModel>>(order.Items));
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int orderId, int id)
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var order = repository.GetOrderById(userName, orderId);

            if (order != null)
            {
                var item = order.Items.Where(i => i.Id == id).FirstOrDefault();
                if (item != null)
                {
                    return Ok(mapper.Map<OrderItem, OrderItemViewModel>(item));
                }

            }
            return NotFound();
        }
    }
}

