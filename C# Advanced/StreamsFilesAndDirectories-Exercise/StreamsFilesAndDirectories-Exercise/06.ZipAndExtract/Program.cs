using System;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            using ZipArchive zipFile = ZipFile.Open("../../../zipFile.zip", ZipArchiveMode.Create);
            ZipArchiveEntry zipArchiveEntry = zipFile.CreateEntryFromFile("../../../copyMe.png", "copyMe.png");
        }
    }
}
