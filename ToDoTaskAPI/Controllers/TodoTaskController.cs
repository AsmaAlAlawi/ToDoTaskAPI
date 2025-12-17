using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using ToDoTaskAPI.Context;
using ToDoTaskAPI.DTO;
using ToDoTaskAPI.Models;

namespace ToDoTaskAPI.Controllers
{
    //[Route("api/[controller]")]
   // [ApiController]

    
    public class TodoTaskController : BaseController
    {
        private readonly ApplicationDbContext _db;
        public TodoTaskController( ApplicationDbContext db)
        {
                _db =db;
        }
       

    [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<TodoTask>>> Get()
    {
            var todo =await _db.ToDoTasks.ToListAsync();
            if(todo.Count()> 0)
            {
                return Ok(todo);
            }
            return Ok("No Data Found!!!");
        }

        [HttpGet("ïnt:id")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task <ActionResult<CatWithoutList>> GetById(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            var todo =await _db.ToDoTasks.FirstOrDefaultAsync(t => t.Id == id);
            if(todo == null)
            {
                return NotFound();
            }
            var catwithout = new CatWithoutList
            {
                Id = todo.Id,
                    Name = todo.Name
                };
                return Ok(catwithout);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TodoTask>> Post(TodoTask obj)
        {
            if (ModelState.IsValid)
            {
                await _db.ToDoTasks.AddAsync(obj);
                await _db.SaveChangesAsync();
            }
            return BadRequest();

        }

        [HttpPut("int:Id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<TodoTask>> Update(int id, CatWithoutList cat)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var cate = await _db.ToDoTasks.FirstOrDefaultAsync(c => c.Id == id);
            if (cate is null)
            {
                return NotFound();
            }
            cate.Name = cat.Name;
            _db.ToDoTasks.Update(cate);
            await _db.SaveChangesAsync();
            return Ok(cate);
        }



        [HttpDelete("int:id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete(int id)
        {
            var cat = await _db.ToDoTasks.FindAsync(id);
            if (cat is null)
            {
                return NotFound();
            }
            _db.ToDoTasks.Remove(cat);
            _db.SaveChanges();
            return Ok();
        }

    }
}