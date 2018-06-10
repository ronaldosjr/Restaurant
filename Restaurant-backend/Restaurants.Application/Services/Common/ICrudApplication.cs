using System.Collections.Generic;
using Restaurants.Application.Dtos.Common;
using Restaurants.Domain.Entities.Common;
using Restaurants.Domain.Specification.Common;

namespace Restaurants.Application.Services.Common
{
    public interface ICrudApplication<TDto, TEntity> where TDto : BaseCrudDto where TEntity : BaseEntity
    {
        TDto Add(TDto dto);
        TDto Update(TDto dto);
        void Delete(int id);
        IEnumerable<TDto> GetAll();

    }

    
}
