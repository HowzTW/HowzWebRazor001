using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HowzWebRazor001.Pages.Employee
{
    public class AddModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet()
        {
            Message = "新增一筆員工資料";
        }
    }
}
