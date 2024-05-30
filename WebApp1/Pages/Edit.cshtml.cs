using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Pages
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EditModel(AppDbContext context,  UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        
        [BindProperty]
        public Reservation Reservation { get; set; }
        public SelectList Rooms { get; set; }
        [BindProperty]
        public int PersonCount {get; set;}

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Reservation = await _context.Reservations.FindAsync(id);
            Rooms = new SelectList(_context.Rooms, "Id", "RoomName");

            if (Reservation == null)
            {
                return Content("abc");
                //return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var user = await _userManager.GetUserAsync(User);
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

            Reservation reservationToUpdate = await _context.Reservations.FindAsync(id);
            if (reservationToUpdate == null)
            {
                //return Content("asd");
                return NotFound();
                //return Content($"Belirtilen ID değeri {id} için kayıt bulunamadı.");
            }

            reservationToUpdate.DateTime = Reservation.DateTime;
            reservationToUpdate.ReservedBy = user.UserName;
            reservationToUpdate.RoomId = Reservation.RoomId;
            reservationToUpdate.Room = Reservation.Room;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}