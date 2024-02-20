using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace RE_House_Bot_Configuration.Pages
{
    public class MessageTextModel : PageModel
    {
        string messageTextFilePath = "Data/message.txt";

        [BindProperty]
        public string MessageText { get; set; }

        public void OnGet()
        {
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
            System.IO.File.WriteAllText(messageTextFilePath, MessageText);
            return RedirectToPage("./MessageText");
        }
    }
}