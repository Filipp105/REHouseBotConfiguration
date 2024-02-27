using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RE_House_Bot_Configuration.Pages
{
    public class MessageTextModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public MessageTextModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public string MessageText { get; set; }

        public void OnGet()
        {
            var messageTextFilePath = _configuration["FilePaths:MessageTextFilePath"];

            if (System.IO.File.Exists(messageTextFilePath))
            {
                MessageText = System.IO.File.ReadAllText(messageTextFilePath);
            }
            else
            {
                MessageText = "Message text file not found";
            }
        }

        public IActionResult OnPost()
        {
            var messageTextFilePath = _configuration["FilePaths:MessageTextFilePath"];
            System.IO.File.WriteAllText(messageTextFilePath, MessageText);
            return RedirectToPage("./MessageText");
        }

        public IActionResult OnGetText()
        {
            var messageTextFilePath = _configuration["FilePaths:MessageTextFilePath"];
            if (System.IO.File.Exists(messageTextFilePath))
            {
                var messageText = System.IO.File.ReadAllText(messageTextFilePath);
                return Content(messageText);
            }
            else
            {
                return Content("Message text file not found");
            }
        }
    }
}