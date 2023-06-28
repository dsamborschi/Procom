using Microsoft.EntityFrameworkCore;

namespace Procom.Api
{
    internal class ProcomContext:DbContext
    {
        public ProcomContext(DbContextOptions<ProcomContext> options) : base(options) { }
    }
}