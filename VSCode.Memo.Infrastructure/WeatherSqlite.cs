using Microsoft.Data.Sqlite;
using VSCode.Memo.Domain.Entities;
using VSCode.Memo.Domain.Repositories;

namespace VSCode.Memo.Infrastructure
{
    public class WeatherSqlite : IWeatherRepository
    {
        private readonly string _connectionString = @"Data Source=/Users/gunj0/vscode/cs/VSCode.Memo/DB/VSCode.Memo.db";

        public WeatherEntity GetLatest(int areaId)
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

            var entity = new WeatherEntity();
            using (var connection = new SqliteConnection(_connectionString))
            using (var command = new SqliteCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@AreaId", areaId);

                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    entity.AreaId = reader.GetInt32(0);
                    entity.DataDate = reader.GetDateTime(1);
                    entity.Condition = reader.GetInt32(2);
                    entity.Temperature = reader.GetFloat(3);
                }
            }

            return entity;
        }
    }
}