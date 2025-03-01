using Microsoft.Data.Sqlite;
using VSCode.Memo.Domain.Entities;
using VSCode.Memo.Domain.Repositories;

namespace VSCode.Memo.Infrastructure.Sqlite
{
    public class WeatherSqlite : IWeatherRepository
    {
        public WeatherEntity? GetLatest(int areaId)
        {
            var sql = @"
                SELECT
                    AreaId,
                    DataDate,
                    Condition,
                    Temperature
                FROM
                    Weather
                WHERE
                    AreaId = @AreaId
                ORDER BY DataDate DESC
                LIMIT 1
            ";

            using var connection = new SqliteConnection(SqliteHelper.ConnectionString);
            using var command = new SqliteCommand(sql, connection);
            connection.Open();
            command.Parameters.AddWithValue("@AreaId", areaId);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                return new WeatherEntity(
                    Convert.ToInt32(reader["AreaId"]),
                    Convert.ToDateTime(reader["DataDate"]),
                    Convert.ToInt32(reader["Condition"]),
                    Convert.ToSingle(reader["Temperature"])
                );
            }

            return null;
        }
    }
}