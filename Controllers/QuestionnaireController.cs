using Microsoft.AspNetCore.Mvc;
using QuestionnaireApp.Model;

namespace QuestionnaireApp.Controllers
{
    [Route("api/")]
    [ApiController]
    public class QuestionnaireController : ControllerBase
    {
        //Below methods are in synch mode, will add async later

        private readonly IQuestionnaireRepo questionnaireRepo;
        public QuestionnaireController(IQuestionnaireRepo questionnaireRepo)
        {
            this.questionnaireRepo = questionnaireRepo;
        }

        /// <summary>
        /// Get Questionnaire
        /// Get Questions and Answers
        /// </summary>
        /// <response code="422">Validation error</response>
        [HttpGet]
        [Route("questions")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Questionnaire> GetQuestionnaire()
        {
            //database and other stuff can be added here
            return Ok(questionnaireRepo.GetQuestionnaire());
        }

        /// <summary>
        /// Add Question
        /// </summary>
        /// <param name="question">Question in string</param>
        /// <returns>Status code of request</returns>
        /// <response code="422">Validation error</response>
        [HttpPost]
        [Route("AddQuestion")]
        [Produces("application/json")]
        //[ValidateAntiForgeryToken]
        public ActionResult AddQuestion(string question)
        {
            if (string.IsNullOrEmpty(question))
            {
                return NotFound();
            }
            questionnaireRepo.AddQuestion(question);
            return Ok();
        }

        /// <summary>
        /// Add Questions
        /// </summary>
        /// <param name="questions">Questions Json array</param>
        /// <returns>Status code of request</returns>
        /// <response code="422">Validation error</response>
        [HttpPost]
        [Route("AddQuestions")]
        // [ValidateAntiForgeryToken]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult AddQuestions(string[] questions)
        {
            if (questions.Length < 1)
            {
                return NotFound();
            }
            questionnaireRepo.AddQuestions(questions);
            return Ok();
        }

        /// <summary>
        /// Add Answer
        /// </summary>
        /// <param name="answer">Answer as string</param>
        /// <returns>Status code of request</returns>
        /// <response code="422">Validation error</response>
        [HttpPost]
        [Route("AddAnswer")]
        //[ValidateAntiForgeryToken]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult AddAnswer(string answer)
        {
            if (string.IsNullOrEmpty(answer))
            {
                return NotFound();
            }
            questionnaireRepo.AddAnswer(answer);
            return Ok();
        }

        /// <summary>
        /// Add Answers
        /// </summary>
        /// <param name="answers">Answers as json array</param>
        /// <returns>Status code of request</returns>
        /// <response code="422">Validation error</response>
        [HttpPost]
        [Route("AddAnswers")]
        // [ValidateAntiForgeryToken]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult AddAnswers(string[] answers)
        {
            //will add other methods later on 

            if (answers.Length < 1)
            {
                return NotFound();
            }
            questionnaireRepo.AddAnswers(answers);
            return Ok();
        }

        /// <summary>
        /// Add Title
        /// </summary>
        /// <param name="title">Title as string</param>
        /// <returns>Status code of request</returns>
        /// <response code="422">Validation error</response>
        [HttpPost]
        [Route("AddTitle")]
        [Produces("application/json")]
        // [ValidateAntiForgeryToken]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]        
        public ActionResult AddTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return NotFound();
            }
           questionnaireRepo.AddTitle(title);
            return Ok();
        }


    }
}
