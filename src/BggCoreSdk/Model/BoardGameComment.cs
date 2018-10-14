namespace BggCoreSdk.Model
{
    public class BoardGameComment
    {
        public string Value { get; set; }

        public string UserName { get; set; }

        public string Rating { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}