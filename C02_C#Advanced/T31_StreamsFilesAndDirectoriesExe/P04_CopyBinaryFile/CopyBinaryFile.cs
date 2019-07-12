using System;
using System.IO;

namespace _04._CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string originalPath = "copyMe.png";
            string copiedPath = "copyMe-copy.png";

            using (FileStream streamReader=new FileStream(originalPath,FileMode.Open))
            {
                using (FileStream streamWriter = new FileStream(copiedPath, FileMode.Create))
                {
                    while (true)
                    {
                        byte[] byteArray = new byte[4096];
                        var size = streamReader.Read(byteArray, 0, byteArray.Length);

                        if (size==0)
                        {
                            break;
                        }
                        streamWriter.Write(byteArray, 0, size);
                    }
                }
            }
        }
    }
}
