using Microsoft.Data.Sqlite;
using VSCode.Memo.UI;

var data = GetWeatherLatestData();
Console.WriteLine($"{data.AreaId} {data.DataDate} {data.Condition} {RoundString(data.Temperature, 2)}");

static Dto GetWeatherLatestData(int areId = 1)
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

  var connectionString = @"Data Source=/Users/gunj0/vscode/cs/VSCode.Memo/DB/DDD.db";

  var dto = new Dto();
  using (var connection = new SqliteConnection(connectionString))
  using (var command = new SqliteCommand(sql, connection))
  {
    connection.Open();
    command.Parameters.AddWithValue("@AreaId", areId);

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

static string RoundString(float value, int decimalPoint)
{
  var temp = Convert.ToSingle(Math.Round(value, decimalPoint));
  return temp.ToString($"F{decimalPoint}");
}