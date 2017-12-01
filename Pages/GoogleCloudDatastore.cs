using System;
using Google.Cloud.Datastore.V1;

namespace HowzWebRazor001.Pages
{
    public static class GoogleCloudDatastore
    {
        private static string gcpProjectId = "howzgcp004";

        public static DatastoreDb CreateDb()
        {
            // Instantiates a client
            DatastoreDb db = DatastoreDb.Create(gcpProjectId);
            return db;
        }
    }
}
