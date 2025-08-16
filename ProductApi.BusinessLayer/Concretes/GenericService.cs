using ProductApi.BusinessLayer.Abstracts;
using ProductApi.DataAccessLayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.BusinessLayer.Concretes
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(T entity) => await _repository.InsertAsync(entity);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
        public async Task<List<T>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<T> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task UpdateAsync(T entity) => await _repository.UpdateAsync(entity);
    }
}
