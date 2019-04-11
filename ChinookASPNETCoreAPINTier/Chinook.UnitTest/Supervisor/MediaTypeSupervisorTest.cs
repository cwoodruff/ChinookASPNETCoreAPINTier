using Chinook.MockData.Repositories;

namespace Chinook.UnitTest.Supervisor
{
    public class MediaTypeSupervisorTest
    {
        private ArtistRepository _repo;

        public MediaTypeSupervisorTest()
        {
            _repo = new ArtistRepository();
        }
    }
}