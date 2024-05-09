using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Project.Pages
{
    public class CreateRoomModel : PageModel
    {
        private readonly ILogger<CreateRoomModel> _logger;
        private readonly AppDbContext _dbContext; 

        [BindProperty] 
        public Room room { get; set; } 

        public CreateRoomModel(ILogger<CreateRoomModel> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext; 
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbContext.Rooms.Add(room); 
            _dbContext.SaveChanges();

            return RedirectToPage("/Index"); 
        }
    }
}