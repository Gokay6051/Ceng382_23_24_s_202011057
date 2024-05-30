using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Models;

namespace Project.Pages
{
    [Authorize]
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