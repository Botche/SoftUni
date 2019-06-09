using System;
using System.IO;
using System.IO.Compression;

namespace _06._ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string picPath = "copyMe.png";
            string zipFile = "../../../newResult.zip";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (var archive = ZipFile.Open(zipFile, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(picPath, Path.GetFileName(picPath));
            }
            using (var archive=ZipFile.OpenRead(zipFile))
            {
                archive.ExtractToDirectory(path);
            }
        }
    }
}
