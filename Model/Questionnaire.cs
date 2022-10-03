namespace QuestionnaireApp.Model
{
    public class Questionnaire
    {
        public Questionnaire()
        {
            QuestionnaireTitle = string.Empty;
            AnswersText = new List<string>();
            QuestionsText = new List<string>();
        }
        // Can be used later
        //public int Id { get; set; }
        public string QuestionnaireTitle { get; set; }
        public List<string> QuestionsText { get; set; }
        public List<string> AnswersText { get; set; }
    }
}
