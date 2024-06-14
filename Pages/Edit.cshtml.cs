using asuransi_polis.Models;
using asuransi_polis.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace asuransi_polis.Pages
{
    public class EditModel : PageModel
    {
        private readonly PolisService _polisService;

        public EditModel(PolisService polisService)
        {
            _polisService = polisService;
        }

        [BindProperty]
        public Polis Polis { get; set; }

        public async Task OnGetAsync(string nomorPolis)
        {
            Polis = _polisService.GetPolisByNomorPolis(nomorPolis);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _polisService.UpdatePolis(Polis);
            return RedirectToPage("Index");
        }
    }
}