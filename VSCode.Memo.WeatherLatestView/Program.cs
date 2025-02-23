using VSCode.Memo.WeatherLatestView;

var data = GetWeatherLatestData();
Console.WriteLine(data.AreaId);
Console.WriteLine(data.DataDate);
Console.WriteLine(data.Condition);
Console.WriteLine(data.Temperature);

static Dto GetWeatherLatestData()
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

  return new Dto
  {
    AreaId = 1,
    DataDate = DateTime.Parse("2025-02-23"),
    Condition = 1,
    Temperature = 20.123f,
  };
}