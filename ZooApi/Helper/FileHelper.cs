namespace ZooApi.Helper
{
    public static class FileHelper
    {
        public static void CreateIfNotExist(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }

        }
    }
}
