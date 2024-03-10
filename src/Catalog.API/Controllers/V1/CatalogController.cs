using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers.V1;

/// <summary>
/// Catalog controller
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class CatalogController : ControllerBase
{
    private readonly IProductRepository _repository;
    private readonly ILogger<CatalogController> _logger;

    /// <summary>
    /// Base constructor
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="logger"></param>
    public CatalogController(IProductRepository repository, ILogger<CatalogController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <summary>
    /// Gets the list of all products.
    /// </summary>
    /// <returns>Returns a list of products.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _repository.GetProductsAsync();
        return Ok(products);
    }
}
