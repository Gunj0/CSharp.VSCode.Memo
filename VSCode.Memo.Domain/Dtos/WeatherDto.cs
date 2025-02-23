namespace VSCode.Memo.Domain.Dtos
{
    public class WeatherDto
    {
        public int AreaId { get; set; }

        public DateTime DataDate { get; set; }

        public int Condition { get; set; }

        public float Temperature { get; set; }
    }
}