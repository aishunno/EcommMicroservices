using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers;

/// <summary>
/// Basket Controller
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class BasketController : ControllerBase
{
    private readonly IBasketRepository _basketRepository;

    /// <summary>
    /// Base constructor
    /// </summary>
    /// <param name="basketRepository">Basket Repository</param>
    public BasketController(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    /// <summary>
    /// Get Basket by Username
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    [HttpGet("{username}")]
    [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCart>> GetBasket(string username)
    {
        var shoppingCart = await _basketRepository.GetBasketAsync(username);
        return Ok(shoppingCart ?? new ShoppingCart(username));
    }
    
    /// <summary>
    /// Update basket
    /// </summary>
    /// <param name="shoppingCart"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCart>> UpdateBasket(ShoppingCart shoppingCart)
    {
        var updatedCart = await _basketRepository.UpdateBasketAsync(shoppingCart);
        return Ok(updatedCart);
    }

    /// <summary>
    /// Delete Basket
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    [HttpDelete("{username}")]
    [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> DeleteBasket(string username)
    {
        await _basketRepository.DeleteBasketAsync(username);
        return Ok();
    }
}
