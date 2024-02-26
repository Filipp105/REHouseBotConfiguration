using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RE_House_Bot_Configuration.Pages
{
    public class SettingsModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public SettingsModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public string Settings { get; set; }

        public void OnGet()
        {
            var settingsFilePath = _configuration["FilePaths:SettingsFilePath"];

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
            var settingsFilePath = _configuration["FilePaths:SettingsFilePath"];
            System.IO.File.WriteAllText(settingsFilePath, Settings);
            return RedirectToPage("./Settings");
        }
    }
}
