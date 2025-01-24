using EcommerceAPI.Application.Interfaces.RedisCache;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Infrastructure.RedisCache
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly ConnectionMultiplexer _connectionMultiplexerRedis;
        private readonly IDatabase _database;
        private readonly RedisCacheSettings _settings;

        public RedisCacheService(IOptions<RedisCacheSettings> options)
        {

            _settings = options.Value;
            ConfigurationOptions opt = ConfigurationOptions.Parse(_settings.ConnectionString);
            _connectionMultiplexerRedis =ConnectionMultiplexer.Connect(opt);
            _database = _connectionMultiplexerRedis.GetDatabase();
        }

        public async Task<T> GetAsync<T>(string key)
        {
            RedisValue value = await _database.StringGetAsync(key);
            if (value.HasValue) return JsonConvert.DeserializeObject<T>(value);

            return default;
        }

        public async Task SetAsync<T>(string key, T value, DateTime? exp = null)
        {
            TimeSpan unitExpiration = exp.Value - DateTime.Now;

            await _database.StringSetAsync(key, JsonConvert.SerializeObject(value), unitExpiration);
        }
    }
}
