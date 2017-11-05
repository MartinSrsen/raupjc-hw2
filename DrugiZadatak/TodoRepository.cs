using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GenericList;

namespace DrugiZadatak
{
    public class TodoRepository : ITodoRepository
    {

        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
        }

        

        public TodoItem Get(Guid todoId)
        {
            TodoItem t = _inMemoryTodoDatabase.Where(i => i.Id.Equals(todoId)).FirstOrDefault();

            return t;
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Where(i => i.Id == todoItem.Id).FirstOrDefault() == null)
            {
                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }
            else
            {
                throw new DuplicateTodoItemException("duplicate id: " + todoItem.Id);
            }
        }

        public bool Remove(Guid todoId)
        {
            TodoItem t = Get(todoId);

            if (t != null)
            {
                _inMemoryTodoDatabase.Remove(t);
                return true;
            }

            return false;
        }

        public TodoItem Update(TodoItem todoItem)
        {
            if (todoItem == null)
            {
                todoItem = new TodoItem("Todo Item: ");
            }
            String newtext = todoItem.Text += " UPDATED";
            todoItem.Text = newtext;
            todoItem.DateCompleted = DateTime.UtcNow;

            return todoItem;
        }

        public bool MarkAsCompleted(Guid todoId)
        {

            if (Get(todoId) == null)
            {
                return false;
            }

            return Get(todoId).MarkAsCompleted();
           
        }

        public List<TodoItem> GetAll()
        {
           
            return _inMemoryTodoDatabase.OrderByDescending(s => s.DateCreated).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(s => s.IsCompleted == false).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(s => s.IsCompleted == true).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(s => filterFunction(s) == true).ToList();
        }
    }

    
}
