namespace QuestionnaireApp.Model
{
    public interface IQuestionnaireRepo
    {
        void AddQuestion(string question);
        void AddAnswer(string answer);
        void AddQuestions(string[] questions);
        void AddAnswers(string[] answers);
        void AddTitle(string title);
        Questionnaire GetQuestionnaire();

        //Can be used later 
        //IEnumerable<Questionnaire> GetQuestions();
    }
}
