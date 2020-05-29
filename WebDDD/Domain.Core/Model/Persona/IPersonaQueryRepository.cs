using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Core.Model.Persona
{
    public interface IPersonaQueryRepository
    {
        Task<Persona> GetById(int id);

        Task<IEnumerable<Persona>> GetAll();

        Task<IEnumerable<Persona>> GetBySearchText(string text);
    }
}
