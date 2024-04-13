namespace GtMotive.Estimate.Microservice.Infrastructure.Services.Redis.Impl.Parent
{
    public abstract class RedisService
    {
        protected RedisService(RedisContext redisContext)
        {
            RedisContext = redisContext;
        }

        protected RedisContext RedisContext { get; }
    }
}
