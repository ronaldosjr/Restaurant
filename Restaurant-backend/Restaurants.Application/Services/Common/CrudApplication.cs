using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Restaurants.Application.Dtos.Common;
using Restaurants.Domain.Entities.Common;
using Restaurants.Domain.Properties;
using Restaurants.Domain.Services.ValidationServices.Common;
using Restaurants.Infra.Context;
using Restaurants.Infra.Repositories.Common;

namespace Restaurants.Application.Services.Common
{
    public abstract class CrudApplication<TDto, TEntity> 
        : ICrudApplication<TDto, TEntity> 
        where TDto : BaseCrudDto 
        where TEntity : BaseEntity
    {
        protected readonly IConnection Connection;
        protected readonly IMapper Mapper;
        protected readonly IRepository<TEntity> Repository;
        protected readonly IValidationBeforePersist<TEntity> Validation;

        protected CrudApplication(
            IConnection connection,
            IMapper mapper,
            IRepository<TEntity> repository,
            IValidationBeforePersist<TEntity> validation)
        {
            Connection = connection;
            Mapper = mapper;
            Repository = repository;
            Validation = validation;
        }

        public TDto Add(TDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);

            if (Validation.CanPersist(entity))
            {
                Repository.Add(entity);
                Connection.Commit();
            }

            return Mapper.Map<TDto>(entity); 
        }

     
        public TDto Update(TDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);

            if (Validation.CanPersist(entity))
            {
                Repository.Update(entity);
                Connection.Commit();
            }

            return Mapper.Map<TDto>(entity);
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
            Connection.Commit();
            
        }

        public IEnumerable<TDto> GetAll()
        {
            return Mapper.Map<IEnumerable<TDto>>(Repository.GetAll());
        }

        
    }
}
