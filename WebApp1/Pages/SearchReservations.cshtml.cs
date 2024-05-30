using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Pages
{
    [Authorize]
    public class SearchReservationsModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly ILogger<SearchReservationsModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public SearchReservationsModel(AppDbContext context, ILogger<SearchReservationsModel> logger, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public IList<Reservation> Reservations { get; set; }
        public SelectList Rooms { get; set; }
        [BindProperty(SupportsGet = true)]
        public string RoomFilter { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime? StartDate { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime? EndDate { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? CapacityFilter { get; set; }

        public async Task OnGetAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            Rooms = new SelectList(await _context.Rooms.ToListAsync(), "RoomName", "RoomName");

            var reservationsQuery = _context.Reservations.Where(r => r.ReservedBy == currentUser.UserName)
                .Include(r => r.Room).AsQueryable();

            if (!string.IsNullOrEmpty(RoomFilter))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Room.RoomName == RoomFilter);
            }

            if (StartDate.HasValue)
            {
                reservationsQuery = reservationsQuery.Where(r => r.DateTime.Date >= StartDate.Value);
            }

            if (EndDate.HasValue)
            {
                reservationsQuery = reservationsQuery.Where(r => r.DateTime.Date <= EndDate.Value);
            }

            if (CapacityFilter.HasValue)
            {
                reservationsQuery = reservationsQuery.Where(r => r.Room.Capacity >= CapacityFilter.Value);
            }

            Reservations = await reservationsQuery.ToListAsync();
        }
    }
}
