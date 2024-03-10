using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Basket.API.Repositories;

public class BasketRepository : IBasketRepository
{
    private readonly IDistributedCache _distributedCache;

    public BasketRepository(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    /// <summary>
    /// Remove user basket
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public async Task DeleteBasketAsync(string username)
    {
        await _distributedCache.RemoveAsync(username);
    }

    /// <summary>
    /// Get basket by username
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public async Task<ShoppingCart?> GetBasketAsync(string username)
    {
        var basket = await _distributedCache.GetStringAsync(username);

        if (basket == null) { return null; }

        try
        {
            return JsonSerializer.Deserialize<ShoppingCart>(basket);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deserializing shopping cart for user {username}: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Update basket 
    /// </summary>
    /// <param name="cart"></param>
    /// <returns></returns>
    public async Task<ShoppingCart?> UpdateBasketAsync(ShoppingCart cart)
    {
        await _distributedCache.SetStringAsync(cart.UserName, JsonSerializer.Serialize(cart));

        return await GetBasketAsync(cart.UserName);
    }
}
