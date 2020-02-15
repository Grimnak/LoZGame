namespace LoZClone
{
    public interface ICommand
    {
        void execute();

        int Priority { get; }
    }
}