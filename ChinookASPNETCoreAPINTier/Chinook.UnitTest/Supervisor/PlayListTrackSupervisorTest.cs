using Chinook.MockData.Repositories;

namespace Chinook.UnitTest.Supervisor
{
    public class PlayListTrackSupervisorTest
    {
        private ArtistRepository _repo;

        public PlayListTrackSupervisorTest()
        {
            _repo = new ArtistRepository();
        }
    }
}