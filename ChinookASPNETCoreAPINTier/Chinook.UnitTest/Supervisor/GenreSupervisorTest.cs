using Chinook.MockData.Repositories;

namespace Chinook.UnitTest.Supervisor
{
    public class GenreSupervisorTest
    {
        private ArtistRepository _repo;

        public GenreSupervisorTest()
        {
            _repo = new ArtistRepository();
        }
    }
}