namespace mLogger.PathCreation
{
    public class PathCreator : IPathCreator
    {
        public string FolderPath { get; set; }

        public PathCreator(string folderPath)
        {
            FolderPath = folderPath;
        }

        public void EnsurePathExsists(string subFolder)
        {
            if (!PathExsists(subFolder))
            {
                CreatePath(subFolder);
            }
        }

        private void CreatePath(string subFolder)
        {
            var fullPath = Path.Combine(FolderPath, subFolder);
            Directory.CreateDirectory(fullPath);

        }

        private bool PathExsists(string subFolder)
        {
            var fullPath = Path.Combine(FolderPath, subFolder);

            return Directory.Exists(fullPath);
        }
    }
}
