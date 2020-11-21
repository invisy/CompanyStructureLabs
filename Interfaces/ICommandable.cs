namespace TRPZ
{
    public interface ICommandable
    {
        void AddCommander(ICommander Supervisor);
    }
}