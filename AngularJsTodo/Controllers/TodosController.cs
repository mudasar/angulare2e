using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AngularJsTodo.Models;

namespace AngularJsTodo.Controllers
{
    public class TodosController : ApiController
    {
        private AngularJsTodoContext db = new AngularJsTodoContext();

        // GET: api/Todos
        public IQueryable<TodoItem> GetTodoItems(string q = null, string sort = null, bool desc = false, int? limit = null, int offset = 0)
        {
            var list = ((IObjectContextAdapter)db).ObjectContext.CreateObjectSet<TodoItem>();
            IQueryable<TodoItem> items = string.IsNullOrWhiteSpace(sort)
                ? list.OrderBy(o => o.Priority)
                : list.OrderBy(string.Format("it.{0} {1}", sort, desc ? "DESC" : "ASC"));
            if (!string.IsNullOrWhiteSpace(q) && q != "undefined")
            {
                items = items.Where(t => t.Text.Contains(q));
            }

            if (offset > 0)
            {
                items = items.Skip(offset);
            }

            if (limit.HasValue)
            {
                items = items.Take(limit.Value);
            }
            return items;
            //return db.TodoItems;
        }

        // GET: api/Todos/5
        [ResponseType(typeof(TodoItem))]
        public async Task<IHttpActionResult> GetTodoItem(int id)
        {
            TodoItem todoItem = await db.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        // PUT: api/Todos/5
        
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTodoItem(int id, TodoItem todoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            db.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Todos
        [ResponseType(typeof(TodoItem))]
        public async Task<IHttpActionResult> PostTodoItem(TodoItem todoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TodoItems.Add(todoItem);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = todoItem.Id }, todoItem);
        }

        // DELETE: api/Todos/5
        [ResponseType(typeof(TodoItem))]
        public async Task<IHttpActionResult> DeleteTodoItem(int id)
        {
            TodoItem todoItem = await db.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            db.TodoItems.Remove(todoItem);
            await db.SaveChangesAsync();

            return Ok(todoItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TodoItemExists(int id)
        {
            return db.TodoItems.Count(e => e.Id == id) > 0;
        }
    }
}