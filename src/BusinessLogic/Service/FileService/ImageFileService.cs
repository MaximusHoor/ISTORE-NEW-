using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.FileService
{
    public class ImageFileService
    {
        private List<string> _alphabet = new List<string>() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L",
                "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        private string _mainCatalog;
        public ImageFileService(string saveDirecroty)
        {
            _mainCatalog = saveDirecroty;
        }

        public async Task Save(IFormFileCollection images)
        {            
            if (Directory.GetDirectories($"{_mainCatalog}").Length == 0)
            {
                Directory.CreateDirectory($"{_mainCatalog}{_alphabet[0]}\\");
                Directory.CreateDirectory($"{_mainCatalog}{_alphabet[0]}\\{_alphabet[0]}{_alphabet[0]}\\");                
            }

            foreach (var item in images)
            {
                var directory = GetLastFolder();
                var filesInLastFolders = Directory.GetFiles(directory);

                if (filesInLastFolders.Length <= 99) 
                {
                    await SaveFile(item, directory);
                }
                else
                {
                    var name = directory.Substring(directory.LastIndexOf("\\") + 1);

                    var letterIndexOne= _alphabet.IndexOf(name[0].ToString());
                    var letterIndexTwo = _alphabet.IndexOf(name[1].ToString());

                    if (letterIndexTwo == _alphabet.Count - 1) 
                    {
                        Directory.CreateDirectory($"{_mainCatalog}{_alphabet[letterIndexOne]}\\{_alphabet[letterIndexOne]}{_alphabet[letterIndexTwo + 1]}\\");

                        directory = GetLastFolder();

                        await SaveFile(item, directory);
                    }
                    else
                    {
                        Directory.CreateDirectory($"{_mainCatalog}{_alphabet[letterIndexOne + 1]}\\");
                        Directory.CreateDirectory($"{_mainCatalog}{_alphabet[letterIndexOne + 1]}\\{_alphabet[letterIndexOne + 1]}{_alphabet[0]}\\");

                        directory = GetLastFolder();

                        await SaveFile(item, directory);
                    }
                }
            }
        }


        public async Task<string> Save(IFormFile image)
        {
            string filePath = "";

            if (Directory.GetDirectories($"{_mainCatalog}").Length == 0)
            {
                Directory.CreateDirectory($"{_mainCatalog}{_alphabet[0]}\\");
                Directory.CreateDirectory($"{_mainCatalog}{_alphabet[0]}\\{_alphabet[0]}{_alphabet[0]}\\");
            }

            
                var directory = GetLastFolder();
                var filesInLastFolders = Directory.GetFiles(directory);

                if (filesInLastFolders.Length <= 99)
                {
                   filePath = await SaveFile(image, directory);
                }
                else
                {
                    var name = directory.Substring(directory.LastIndexOf("\\") + 1);

                    var letterIndexOne = _alphabet.IndexOf(name[0].ToString());
                    var letterIndexTwo = _alphabet.IndexOf(name[1].ToString());

                    if (letterIndexTwo == _alphabet.Count - 1)
                    {
                        Directory.CreateDirectory($"{_mainCatalog}{_alphabet[letterIndexOne]}\\{_alphabet[letterIndexOne]}{_alphabet[letterIndexTwo + 1]}\\");

                        directory = GetLastFolder();

                        filePath = await SaveFile(image, directory);
                    }
                    else
                    {
                        Directory.CreateDirectory($"{_mainCatalog}{_alphabet[letterIndexOne + 1]}\\");
                        Directory.CreateDirectory($"{_mainCatalog}{_alphabet[letterIndexOne + 1]}\\{_alphabet[letterIndexOne + 1]}{_alphabet[0]}\\");

                        directory = GetLastFolder();

                        filePath = await SaveFile(image, directory);
                    }
                }

            return filePath;
        }


        private string GetLastFolder()
        {
            var directory = Directory.GetDirectories(_mainCatalog);
            var lastDirectory = directory[directory.Length - 1];
            var folders = Directory.GetDirectories(lastDirectory);
            return folders[folders.Length - 1];
        }

        //private async Task SaveFile(IFormFile file, string path)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        var fileExtension = file.FileName.Substring(file.FileName.IndexOf('.'));
        //        await file.CopyToAsync(ms);
        //        var fileBytes = ms.ToArray();
        //        await File.WriteAllBytesAsync($"{path}\\{Guid.NewGuid()}{fileExtension}", fileBytes);
        //    }
        //}

        private async Task<string> SaveFile(IFormFile file, string path)
        {
            var fileExtension = file.FileName.Substring(file.FileName.IndexOf('.'));
            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                var fileBytes = ms.ToArray();
                await File.WriteAllBytesAsync($"{path}\\{Guid.NewGuid()}{fileExtension}", fileBytes);
            }

            return $"{path}\\{Guid.NewGuid()}{fileExtension}";
        }

        //private async Task<string> SaveFile(string filePath, string path)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        try
        //        {
        //            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        //            {
        //                await file.CopyToAsync(ms);
        //            }
        //        } catch(Exception ex)
        //        {

        //        }
                   
        //        var fileExtension = filePath.Substring(filePath.IndexOf('.'));               
        //        var fileBytes = ms.ToArray();
        //        await File.WriteAllBytesAsync($"{path}\\{Guid.NewGuid()}{fileExtension}", fileBytes);

        //        return $"{path}\\{Guid.NewGuid()}{fileExtension}";
        //    }
        //}
    }
}
