using System.Data;

namespace Infrastructure.Persistence.SQL
{
    public interface IConnectionFactory
    {
        /// <summary>
        ///     Create <see cref="IDbConnection" />
        /// </summary>
        IDbConnection Create();
    }
}
