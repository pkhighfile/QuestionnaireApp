namespace QuestionnaireApp.Model.BlockApproch
{
    public class QuestionnaireBlockRepo : IQuestionnaireBlockRepo
    {
        private readonly List<QuestionBlock>? _blocks = new();
        public QuestionnaireBlockRepo()
        {

        }
        public void AddAnswer(Guid questionId, string answerText)
        {
            var questions = _blocks?.Find(x => x.Id == questionId);
            if (questions is QuestionBlock d)
            {
                // just for mock 
                d.AnswerText = answerText;
            }
        }

        public void AddQuestion(QuestionBlock questionBlock)
        {
            _blocks?.Add(questionBlock);
        }

        public void DeleteQuestion(Guid questionId)
        {
            var questions = _blocks?.Find(x => x.Id == questionId);
            if (questions is QuestionBlock d)
            {
                // just for mock 
                _blocks?.Remove(d);
            }
        }

        public void UpdateAnswer(Guid questionId, string answerText)
        {
            var questions = _blocks?.Find(x => x.Id == questionId);
            if (questions is QuestionBlock d)
            {
                // just for mock 
                d.AnswerText = answerText;
            }
        }

        public void UpdateQuestion(Guid questionId, string questionText)
        {
            var questions = _blocks?.Find(x => x.Id == questionId);
            if (questions is QuestionBlock d)
            {
                // just for mock 
                d.QuestionText = questionText;
            }
        }

        public List<QuestionsResultView> GetQuestions()
        {
            //For Mocking 
            var questionList = new List<QuestionsResultView>();
            var list = _blocks?.ToLookup(x => x.QuestionCategory);
            if (list?.Count > 0)
            {
                foreach (var questionItem in list)
                {
                    var questionResult = new QuestionsResultView(questionItem.Key);
                    foreach (var item in list[questionItem.Key])
                    {
                        questionResult?.questionsText.Add(item.QuestionText);
                    }

                    questionList.Add(questionResult);
                }
            }
            return questionList;
        }

        public List<QuestionBlock> GetAllQuestions()
        {
            return _blocks;
        }
    }
}
