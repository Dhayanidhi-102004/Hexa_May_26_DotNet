using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Partial_Sealed_Demo.Services
{
    public class FileService
    {
        private readonly string _folderPath;
        public FileService(string folderPath)
        {
            _folderPath = folderPath;
        }

        public void CreateFolderIfNotExists()
        {
            try
            {
                if (!Directory.Exists(_folderPath))
                {
                    Directory.CreateDirectory(_folderPath);
                    Console.WriteLine($"Folder Created {_folderPath}");
                }
                else
                {
                    Console.WriteLine($"Folder already Exists. : {_folderPath}");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Permission Error: Cannot Create folder.{ex.Message}");

            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Directory Error : Parent Director not found {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"IO error while creating Folder: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Unxepected error while creating folder. {ex.Message}");
            }
        }

        public void WriteToFile(string fileName, string content)
        {
            try
            {
                ValidateFileName(fileName);
                if (string.IsNullOrWhiteSpace(content))
                {
                    throw new ArgumentException("File cannot be empty.", nameof(content));
                }


                string filePath = Path.Combine(_folderPath, fileName);
                File.WriteAllText(filePath, content);
                Console.WriteLine($"File Created Succesfully : {filePath}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input Error : {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Permission Error: cannot write file : {ex.Message}");
            }
            catch (DirectoryNotFoundException ex) {
                Console.WriteLine($"Directory Error: Folder path not Found: {ex.Message}");
            }
            catch (IOException ex)
            { Console.WriteLine($"IO error while writing the Files: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Unexpected Error while writing File {ex.Message}");
            }
        }

        public string ReadFromFile(string fileName)
        {
            try
            {
                ValidateFileName(fileName);

                string filePath = Path.Combine(_folderPath, fileName);
                if (!File.Exists(filePath))
                {
                    return "File Not Found";
                }
                return File.ReadAllText(filePath);
            }
            catch (FileNotFoundException ex)
            {
                return $"File Error : {ex.Message}";
            }
            catch (UnauthorizedAccessException ex)
            {
                return $"Permission Error: cannot read file : {ex.Message}";
            }
            catch (IOException ex)
            {
                return $"IO error while reading the Files: {ex.Message}";
            }
            catch(ArgumentException ex)
            {
                return $"Input Error :{ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Unexpected Error while reading File {ex.Message}";
            }

        }

        public void AppendToFile(string fileName, string content)
        {
            try
            {
                ValidateFileName(fileName);
                if (string.IsNullOrWhiteSpace(content))
                {
                    throw new ArgumentException("File cannot be empty.", nameof(content));
                }
                string filePath = Path.Combine(_folderPath, fileName);
                File.AppendAllText(filePath, content + Environment.NewLine);
                Console.WriteLine($" Content Appended successfully: {filePath}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input Error : {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Permission Error: cannot append file : {ex.Message}");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Directory Error: Folder path not Found: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"IO error while appending the Files: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error while appending File {ex.Message}");
            }
        }

        private void ValidateFileName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("File name cannot be Empty.", nameof(fileName));
            }
            char[] invalidCharacters = Path.GetInvalidFileNameChars();
            if (fileName.Any(ch => invalidCharacters.Contains(ch)))
            {
                throw new ArgumentException("File name contains invalid characters. ", nameof(fileName));
            }
        }

    }
}
