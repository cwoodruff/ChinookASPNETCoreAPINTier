using Chinook.MockData.Repositories;

namespace Chinook.UnitTest.Supervisor
{
    public class TrackSupervisorTest
    {
        private ArtistRepository _repo;

        public TrackSupervisorTest()
        {
            _repo = new ArtistRepository();
        }
    }
}