using Microsoft.AspNetCore.Mvc;
using QuestionnaireApp.Model.BlockApproch;

namespace QuestionnaireApp.Controllers
{
    [Route("api/block/")]
    [ApiController]
    public class QuestionnaireBlockController : Controller
    {
        //Below methods are in synch mode, will add async later

        private readonly IQuestionnaireBlockRepo _questionnaireBlockRepo;
        public QuestionnaireBlockController(IQuestionnaireBlockRepo questionnaireRepo)
        {
            _questionnaireBlockRepo = questionnaireRepo;
        }

        /// <summary>
        /// Get Questions
        /// </summary>
        /// <response code="422">Validation error</response>
        [HttpGet]
        [Route("questions")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<QuestionsResultView>> GetQuestionnaire()
        {
            //database and other stuff can be added here
            return Ok(_questionnaireBlockRepo.GetQuestions());
        }

        /// <summary>
        /// Add Question
        /// </summary>
        /// <param name="questionText">Question as string</param>
        /// <param name="answerText">Answer as string</param>
        /// <param name="categoryText">Category as string</param>
        /// <returns>Status code of request</returns>
        /// <response code="422">Validation error</response>
        [HttpPost]
        [Route("AddNewQuestion")]
        [Produces("application/json")]
        //[ValidateAntiForgeryToken]
        public ActionResult AddQuestion(string questionText, string categoryText, string answerText = "")
        {
            if (string.IsNullOrEmpty(questionText) || string.IsNullOrEmpty(questionText))
            {
                return NotFound();
            }
            var question = new QuestionBlock
            {
                Id = Guid.NewGuid(),
                QuestionText = questionText,
                AnswerText = answerText,
                QuestionCategory = categoryText
            };
            _questionnaireBlockRepo.AddQuestion(question);
            return Ok();
        }

        /// <summary>
        /// Add Questions
        /// </summary>
        /// <param name="questions">Questions Array Json</param>
        /// <returns>Status code of request</returns>
        /// <response code="422">Validation error</response>
        [HttpPost]
        [Route("AddQuestions")]
        // [ValidateAntiForgeryToken]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult AddQuestions(QuestionBlock[] questions)
        {
            if (questions.Length < 1)
            {
                return NotFound();
            }
            foreach (var item in questions)
            {
                if (item.Id.Equals(""))
                {
                    item.Id = Guid.NewGuid();
                }
                _questionnaireBlockRepo.AddQuestion(item);
            }
           
            return Ok();
        }

        /// <summary>
        /// Add Answer
        /// </summary>
        /// <param name="answer">Answer as string</param>
        /// <param name="questionId">questionId as Guid</param>
        /// <returns>Status code of request</returns>
        /// <response code="422">Validation error</response>
        [HttpPost]
        [Route("AddAnswer")]
        //[ValidateAntiForgeryToken]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult AddAnswer(Guid questionId, string answer)
        {
            if (string.IsNullOrEmpty(answer) || questionId.Equals(""))
            {
                return NotFound();
            }
            _questionnaireBlockRepo.AddAnswer(questionId,answer);
            return Ok();
        }

        /// <summary>
        /// Delete Question
        /// </summary>
        /// <param name="questionId">id as Guid</param>
        /// <returns>Status code of request</returns>
        /// <response code="422">Validation error</response>
        [HttpPost]
        [Route("DeleteQuestion")]
        //[ValidateAntiForgeryToken]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult DeleteQuestion(Guid questionId)
        {
            if (questionId.Equals(""))
            {
                return NotFound();
            }
            _questionnaireBlockRepo.DeleteQuestion(questionId);
            return Ok();
        }


        /// <summary>
        /// Get All Question
        /// </summary>       
        /// <returns>Status code of request</returns>
        /// <response code="422">Validation error</response>
        [HttpGet]
        [Route("GetAllQuestions")]
        //[ValidateAntiForgeryToken]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<QuestionBlock>> GetAllQuestions()
        {            
            return Ok(_questionnaireBlockRepo.GetAllQuestions());
        }

    }
}
