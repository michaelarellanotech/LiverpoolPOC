using Microsoft.EntityFrameworkCore;
using MOQdigital.LHAntenatal.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOQdigital.LHAntenatal.DataLayer
{
    public class SurveyRepository: ISurveyRepository
    {
        private readonly LiverpoolContext context;

        public SurveyRepository(LiverpoolContext ctx) 
        {
            context = ctx;
        }

        public async Task<List<VW_GroupQuestion>> GetQuestionGroup(int questionGroupId, int languageId) 
        {
            return await context.VW_GroupQuestion
                            .Where(x => x.QuestionGroupId == questionGroupId
                                && x.LanguageId == languageId)
                            .Select(x => x).ToListAsync();
        }
    }

    public interface ISurveyRepository
    {
        Task<List<VW_GroupQuestion>> GetQuestionGroup(int questionGroupId, int languageId);
    }
}
