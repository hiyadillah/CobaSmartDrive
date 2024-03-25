using Domain.DTO;
using Domain.Entities;
using Domain.Repository.Base;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IRepositoryEntityBase<Permission, PermissionRequest> _repo;

        public PermissionController(IRepositoryEntityBase<Permission, PermissionRequest> repo)
        {
            _repo = repo;
        }

        // GET: api/<PermissionController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Permission>>> Get()
        {
            var item = await _repo.GetAll();
            return Ok(item);
        }

        // GET api/<PermissionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Permission>> GetById(int id)
        {
            var item = await _repo.GetById(id);
            return Ok(item);
        }

        // POST api/<PermissionController>
        [HttpPost]
        public async Task<ActionResult<Permission>> Create([FromBody] PermissionRequest entity)
        {
            var item = await _repo.Create(entity);
            return CreatedAtAction(nameof(GetById), new { id = item.PermissionID }, item);
        }

        // PUT api/<PermissionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PermissionRequest entity)
        {
            await _repo.Update(id, entity);
            return NoContent();
        }

        // DELETE api/<PermissionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repo.Delete(id);
            return NoContent();
        }
    }
}
