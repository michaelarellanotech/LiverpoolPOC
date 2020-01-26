using MOQdigital.LHAntenatal.Common.DTO;
using MOQdigital.LHAntenatal.Common.Extensions;
using MOQdigital.LHAntenatal.DataLayer;
using MOQdigital.LHAntenatal.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeofencePOC.Services
{
    public class SurveyService : ISurveyService
    {
        private ISurveyRepository _surveyRepository;

        public SurveyService(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public async Task<QuestionGroupModel> GetQuestionGroup(int questionGroupI, int languageId)
        {
            return (await _surveyRepository.GetQuestionGroup(questionGroupI, languageId)).ToDTO();
        }

    }

   

    

}
