using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using VSCode.Memo.Domain.Dtos;
using VSCode.Memo.Domain.Repositories;

namespace VSCode.Memo.Infrastructure
{
    public class WeatherSqlite : IWeatherRepository
    {
        private readonly string _connectionString = @"Data Source=/Users/gunj0/vscode/cs/VSCode.Memo/DB/VSCode.Memo.db";

        public WeatherDto GetLatest(int areaId)
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

            var dto = new WeatherDto();
            using (var connection = new SqliteConnection(_connectionString))
            using (var command = new SqliteCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@AreaId", areaId);

                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    dto.AreaId = reader.GetInt32(0);
                    dto.DataDate = reader.GetDateTime(1);
                    dto.Condition = reader.GetInt32(2);
                    dto.Temperature = reader.GetFloat(3);
                }
            }

            return dto;
        }
    }
}