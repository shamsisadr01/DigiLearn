using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Common.L2.Application.FileUtil.Interfaces
{
	public interface IFileService
	{
        void DeleteDirectory(string directoryPath);
        void DeleteFile(string path, string fileName);
        void DeleteFile(string filePath);
        Task SaveFile(IFormFile file, string directoryPath);
        Task SaveFile(IFormFile file, string directoryPath, string fileName);
        Task<string> SaveFileAndGenerateName(IFormFile file, string directoryPath);
    }
}
