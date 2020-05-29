namespace Domain.Core.Services
{
    public interface ICache<T>
    {
        void Set(string key, T cacheValue);

        void Set(string key, T cacheValue, System.DateTime expires);

        void Remove(string key);

        void RemovePrefix(string prefixKey);

        T Get(string key);

        bool Exists(string key);

        int GetSlidingExpiration();

        int GetAbsoluteExpiration();

    }
}
