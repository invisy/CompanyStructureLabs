namespace TRPZ.Interfaces
{
    public interface ILoadSave
    {
        void Save(string path, ICompany company);
        ICompany Load(string path);
    }
}