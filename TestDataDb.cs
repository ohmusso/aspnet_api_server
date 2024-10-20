using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    class TestDataDb : DbContext
    {
        public TestDataDb(DbContextOptions<TestDataDb> options)
            : base(options) {
        }

        public DbSet<TestData> TestDatas => Set<TestData>();

        // never called
        //protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        //  modelBuilder.Entity<TestData>().HasData(
        //    new TestData { Id = 1, Name = "abc", IsComplete = false },
        //    new TestData { Id = 2, Name = "def", IsComplete = true },
        //    new TestData { Id = 3, Name = "ghi", IsComplete = false }
        //);
    }
}
