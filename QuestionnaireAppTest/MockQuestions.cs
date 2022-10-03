using QuestionnaireApp.Model;
using QuestionnaireApp.Model.BlockApproch;

namespace QuestionnaireAppTest
{
    public static class MockQuestions
    {
        public const string questionCategory = "Geography Questions";

        public static List<QuestionBlock> QuestionBlocks()
        {
            var result = new List<QuestionBlock>
            {
                new QuestionBlock
                {
                    Id = Guid.NewGuid(),
                    QuestionCategory = questionCategory,
                    QuestionText = "What is the capital of Italy?",
                    AnswerText ="ROME"
                },
                 new QuestionBlock
                {
                    Id = Guid.NewGuid(),
                    QuestionCategory = questionCategory,
                    QuestionText = "What is the capital of France?",
                    AnswerText ="Paris"
                },
                  new QuestionBlock
                {
                    Id = Guid.NewGuid(),
                    QuestionCategory = questionCategory,
                    QuestionText = "What is the capital of Uk?",
                    AnswerText ="London"
                },
                   new QuestionBlock
                {
                    Id = Guid.NewGuid(),
                    QuestionCategory = questionCategory,
                    QuestionText = "What is the capital of Germany?",
                    AnswerText ="Berlin"
                }
            };
            return result;
        }

        public static Questionnaire Questionnaire()
        {
            var result = new Questionnaire
            {
                QuestionnaireTitle = questionCategory,
                QuestionsText =
                {
                    "What is the capital of Italy?",
                    "What is the capital of France?",
                    "What is the capital of Uk?",
                    "What is the capital of Germany?"

                },
                AnswersText = { "Rome", "Paris", "London", "Berlin" }
            };

            return result;
        }


    }
}
