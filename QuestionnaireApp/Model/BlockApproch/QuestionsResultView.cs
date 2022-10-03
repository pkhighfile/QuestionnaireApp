namespace QuestionnaireApp.Model.BlockApproch
{
    public class QuestionsResultView
    {
        public QuestionsResultView(string title)
        {
            questionnaireTitle = title;
            questionsText = new List<string>();
        }
        public string questionnaireTitle { get; set; }
        public List<string> questionsText { get; set; }

    }
}
