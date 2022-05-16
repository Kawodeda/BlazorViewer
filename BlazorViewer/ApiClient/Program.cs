
//namespace ApiClient
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {

//        }
//    }
//}

using ApiClient;

Client client = new Client("https://localhost:7091", new HttpClient());

var response = await client.DesignsGET2Async();


