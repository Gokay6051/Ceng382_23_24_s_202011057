using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Project.Pages
{
    public class ShowRoomsModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public ShowRoomsModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Room> Rooms { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Rooms = await _dbContext.Rooms.ToListAsync();
            return Page();
        }
    }
}