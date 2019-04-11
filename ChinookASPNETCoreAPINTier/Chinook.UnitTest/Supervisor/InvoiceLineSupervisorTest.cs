using Chinook.MockData.Repositories;

namespace Chinook.UnitTest.Supervisor
{
    public class InvoiceLineSupervisorTest
    {
        private ArtistRepository _repo;

        public InvoiceLineSupervisorTest()
        {
            _repo = new ArtistRepository();
        }
    }
}