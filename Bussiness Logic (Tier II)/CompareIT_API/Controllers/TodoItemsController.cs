using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CompareIT_API.Model;
using CustomAPI_V4;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CompareIT_API
{
        [Route("api/TodoItems")]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext context;
        private CompareIT compare = new CompareIT(); // connection to the tier2
       
        
        public TodoItemsController(TodoContext context)
        {
            this.context = context;
        }


        //GET by query string
        [HttpGet]
        public IEnumerable<Item> GetItems(string title)
        {
            var result= compare.SortedPriceList(title);
            return result;
        }

        //POST getting a list by a received string
        [HttpPost]
        public IEnumerable<Item> GetItemsPost(string title)
        {
            var result = compare.SortedPriceList(title);
            return result;
        }


        /*

        //GET by query string
        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> GetTodoItems(string title)
        {
            Console.WriteLine($"Get all here.Title: {title}");

            IQueryable<TodoItem> todoItems = context.TodoItems;
            todoItems = todoItems.Where(item => title == null || item.Title.Equals(title)  );
            
            if (!todoItems.Any())
            {
                return NotFound();
            }

            return result;
        }*/

        /*// GET: api/TodoItems/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            Console.WriteLine("Get here");
            TodoItem todoItem = await context.TodoItems.FindAsync(id);
            compare.SearchForItems();  // the method from tier2 compareIT class
            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
        */

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