namespace BggCoreSdk.Model
{
    public class BoardGameName
    {
        public string Value { get; set; }

        public bool IsPrimary { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}