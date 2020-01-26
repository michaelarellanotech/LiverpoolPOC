using MOQdigital.LHAntenatal.Common.DTO;
using MOQdigital.LHAntenatal.DataLayer.Model;
using System.Collections.Generic;
using System.Linq;

namespace MOQdigital.LHAntenatal.Common.Extensions
{
    public static class QuestionGroupExtension
    {
        public static QuestionGroupModel ToDTO(this List<VW_GroupQuestion> source)
        {
            return source == null ? null
                : new QuestionGroupModel()
                {
                    GroupDescription = source.First().GroupDescription,
                    Questions = source.Select(x => new QuestionModel
                    {
                        QuestionCode = x.QuestionCode,
                        QuestionText = x.QuestionText,
                        RTL = x.RTL

                    }).ToList()
                };
        }
    }
}
