namespace BggCoreSdk.Model
{
    public class ValueIdentifier
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}