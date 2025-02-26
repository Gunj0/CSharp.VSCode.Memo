using VSCode.Memo.Domain.ValueObjects;

namespace VSCode.Memo.Domain.Entities
{
    // エンティティ
    // …データベースのテーブルに対応する
    public sealed class WeatherEntity
    {
        // 完全コンストラクタパターン
        // …初期化時にのみセットされるので、不具合が混入しにくくなる
        public WeatherEntity(int areaId, DateTime dataDate, int condition, float temperature)
        {
            AreaId = areaId;
            DataDate = dataDate;
            Condition = condition;
            // ここでバリューオブジェクトを生成
            Temperature = new Temperature(temperature);
        }

        public int AreaId { get; }

        public DateTime DataDate { get; }

        public int Condition { get; }

        public Temperature Temperature { get; }

        // データに全体に対するロジックは、エンティティに持たせる
        public bool IsOK()
        {
            if (DataDate < DateTime.Now.AddMonths(-1))
            {
                if (Temperature.Value < 10)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
