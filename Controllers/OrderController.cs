using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCCoreAngular.Data;
using MVCCoreAngular.Data.Entities;
using MVCCoreAngular.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCCoreAngular.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[Controller]")]
    public class OrderController : Controller
    {
        private readonly IRepository repository;
        private readonly ILogger<OrderController> logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMapper mapper;

        public OrderController(IRepository repository,
            ILogger<OrderController> logger,
            UserManager<IdentityUser> userManager,
            IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(bool includeItems = true)
        {
            try
            {
                //string userName = User.Identity.Name; // For some reason this is line does work
                //var orders = repository.GetAllOrders(includeItems);
                var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var orders = repository.GetAllOrdersByUser(userName, includeItems);


                if (orders != null) return Ok(mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(orders));
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get Orders {ex}");
                return BadRequest("Failed to get orders");
            }
        }

        [AllowAnonymous]
        [HttpGet("all")]
        public IActionResult GetAll(bool includeItems = true)
        {
            try
            {
                var orders = repository.GetAllOrders(includeItems);

                if (orders != null) return Ok(mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(orders));
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get Orders {ex}");
                return BadRequest("Failed to get orders");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var order = repository.GetOrderById(userName, id);

                if (order != null) return Ok(mapper.Map<Order, OrderViewModel>(order));
                else return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get Orders {ex}");
                return BadRequest("Failed to get orders");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = mapper.Map<OrderViewModel, Order>(model);

                    if (model.OrderDate == DateTime.MinValue)
                    {
                        model.OrderDate = DateTime.Now;
                    }

                    var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    var currentUser = await userManager.FindByNameAsync(userName);
                    newOrder.User = currentUser;

                    repository.AddOrder(newOrder);
                    if (repository.SaveChanges())
                    {
                        return Created($"/api/order/{newOrder.Id}", mapper.Map<Order, OrderViewModel>(newOrder));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get Orders {ex}");
                return BadRequest("Failed to get orders");
            }

            return BadRequest("Failed to save new Order");
        }
    }
}
