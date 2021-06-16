using System.Threading.Tasks;
using ProEventos.Damain;
namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersistence
    {
        // Palestrantes

        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool inclueEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool inclueEventos);
         Task<Palestrante> GetPalestranteByAsync(int palestranteId , bool inclueEventos);
    }
}