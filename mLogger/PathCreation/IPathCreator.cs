namespace mLogger.PathCreation
{
    public interface IPathCreator
    {
        /// <summary>
        /// Base output path
        /// </summary>
        string FolderPath { get; set; }
        /// <summary>
        /// Ensure creation of folder Folderpath+subfolder
        /// </summary>
        /// <param name="subFolder">subfolder to create</param>
        void EnsurePathExsists(string subFolder);

    }
}