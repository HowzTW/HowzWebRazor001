using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Google.Cloud.Datastore.V1;

namespace HowzWebRazor001.Pages
{
    public class GcpTestModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {


            /* *****************************************************************
            // Your Google Cloud Platform project ID
            string projectId = "howzgcp004";

            // Instantiates a client
            DatastoreDb db = DatastoreDb.Create(projectId);
            ***************************************************************** */

            DatastoreDb db = GoogleCloudDatastore.CreateDb();

            /* *****************************************************************
            // The kind for the new entity
            string kind = "Task";
            // The name/ID for the new entity
            string name = "sampletask1";
            KeyFactory keyFactory = db.CreateKeyFactory(kind);
            // The Cloud Datastore key for the new entity
            Key key = keyFactory.CreateKey(name);

            var task = new Entity
            {
                Key = key,
                ["description"] = "Buy milk"
            };
            using (DatastoreTransaction transaction = db.BeginTransaction())
            {
                // Saves the task
                transaction.Upsert(task);
                transaction.Commit();

                Console.WriteLine($"Saved {task.Key.Path[0].Name}: {(string)task["description"]}");
            }
            ***************************************************************** */

 



            Query query = new Query("Beer")
            {
                Filter = Filter.Equal("Brand", "TOOL")
            };
            foreach (Entity entity in db.RunQueryLazily(query))
            {
                string beerBrand = (string)entity["Brand"];
                string beerName = (string)entity["Name"];
                int beerCost = (int)entity["Cost"];
                int beerPrice = (int)entity["Price"];
                DateTime beerStockDate = (DateTime)entity["StockDate"];
                Console.WriteLine("Brand:{0} Name:{1} Cost:{2} Price:{3} StockDate:{4} ", 
                                  beerBrand, beerName, beerCost, beerPrice, beerStockDate);
                
                entity.Key = db.CreateKeyFactory("Beer").CreateIncompleteKey();
                entity["Brand"] = beerBrand + " again";
                var keys = db.Upsert(new[] { entity });
                Console.WriteLine("Beer Id: {0}", keys.First().Path.First().Id);

            }


            var task = new Entity
            {
                Key = db.CreateKeyFactory("Task").CreateIncompleteKey(),
                ["memo"] = "買牛奶"
            };
            var taskkeys = db.Insert(new[] { task });
            Console.WriteLine("Task Id: {0}", taskkeys.First().Path.First().Id);

            var employee = new Entity
            {
                Key = db.CreateKeyFactory("Employee").CreateIncompleteKey(),
                ["PersonId"] = "A123901930",
                ["Name"] = "陳小寶"
            };
            var employeeKeys = db.Insert(new[] { employee });
            Console.WriteLine("Employee Id: {0}, Employee Kind: {1}", employeeKeys.First().Path.First().Id, employeeKeys.First().Path.First().Kind);

            Message = "Your Goole Cloud Platform Test page. (測試beer and task and employee)";
        }
    }
}
