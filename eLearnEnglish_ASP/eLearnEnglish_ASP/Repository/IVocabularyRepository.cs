using eLearnEnglish_ASP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eLearnEnglish_ASP.Repository
{
    public interface IVocabularyRepository
    {
        Task<List<VocabularyModel>> GetAllWords(int id);
    }
}