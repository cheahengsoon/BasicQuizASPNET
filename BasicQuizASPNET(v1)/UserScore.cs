using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicQuizASPNET_v1_
{
    public class UserScore
    {
        public int intRowID { get; set; }
        public int intUserID { get; set; }
        public int intQuestionID { get; set; }
        public string strQuestionDescription { get; set; }
        public int intUserAnswerID { get; set; }
        public string strUserAnswerDescription { get; set; }
        public int intCorrectAnswerID { get; set; }
        public string strCorrectAnswerDescription { get; set; }
        public int intUserQuestionScore { get; set; }
    }
}