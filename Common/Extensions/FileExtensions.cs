
namespace EmailService.Extensions
{
    public static class FileExtensions
    {

        public static string GetSubFolderPath(string parentPath,string subFolderName)
        {
            return Path.Combine(parentPath, subFolderName);
        }

        public static string GetSubFolderFilePath(
            string parentFolderPath,
            string subFolderName,
            string fileName)
        {
            var subFolderPath = GetSubFolderPath(parentFolderPath,subFolderName);
            var filePath = Path.Combine(parentFolderPath,subFolderPath,fileName);
            return filePath;
        }


        public static string GetParentFolderPath(string directoryName)
        {
            var currentFolderPath = Directory.GetCurrentDirectory();
            var parentDir = Directory.GetParent(currentFolderPath);

            while (parentDir!.Name != directoryName)
            {
                parentDir = parentDir.Parent;
            }

            string baseWrapperFolderPath = parentDir.FullName;
            return baseWrapperFolderPath;
        }
    }
}
