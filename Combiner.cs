using System;
using System.IO;

class FileBinder
{
    static void Main()
    {
        Console.Write("bin files: ");
        string outputDirectory = Console.ReadLine();

        Console.Write("Output: ");
        string mergedFilePath = Console.ReadLine();

        BindFiles(outputDirectory, mergedFilePath);
    }

    static void BindFiles(string outputDirectory, string mergedFilePath)
    {
        try
        {
            using (FileStream mergedFileStream = new FileStream(mergedFilePath, FileMode.Create))
            {
                int fileNumber = 1;
                string inputFilePath;

                do
                {
                    inputFilePath = Path.Combine(outputDirectory, $"part_{fileNumber}.bin");

                    if (File.Exists(inputFilePath))
                    {
                        byte[] buffer = File.ReadAllBytes(inputFilePath);
                        mergedFileStream.Write(buffer, 0, buffer.Length);
                        fileNumber++;
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                Console.WriteLine("Fertig");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler: {ex.Message}");
        }
    }
}
