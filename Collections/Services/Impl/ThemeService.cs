using System.Linq;
using AutoMapper;
using Collections.DAL;
using Collections.DAL.Entities;
using Services.Abstractions;
using Services.Abstractions.Interfaces;
using Services.Dto;

namespace Services.Impl
{
    public class ThemeService : BaseCrudService<Theme,ThemeDto>, IThemeService
    {
        public ThemeService(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            
        }
        
        protected override IQueryable<Theme> Include(IQueryable<Theme> query) => query;
    }
}