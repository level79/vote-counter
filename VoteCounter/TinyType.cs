namespace VoteCounter
{
    public class TinyType<T>
    {
        public readonly T Value;
        public TinyType (T value) {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is TinyType<T> other &&
                   Value.Equals(other.Value);
        }
    }
}