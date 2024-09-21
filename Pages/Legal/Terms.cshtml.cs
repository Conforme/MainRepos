﻿using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Conforme.Pages.Legal
{
    public class TermsModel : PageModel
    {
        private readonly ILogger<TermsModel> _logger;

        public TermsModel(ILogger<TermsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}