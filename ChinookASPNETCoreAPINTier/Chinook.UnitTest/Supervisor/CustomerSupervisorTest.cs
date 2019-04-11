using Chinook.MockData.Repositories;

namespace Chinook.UnitTest.Supervisor
{
    public class CustomerSupervisorTest
    {
        private ArtistRepository _repo;

        public CustomerSupervisorTest()
        {
            _repo = new ArtistRepository();
        }
    }
}