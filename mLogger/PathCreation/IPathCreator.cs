namespace mLogger.PathCreation
{
    public interface IPathCreator
    {
        string FolderPath { get; set; }
        void EnsurePathExsists(string subFolder);
        
    }
}