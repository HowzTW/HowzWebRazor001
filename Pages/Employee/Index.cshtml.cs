using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Datastore.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HowzWebRazor001.Pages.Employee
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public List<Entity> Employees { get; set; }

        public void OnGet()
        {
            DatastoreDb db = GoogleCloudDatastore.CreateDb();

            // 查詢現有貝工
            Query query = new Query("Employee");
            var allEmployee = db.RunQueryLazily(query);
            int count = allEmployee.Count();
            Employees = allEmployee.ToList();

            Message = "員工資料新增/修改/刪除作業";
        }
    }
}
