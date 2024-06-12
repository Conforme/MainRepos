using Microsoft.AspNetCore.Mvc.RazorPages;
using Word = Microsoft.Office.Interop.Word;

namespace Conforme.Pages
{
    public class NavigateModel : PageModel
    {
        public string? SuccessMessage { get; set; }
        public string? FileNamePath { get; set; }
        public Word.Application? WordApp;

        public void OnGet()
        {
            FileToWord();
            ShowSuccess();
        }

        public bool GetFileName()
        {
            object? fileName;
            TempData.TryGetValue("FileName", out fileName);
            if (fileName != null)
            {
                FileNamePath = fileName.ToString();
                return true;
            }
            else
            { return false; }
        }

        public bool PrepareNavigation()
        {
            try
            {
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void FileToWord()
        {
            if (GetFileName()) {
                
                try
                {                    
                    WordApp = new Word.Application();
                    WordApp.Visible = false;
                    //WordApp.Documents.Add(FileNamePath);
                    Document document = WordApp.Documents.Open(FileNamePath);
                    PrepareNavigation();
                }
                finally
                {
                    if (WordApp != null)
                    {
                        WordApp.Quit();
                    }
                }
            }
        }

        public void ShowSuccess()
        {
            object? successMessage;
            TempData.TryGetValue("SuccessMessage", out successMessage);
            if (successMessage != null)
            {
                SuccessMessage = successMessage.ToString();
            }
        }
    }
}
