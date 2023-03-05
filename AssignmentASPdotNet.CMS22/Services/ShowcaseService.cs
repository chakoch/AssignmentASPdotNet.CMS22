using AssignmentASPdotNet.CMS22.Contexts;
using AssignmentASPdotNet.CMS22.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AssignmentASPdotNet.CMS22.Services
{
    public class ShowcaseService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ShowcaseService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ShowcaseModel> GetLatestShowcase()
        {
            return _mapper.Map<ShowcaseModel>(
                await _context.Showcases
                    .Include(x => x.NavLink)
                    .Include(x => x.Image)
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefaultAsync()
                );
        }

    }
}
