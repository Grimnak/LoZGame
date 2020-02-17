namespace LoZClone
{
    public interface ICommand
    {
        int Priority { get; }

        void Execute();
    }
}