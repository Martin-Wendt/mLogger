using mLogger.PathCreation;
using System.IO;
using Xunit;

namespace mLogger.Test
{
    public class PathCreatorShould
    {
        [Fact]
        public void CreateFolders()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory() + @"\tester");
            var sut = new PathCreator(path);

            sut.EnsurePathExsists(path);

            Assert.True(Directory.Exists(Path.Combine(path)));

            //clean up
            Directory.Delete(path, true);
            Assert.False(Directory.Exists(Path.Combine(path)));


        }

    }
}
