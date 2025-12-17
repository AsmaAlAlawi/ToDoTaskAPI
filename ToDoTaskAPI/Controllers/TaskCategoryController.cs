using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ToDoTaskAPI.Context;
using ToDoTaskAPI.DTO;
using ToDoTaskAPI.Models;

namespace ToDoTaskAPI.Controllers
{
    //   [Route("api/[Controller]")]
    // [ApiController]
    public class TaskCategoryController : BaseController
    {
        private readonly ApplicationDbContext _db;
        public TaskCategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<TaskCategory>>> Get()
        {
            var cats = await _db.TaskCategories.ToListAsync();
            if (cats.Count() > 0)
            {
                return Ok(cats);
            }
            return Ok("No Data Found!!!");
        }

//Get method using id
        [HttpGet("int:id")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<CatWithoutList>> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var cat = await _db.TaskCategories.FirstOrDefaultAsync(c => c.Id == id);
            if (cat == null)
            {
                return NotFound();
            }
                var catwithout = new CatWithoutList()
                {
                    Id = cat.Id,
                    Name = cat.Name
                };
                // return Ok(cat);
                return Ok(catwithout);
            }

        

            /* [HttpPost]
             [ProducesResponseType(StatusCodes.Status201Created)]
             public ActionResult Post([FromBody] TaskCategory category)
             {
                 _db.TaskCategories.Add(category);
                 _db.SaveChanges();
                 return CreatedAtAction("Get", new { id = category.Id }, category);

             }
            */

            [HttpPost]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            //[ProducesResponseType(StatusCodes.Status201Created)]
            public async Task<ActionResult<TaskCategory>> Post(TaskCategory obj)
            {
                if (ModelState.IsValid)
                {
                   await _db.TaskCategories.AddAsync(obj);
                   await _db.SaveChangesAsync();
                }
                return BadRequest();

            }


//Update method using PUT
        [HttpPut("int:Id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        

            public async Task< ActionResult<TaskCategory>> Update(int id, CatWithoutList cat)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var cate = await _db.TaskCategories.FirstOrDefaultAsync(c => c.Id == id);
            if(cate is null)
            {
                return NotFound();
            }
            cate.Name = cat.Name;
            _db.TaskCategories.Update(cate);
            await _db.SaveChangesAsync();
            return Ok(cate);
        }
        /*[HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            public ActionResult Put(int id, [FromBody] TaskCategory category)
            {
                var catInDb = _db.TaskCategories.Find(id);
                if (catInDb == null)
                {
                    return NotFound();
                }
                catInDb.Name = category.Name;
                _db.SaveChanges();
                return NoContent();
            }
        */


//Delete method using DELETE

        [HttpDelete("int:id")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
            public async Task<ActionResult> Delete(int id)
            {
                var cat = await _db.TaskCategories.FindAsync(id);
                if (cat is null)
                {
                    return NotFound();
                }
                _db.TaskCategories.Remove(cat);
                _db.SaveChanges();
                return Ok();
            }
        
    }
}