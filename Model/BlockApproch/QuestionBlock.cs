namespace QuestionnaireApp.Model.BlockApproch
{
    public class QuestionBlock
    {
        public Guid Id { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public string QuestionCategory { get; set; }

        //Will add more field later
        //public string? QuestionType { get; set; }
    }
}
