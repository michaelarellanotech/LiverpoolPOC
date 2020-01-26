using MOQdigital.LHAntenatal.Common.DTO;
using System.Threading.Tasks;

namespace GeofencePOC.Services
{
    public interface ISurveyService
    {
        Task<QuestionGroupModel> GetQuestionGroup(int questionGroupI, int languageId);
    }
}