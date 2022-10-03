using QuestionnaireApp.Controllers;
using QuestionnaireApp.Model.BlockApproch;

namespace QuestionnaireAppTest
{
    public class QuestionnaireBlockTest
    {
        private Mock<IQuestionnaireBlockRepo> questionnaireBlockRepo;
        private QuestionnaireBlockController questionnaireBlockController;

        [SetUp]
        public void Setup()
        {
            questionnaireBlockRepo = new Mock<IQuestionnaireBlockRepo>();
            questionnaireBlockRepo.Setup(repo => repo.GetAllQuestions()).Returns(MockQuestions.QuestionBlocks());
            questionnaireBlockController = new QuestionnaireBlockController(questionnaireBlockRepo.Object);
        }

        [Test]
        public void GetAllQuestions()
        {
            var result = questionnaireBlockController.GetAllQuestions();
            Assert.That(result, Is.Not.Null);
            var values = (result.Result as ObjectResult)?.Value as List<QuestionBlock>;
            Assert.Multiple(() =>
            {
                Assert.That(values?[0].QuestionCategory, Is.EqualTo(MockQuestions.questionCategory), "Mismatch Question category");
                Assert.That(values?.Count, Is.GreaterThan(0), "Mismatch Question count");
                Assert.That(values?.Count, Is.EqualTo(4), "Mismatch Question count, Items should be 4");
            });
        }

    }
}
