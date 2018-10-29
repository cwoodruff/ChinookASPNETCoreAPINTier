using System;
using Chinook.MockData.Repositories;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using Chinook.Domain.Supervisor;
using JetBrains.dotMemoryUnit;
using Xunit;

namespace Chinook.UnitTest.Supervisor
{
    public class InvoiceLineSupervisorTest
    {
        private readonly ChinookSupervisor _super;
        private ArtistRepository _repo;

        public InvoiceLineSupervisorTest()
        {
            _repo = new ArtistRepository();
        }
    }
}