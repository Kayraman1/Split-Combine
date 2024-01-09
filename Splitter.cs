using System;
using System.IO;

class FileSplitter
{
    static void Main()
    {
        Console.Write("FP: ");
        string filePath = Console.ReadLine();

        Console.Write("Output: ");
        string outputDirectory = Console.ReadLine();

        SplitFile(filePath, outputDirectory);
    }

    static void SplitFile(string filePath, string outputDirectory)
    {
        const int chunkSize = 25 * 1024 * 1024; // 25 MB
        byte[] buffer = new byte[chunkSize];

        using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            int bytesRead;
            int fileNumber = 1;

            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string outputFilePath = Path.Combine(outputDirectory, $"part_{fileNumber}.bin");
                using (FileStream outputFileStream = new FileStream(outputFilePath, FileMode.Create))
                {
                    outputFileStream.Write(buffer, 0, bytesRead);
                }

                fileNumber++;
            }
        }

        Console.WriteLine("Done");
    }
}
