namespace VSCode.Memo.Domain.Entities
{
    public class WeatherEntity
    {
        public int AreaId { get; set; }

        public DateTime DataDate { get; set; }

        public int Condition { get; set; }

        public float Temperature { get; set; }
    }
}