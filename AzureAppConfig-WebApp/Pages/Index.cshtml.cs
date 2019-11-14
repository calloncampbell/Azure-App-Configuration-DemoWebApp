using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AzureAppConfig_WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IOptionsSnapshot<Settings> options)
        {
            _logger = logger;
            Settings = options.Value;
        }

        public Settings Settings { get; }

        public void OnGet()
        {

        }
    }
}
