namespace QuestionnaireApp.Model.BlockApproch
{
    public interface IQuestionnaireBlockRepo
    {       
        void AddQuestion(QuestionBlock questionBlock);
        void UpdateQuestion(Guid questionId, string questionText);
        void DeleteQuestion(Guid questionId);
        void AddAnswer(Guid questionId, string answerText);
        void UpdateAnswer(Guid questionId, string answerText);      
        List<QuestionsResultView> GetQuestions();
        List<QuestionBlock> GetAllQuestions();
    }
}
