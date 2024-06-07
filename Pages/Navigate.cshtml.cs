using Microsoft.AspNetCore.Mvc.RazorPages;
using Word = Microsoft.Office.Interop.Word;

namespace Conforme.Pages
{
    public class NavigateModel : PageModel
    {
        private Word.Application? wordApp;
        public string? SuccessMessage { get; set; }
        public string? FileNamePath { get; set; }

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
                return false;
            }
        }

        public void FileToWord()
        {
            if (GetFileName()) {
                try
                {
                    wordApp = new Word.Application();
                    wordApp.Visible = false;
                    wordApp.Documents.Add(FileNamePath);
                    PrepareNavigation();
                }
                finally
                {
                    if (wordApp != null)
                    {
                        wordApp.Quit();
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
