using asuransi_polis.Models;
using asuransi_polis.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace asuransi_polis.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly PolisService _polisService;

        public DeleteModel(PolisService polisService)
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
            _polisService.DeletePolis(Polis.NomorPolis);
            return RedirectToPage("Index");
        }
    }
}