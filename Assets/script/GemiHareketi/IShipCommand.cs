namespace script.GemiHareketi
{
    public interface IShipCommand
    {
        void Execute();
        void Undo();
    }
}