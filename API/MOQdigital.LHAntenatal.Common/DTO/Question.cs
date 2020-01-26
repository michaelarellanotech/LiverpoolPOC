using System;
using System.Collections.Generic;
using System.Text;

namespace MOQdigital.LHAntenatal.Common.DTO
{
    public class QuestionGroupModel
    {
        public string GroupDescription { get; set; }
        public List<QuestionModel> Questions { get; set; }
    }

    public class QuestionModel
    {
        public string QuestionCode { get; set; }
        public string QuestionText { get; set; }
        public bool RTL { get; set; }
    }
}
