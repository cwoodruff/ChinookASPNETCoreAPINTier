using Chinook.MockData.Repositories;

namespace Chinook.UnitTest.Supervisor
{
    public class PlayListSupervisorTest
    {
        private ArtistRepository _repo;

        public PlayListSupervisorTest()
        {
            _repo = new ArtistRepository();
        }
    }
}