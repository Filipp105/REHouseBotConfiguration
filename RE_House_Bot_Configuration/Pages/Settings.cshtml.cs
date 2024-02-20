using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace RE_House_Bot_Configuration.Pages
{
    public class SettingsModel : PageModel
    {
        string settingsFilePath = "Data/settings.txt";

        [BindProperty]
        public string Settings { get; set; }

        public void OnGet()
        {
            if (System.IO.File.Exists(settingsFilePath))
            {
                Settings = System.IO.File.ReadAllText(settingsFilePath);
            }
            else
            {
                Settings = "Settings file not found";
            }
        }

        public IActionResult OnPost()
        {
            System.IO.File.WriteAllText(settingsFilePath, Settings);
            return RedirectToPage("./Settings");
        }
    }
}