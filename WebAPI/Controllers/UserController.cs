using Domain.DTO;
using Domain.Entities;
using Domain.Repository.Base;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryEntityBase<User, UserRequest> _repo;

        public UserController(IRepositoryEntityBase<User, UserRequest> repo)
        {
            _repo = repo;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var item = await _repo.GetAll();
            return Ok(item);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var item = await _repo.GetById(id);
            return Ok(item);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] UserRequest entity)
        {
            var item = await _repo.Create(entity);
            return CreatedAtAction(nameof(GetById), new { id = item.UserID }, item);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UserRequest entity)
        {
            await _repo.Update(id, entity);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repo.Delete(id);
            return NoContent();
        }
    }
}
