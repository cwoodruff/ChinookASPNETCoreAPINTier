using System.Threading.Tasks;
using Alba;
using Chinook.API;
using Xunit;

namespace Chinook.IntegrationTest.API
{
    public class AlbumApiAlbaTest
    {
        [Fact]
        public async Task should_get_list_of_albums()
        {
            using (var system = SystemUnderTest.ForStartup<Startup>())
            {
                // This runs an HTTP request and makes an assertion
                // about the expected content of the response
                await system.Scenario(_ =>
                {
                    _.Get.Url("/api/Album");
                    _.StatusCodeShouldBeOk();
                });
            }
        }

        [Fact]
        public async Task should_get_single_album()
        {
            using (var system = SystemUnderTest.ForStartup<Startup>())
            {
                // This runs an HTTP request and makes an assertion
                // about the expected content of the response
                await system.Scenario(_ =>
                {
                    _.Get.Url("/api/Album/4/");
                    _.StatusCodeShouldBeOk();
                });
            }
        }
    }
}