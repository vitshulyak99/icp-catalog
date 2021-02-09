using System.Collections.Generic;

namespace Services.Abstractions.Interfaces
{
    public interface ICrudService<TDto>
    {
        IEnumerable<TDto> GetPage(int skip = 0, int take = -1);
        IEnumerable<TDto> GetAll();
        TDto GetById(int id);
        TDto Create(TDto dto);
        TDto Update(TDto dto);
        void Delete(params int[] ids);
    }
}
