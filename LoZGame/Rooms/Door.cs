namespace LoZClone
{
    /*
     * The Door struct is separated from Room.cs to prevent file bloat.
     */
    public partial class Room
    {
        public struct Door
        {
            private string location;
            private string kind;

            public Door(string loc, string k)
            {
                this.location = loc;
                this.kind = k;
            }
        }
    }
}
