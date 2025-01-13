using CodeChallenge.Data;
using CodeChallenge.Models;
using System.Threading.Tasks;

namespace CodeChallenge.Services
{
    public interface ICompensationService
    {
        Compensation Create(Compensation compensation);
        Compensation Read(string id);
    }
}
