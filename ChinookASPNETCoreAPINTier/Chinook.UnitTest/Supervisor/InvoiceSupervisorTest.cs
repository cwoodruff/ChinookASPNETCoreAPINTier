using Chinook.MockData.Repositories;

namespace Chinook.UnitTest.Supervisor
{
    public class InvoiceSupervisorTest
    {
        private ArtistRepository _repo;

        public InvoiceSupervisorTest()
        {
            _repo = new ArtistRepository();
        }
    }
}