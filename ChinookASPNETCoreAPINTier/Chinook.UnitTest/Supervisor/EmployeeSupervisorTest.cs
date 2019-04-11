using Chinook.MockData.Repositories;

namespace Chinook.UnitTest.Supervisor
{
    public class EmployeeSupervisorTest
    {
        private ArtistRepository _repo;

        public EmployeeSupervisorTest()
        {
            _repo = new ArtistRepository();
        }
    }
}