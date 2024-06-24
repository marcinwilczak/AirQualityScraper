using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScraper
{
    internal class PathHelper
    {
        public static string GetProjectRootDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var directoryInfo = new DirectoryInfo(currentDirectory);

            while (directoryInfo != null && directoryInfo.Name != "bin")
            {
                directoryInfo = directoryInfo.Parent;
            }

            if (directoryInfo == null)
            {
                throw new Exception("Could not find the 'bin' directory.");
            }

            return directoryInfo.Parent.FullName;
        }
    }
}