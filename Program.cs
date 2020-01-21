using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main(string[] args)
    {
        //string zipPath = @".\Arquivo.zip";
        Console.WriteLine("Insira o arquivo a ser extraido :");
        string zipPath = Console.ReadLine();
        zipPath = Path.GetFullPath(zipPath);

        Console.WriteLine("Insira o diretório para extração dos arquivos :");
        string extractPath = Console.ReadLine();

        using (ZipArchive archive = ZipFile.OpenRead(zipPath))
        {
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                try
                {
                    string diretorio = Path.Combine(extractPath, Path.GetDirectoryName(entry.FullName));


                    if (!Directory.Exists(diretorio))
                        Directory.CreateDirectory(diretorio);

                    string arquivoPath = Path.Combine(diretorio, entry.Name);
                    entry.ExtractToFile(arquivoPath);

                }
                catch (Exception ex)
                {

                    //O objetivo aqui era realmente apenas escrever o arquivo que gerou erro
                    Console.WriteLine($"O arquivo {entry.FullName} gerou erro ao extrair : {ex.Message}");
                }

            }
        }
    }
}