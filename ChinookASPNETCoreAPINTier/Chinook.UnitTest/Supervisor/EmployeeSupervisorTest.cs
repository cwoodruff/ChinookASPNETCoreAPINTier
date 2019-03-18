using System;
using Chinook.MockData.Repositories;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using Chinook.Domain.Supervisor;
using JetBrains.dotMemoryUnit;
using Xunit;

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