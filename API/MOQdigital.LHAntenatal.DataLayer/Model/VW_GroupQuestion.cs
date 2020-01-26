using System;
using System.Collections.Generic;
using System.Text;

namespace MOQdigital.LHAntenatal.DataLayer.Model
{
    public class VW_GroupQuestion
    {
        public int QuestionGroupId { get; set; }
        public string GroupDescription { get; set; }
        public string QuestionCode { get; set; }
        public int LanguageId { get; set; }
        public string QuestionText { get; set; }
        public bool RTL { get; set; }

    }
}
