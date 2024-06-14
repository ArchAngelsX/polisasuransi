using asuransi_polis.Models;
using asuransi_polis.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public class CreateModel : PageModel
{
    [BindProperty]
    public Polis Polis { get; set; }

    private readonly PolisService _polisService;

    public CreateModel(PolisService polisService)
    {
        _polisService = polisService;
    }

    public IActionResult OnPost()
    {
        Console.WriteLine("OnPost method called");

        if (!ModelState.IsValid)
        {
            Console.WriteLine("Model state is invalid");
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return Page();
        }

        Console.WriteLine("Polis object:");
        Console.WriteLine($"NamaTertanggung: {Polis.NamaTertanggung}");
        Console.WriteLine($"TanggalEfektif: {Polis.TanggalEfektif}");
        //... and so on for each property

        _polisService.AddPolis(Polis);

        return RedirectToPage("./Index");
    }
}