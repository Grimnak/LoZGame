namespace LoZClone
{
    public abstract class EnumClass
    {
        protected int _id;
        protected string _name;

        public virtual int ID
        {
            get { return _id; }
        }

        public virtual string Name
        {
            get { return _name; }
        }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is EnumClass)
                return ID == (obj as EnumClass).ID;

            return base.Equals(obj);
        }

        public static bool operator ==(EnumClass left, EnumClass right)
        {
            if ((left as object) == null)
                return (right as object) == null;

            return left.Equals(right);
        }

        public static bool operator !=(EnumClass left, EnumClass right)
        {
            if ((left as object) == null)
                return (right as object) != null;

            return !left.Equals(right);
        }
    }
}