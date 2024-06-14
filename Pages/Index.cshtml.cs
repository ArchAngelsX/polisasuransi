using asuransi_polis.Models;
using asuransi_polis.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asuransi_polis.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PolisService _polisService;

        public IndexModel(PolisService polisService)
        {
            _polisService = polisService;
        }

        public List<Polis> PolisList { get; set; }

        public void OnGet()
        {
            PolisList = _polisService.GetPolisList();
        }
    }
}