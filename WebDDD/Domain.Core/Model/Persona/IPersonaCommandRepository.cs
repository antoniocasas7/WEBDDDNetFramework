using System.Threading.Tasks;

namespace Domain.Core.Model.Persona
{
    public interface IPersonaCommnadRepository
    {
        Task<bool> Insert(Persona persona);

        Task<bool> Update(Persona persona);

        Task<bool> Delete(Persona persona);
    }
}
