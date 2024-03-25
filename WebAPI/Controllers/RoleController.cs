using Domain.DTO;
using Domain.Entities;
using Domain.Repository.Base;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRepositoryEntityBase<Role, RoleRequest> _repo;

        public RoleController(IRepositoryEntityBase<Role, RoleRequest> repo)
        {
            _repo = repo;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> Get()
        {
            var item = await _repo.GetAll();
            return Ok(item);
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetById(int id)
        {
            var item = await _repo.GetById(id);
            return Ok(item);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult<Role>> Create([FromBody] RoleRequest entity)
        {
            var item = await _repo.Create(entity);
            return CreatedAtAction(nameof(GetById), new { id = item.RoleID }, item);
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] RoleRequest entity)
        {
            await _repo.Update(id, entity);
            return NoContent();
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repo.Delete(id);
            return NoContent();
        }
    }
}
