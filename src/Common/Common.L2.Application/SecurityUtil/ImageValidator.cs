using System.Drawing;
using Common.L2.Application.FileUtil;
using Microsoft.AspNetCore.Http;

namespace Common.L2.Application.SecurityUtil
{
	public static class ImageValidator
	{
		public static bool IsImage(this IFormFile? file)
		{
			if (file == null) return false;
            return FileValidation.IsValidImageFile(file.FileName);
        }
	}
}
