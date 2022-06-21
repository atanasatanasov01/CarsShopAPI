namespace RestAPI.Settings
{
    public class MongoDbSettings
    {
        public string Host {get; set;}

        public int Port {get; set;}

        public string connectionString {get
        {
            return "mongodb://docker:mongopw@localhost:49153";
        }
        }
    }
}