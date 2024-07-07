using Newtonsoft.Json;
using RestSharp;
using static API_Tests.DataModels;

namespace API_Tests
{
    public class ReqResClient
    {
        private readonly IRestClient _client;
        public ReqResClient()
        {
            _client = new RestClient("https://reqres.in/");
        }

        public async Task<int> GetUserCount()
        {
            var request = new RestRequest("api/users?page=2", Method.Get);
            var result = await _client.ExecuteAsync(request);
            var json = JsonConvert.DeserializeObject<DataModels.general>(result.Content!);
            return json!.total;
        }

        public async Task<int> GetPageCount()
        {
            var request = new RestRequest("api/users?page=2", Method.Get);
            var result = await _client.ExecuteAsync(request);
            var json = JsonConvert.DeserializeObject<DataModels.general>(result.Content!);
            return json!.page;
        }

        public async Task<RestResponse> GetAllUsers()
        {
            var request = new RestRequest("api/users?page=1", Method.Get);
            var result = await _client.ExecuteAsync(request);
            return result;
        }

        public async Task<RestResponse> CreateUser()
        {
            var request = new RestRequest("api/users", Method.Post);
            var payload = new DataModels.createUserPayload() { First_name = "FakeFirstName", Last_name = "FakeLastName"};
            request.AddBody(payload);
            var result = await _client.ExecutePostAsync(request);
            Console.WriteLine(result.Content!.ToString());
            return result;
        }

        public async Task<RestResponse> UpdateUser(int id)
        {
            var request = new RestRequest("api/users/" + id + "", Method.Put);
            var payload = new DataModels.updateUserPayload { First_name = "UpdatedFirstName", Last_name = "UpdatedLastName" };
            request.AddBody(payload);
            var result = await _client.ExecutePutAsync(request);
            Console.WriteLine(result.Content!.ToString());
            return result;
        }

        public void ListAllUsers(RestResponse response)
        {
            var generalJSON = JsonConvert.DeserializeObject<DataModels.general>(response.Content!);
            var usersJSON = generalJSON!.data;
            foreach (var user in usersJSON)
            {
                Console.WriteLine("ID: " + user.id);
                Console.WriteLine("First name: " + user.first_name);
                Console.WriteLine("Last name: " + user.last_name);
            }
        }

        public async Task<RestResponse> getUser(int id)
        {
            var request = new RestRequest("api/users/" + id + "", Method.Get);
            var result = await _client.ExecuteAsync(request);
            return result;
        }
    }
}
