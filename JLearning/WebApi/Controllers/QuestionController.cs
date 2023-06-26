using AutoMapper;
using BusinessObjects.DTO;
using BusinessObjects.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Reporitories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        // Repository
        private IQuestionRepository repository = new QuestionRepository();

        // Mapper
        private readonly IMapper _mapper;

        // Get mapper singleton
        public QuestionController(IMapper mapper)
        {
            _mapper = mapper;
        }


        // POST api/<QuestionController>
        [HttpPost("insert")]
        public ActionResult Post([FromBody][Bind("test_id,answer_1,answer_2,answer_3,answer_4,description,explaination,correct_answer")] QuestionDTO questionDTO)
        {
                Question question = _mapper.Map<Question>(questionDTO);
                repository.CreateQuestion(question);
                return Ok();
        }

        // PUT api/<QuestionController>/5
        [HttpPost("update")]
        public ActionResult Put([FromBody][Bind("question_id,test_id,answer_1,answer_2,answer_3,answer_4,description,explaination,correct_answer")] QuestionDTO questionDTO)
        {
            var question = repository.FindQuestionById((int)questionDTO.QuestionId);
            if (question == null) return NotFound();
            Question ques = _mapper.Map<Question>(questionDTO);
            repository.UpdateQuestion(ques);
            return Ok();
        }

        // DELETE api/<QuestionController>/5
        [HttpPost("delete")]
        public ActionResult Delete([FromBody] int question_id)
        {
            var question = repository.FindQuestionById(question_id);
            if (question == null) return NotFound();
            else
            {
                repository.DeleteQuestion(question);
                return Ok();
            }
        }
    }
}
