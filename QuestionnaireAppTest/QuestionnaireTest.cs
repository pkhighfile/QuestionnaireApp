using QuestionnaireApp.Controllers;
using QuestionnaireApp.Model;

namespace QuestionnaireAppTest
{
    public class QuestionnaireTest
    {
        private Mock<IQuestionnaireRepo> questionnaireRepo;
        private QuestionnaireController questionnaireController;

        [SetUp]
        public void Setup()
        {
            questionnaireRepo = new Mock<IQuestionnaireRepo>();
            questionnaireRepo.Setup(repo => repo.GetQuestionnaire())
                .Returns(MockQuestions.Questionnaire());
            questionnaireController = new QuestionnaireController(questionnaireRepo.Object);
        }

        [Test]
        public void GetQuestions()
        {
            var result = questionnaireController.GetQuestionnaire();           
            Assert.That(result, Is.Not.Null);
            var values = (result.Result as ObjectResult)?.Value as Questionnaire;
            Assert.Multiple(() =>
            {
                Assert.That(values?.QuestionnaireTitle, Is.EqualTo(MockQuestions.questionCategory), "Mismatch Question category");
                Assert.That(values?.QuestionsText.Count, Is.GreaterThan(0), "Mismatch Question count");
                Assert.That(values?.QuestionsText.Count, Is.EqualTo(4), "Mismatch Question count, Items should be 4");
            });
        }
    }
}