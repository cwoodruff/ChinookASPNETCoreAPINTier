namespace Chinook.Domain.DbInfo
{
    public class DbInfo: IDbInfo
    {
        public string ConnectionStrings { get; }

        public DbInfo(string connectionStrings) => ConnectionStrings = connectionStrings;
    }
}