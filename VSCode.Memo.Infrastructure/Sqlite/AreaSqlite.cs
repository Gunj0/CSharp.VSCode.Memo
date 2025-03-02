using Microsoft.Data.Sqlite;
using VSCode.Memo.Domain.Entities;
using VSCode.Memo.Domain.Repositories;

namespace VSCode.Memo.Infrastructure.Sqlite
{
    public sealed class AreaSqlite : IAreaRepository
    {
        public IReadOnlyList<AreaEntity> GetData()
        {
            var sql = @"
                        SELECT
                            AreaId,
                            AreaName
                        FROM
                            Areas
                    ";

            var list = new List<AreaEntity>();
            using var connection = new SqliteConnection(SqliteHelper.ConnectionString);
            using var command = new SqliteCommand(sql, connection);
            connection.Open();

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new AreaEntity(reader.GetInt32(0), reader.GetString(1)));
            }
            return list.AsReadOnly();
        }
    }
}
