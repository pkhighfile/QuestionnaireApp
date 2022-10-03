namespace QuestionnaireApp.Model.BlockApproch
{
    public class QuestionnaireBlock
    {
        //Different Approch can be used later
        public string? QuestionnaireTitle { get; private set; }
        public List<QuestionBlock>? Questions { get; set; }

        public QuestionnaireBlock(string? questionnaireTitle)
        {
            QuestionnaireTitle = questionnaireTitle;
        }
    }
}
