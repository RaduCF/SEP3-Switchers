using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CompareIT_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CompareIT_API
{
    [ApiController]
    [Route("[controller]")]
    public class TodoItemsController : ControllerBase
    {

        private readonly TodoContext context;
        private CompareIT compare; // connection to the tier2
        public TodoItemsController(TodoContext context, CompareIT compare)
        {

            this.context = context;
        }

        // GET: api/TodoItems/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            Console.WriteLine("Get here");
            TodoItem todoItem = await context.TodoItems.FindAsync(id);
            compare.getPrices;  // the method from tier2 compareIT class
            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        //get by query string
        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> GetTodoItems(string title)
        {
            Console.WriteLine($"Get all here.Title: {title}");

            IQueryable<TodoItem> todoItems = context.TodoItems;
            todoItems = todoItems
                .Where(item => title == null || item.Title.Equals(title));

            if (!todoItems.Any())
            {
                return NotFound();
            }

            return todoItems.ToList();
        }


        /* later use:
        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            Console.WriteLine("Post here");
            context.TodoItems.Add(todoItem);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoItem>> PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (context.TodoItems.Find(id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(long id)
        {
            var todoItem = await context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            context.TodoItems.Remove(todoItem);
            await context.SaveChangesAsync();

            return todoItem;
        }*/
    }
}