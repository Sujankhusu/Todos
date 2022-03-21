using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Dto;
using Volo.Abp.Domain.Repositories;

namespace Todos
{
    public class TodoAppService : TodosAppService
    {
        //private const bool V = false;
        //private const bool V1 = true;
        private readonly IRepository<Todo, Guid> todoRespository;
        private Todo createdTodo;

        public TodoAppService(IRepository<Todo, Guid> todoRespository)
        {
            this.todoRespository = todoRespository;
        }

        public async Task<List<TodoDto>> GetAll()
        {
            return ObjectMapper.Map<List<Todo>, List<TodoDto>>(await todoRespository.GetListAsync());
        }
         
        public async Task<TodoDto> CreateAsync(TodoDto todoDto)
        {
            var todo = ObjectMapper.Map<TodoDto, Todo>(todoDto);
            var createTodo = await todoRespository.InsertAsync(todo);
            return ObjectMapper.Map<Todo, TodoDto>(createdTodo);
        }

        public async Task<TodoDto> UpdateAsync(TodoDto todoDto)
        {
            var todo = ObjectMapper.Map<TodoDto, Todo>(todoDto);
            var createTodo = await todoRespository.UpdateAsync(todo);
            return ObjectMapper.Map<Todo, TodoDto>(createdTodo);
        }

        public async Task<bool> DeleteAsync(Guid id, TodoDto v, TodoDto v1)
        {
            var todo = await todoRespository.FirstOrDefaultAsync(x => x.Id == id);
            if ( todo != null)
            {
                await todoRespository.DeleteAsync(todo);
                return true;
            }
            return false;
        }
    }
}
