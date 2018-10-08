namespace BggCoreSdk.Model
{
    public class BoardGameName
    {
        internal BoardGameName()
        {            
        }
        
        public string Value { get; set; }

        public bool IsPrimary { get; set; }

        public int? SortIndex { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}