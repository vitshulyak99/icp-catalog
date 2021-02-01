using Collections.DAL;
using Collections.DAL.Entities;
using Services.Abstractions;
using Services.Abstractions.Interfaces;

namespace Services.Impl
{
    public class ThemeService : BaseCrudService<Theme>, IThemeService
    {
        public ThemeService(AppDbContext context) : base(context)
        {
        }
    }
}