using Newtonsoft.Json;
using RestSharp;
using System.Net;
using static API_Tests.DataModels;

namespace API_Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class AllApiTests
    {

        //SCENARIO 1# - List all users
        //SCENARIO 2# - Create user
        //SCENARIO 3# - Update user

        [Test]
        public async Task ListAllUsers()
        {
            var client = new ReqResClient();
            var response = await client.GetAllUsers();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            client.ListAllUsers(response);
        }

        [Test]
        public async Task CreateUser()
        {
            var client = new ReqResClient();
            var response = await client.CreateUser();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public async Task UpdateUser()
        {
            var client = new ReqResClient();
            var response = await client.UpdateUser(3);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
