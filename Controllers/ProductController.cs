using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCCoreAngular.Data;
using MVCCoreAngular.Data.Entities;
using System;
using System.Collections.Generic;

namespace MVCCoreAngular.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IRepository repository;
        private readonly ILogger logger;

        public ProductController(IRepository repository, ILogger<ProductController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                logger.LogInformation($"Failed to Get Products: {ex}");
                return BadRequest("Failed to get products");
            }

        }

    }
}
