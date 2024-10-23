﻿using Common.L2.Application.FileUtil;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Common.L2.Application.Validation.CustomValidation.IFormFile
{
	public class FileImageAttribute : ValidationAttribute, IClientModelValidator
	{
		public override bool IsValid(object? value)
		{
			var fileInput = value as Microsoft.AspNetCore.Http.IFormFile;
			if (fileInput == null)
				return true;

			return fileInput.IsImage();
		}

		public void AddValidation(ClientModelValidationContext context)
		{
			if (!context.Attributes.ContainsKey("data-val"))
				context.Attributes.Add("data-val", "true");
			context.Attributes.Add("accept", "image/*");
			context.Attributes.Add("data-val-fileImage", ErrorMessage);
		}
	}
	static class Validation
	{
        public static bool IsImage(this Microsoft.AspNetCore.Http.IFormFile file)
        {
            if (string.IsNullOrEmpty(file.FileName)) return false;
            var path = Path.GetExtension(file.FileName);
            path = path.ToLower();
            if (path == ".jpg" || path == ".png" || path == ".bmp" || path == ".svg" || path == ".jpeg" ||
                path == ".webp")
            {
                return true;
            }

            return false;
        }
    }
}