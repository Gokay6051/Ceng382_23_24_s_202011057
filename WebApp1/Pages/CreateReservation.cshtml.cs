using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Pages
{
    [Authorize]
    public class CreateReservationModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<CreateReservationModel> _logger;

        public CreateReservationModel(AppDbContext context, UserManager<IdentityUser> userManager, ILogger<CreateReservationModel> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public Reservation Reservation { get; set; }
        public SelectList Rooms { get; set; }
        public List<Room> RoomsList { get; set; }
        [BindProperty]
        public int PersonCount { get; set; }

        public void OnGet()
        {
            RoomsList = _context.Rooms.ToList();
            Rooms = new SelectList(RoomsList, "Id", "RoomName");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Reservation.RoomId == 0 || Reservation.DateTime == default || PersonCount <= 0)
            {
                if (Reservation.RoomId == 0)
                {
                    ModelState.AddModelError("Reservation.RoomId", "Room is required.");
                }
                if (Reservation.DateTime == default)
                {
                    ModelState.AddModelError("Reservation.DateTime", "Date and Time is required.");
                }
                if (PersonCount <= 0)
                {
                    ModelState.AddModelError("PersonCount", "Person count should be more than 0.");
                }
                return Page();
            }

            var room = await _context.Rooms.FindAsync(Reservation.RoomId);
            if (PersonCount > room.Capacity)
            {
                ModelState.AddModelError("PersonCount", "Person count exceeds room capacity.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            Reservation.ReservedBy = user.UserName;
            _context.Reservations.Add(Reservation);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Reservation created by {User} for room {RoomId} at {DateTime}", user.UserName, Reservation.RoomId, Reservation.DateTime);

            return RedirectToPage("/Index");
        }
    }
}
