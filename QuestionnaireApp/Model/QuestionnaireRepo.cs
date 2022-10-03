namespace QuestionnaireApp.Model
{
    public class QuestionnaireRepo : IQuestionnaireRepo
    {
        //Can be used later on List 
        //private readonly List<Questionnaire> _questions;

        //Just for mock 
        private readonly Questionnaire _questionnaire;

        public QuestionnaireRepo()
        {
            _questionnaire = new Questionnaire();
        }

        public QuestionnaireRepo(Questionnaire questionnaire)
        {
           _questionnaire = questionnaire;
        }
        public void AddAnswer(string answer)
        {
            _questionnaire.AnswersText.Add(answer);
        }

        public void AddAnswers(string[] answers)
        {
            foreach (var item in answers)
            {
                AddAnswer(item);
            }
        }

        public void AddQuestion(string question)
        {
            _questionnaire.QuestionsText.Add(question);
        }

        public void AddQuestions(string[] questions)
        {
            foreach (var item in questions)
            {
                AddQuestion(item);
            };
        }

        public void AddTitle(string title)
        {
            _questionnaire.QuestionnaireTitle = title;
        }
        public Questionnaire GetQuestionnaire()
        {
            return _questionnaire;
        }
    }
}
