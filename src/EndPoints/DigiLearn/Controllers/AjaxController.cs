using Common.L2.Application.FileUtil.Interfaces;
using Common.L2.Application.FileUtil.Services;
using CoreModule.Facade.Category;
using Microsoft.AspNetCore.Mvc;

namespace DigiLearn.Controllers
{
    public class AjaxController : Controller
    {
        private readonly ICourseCategoryFacade _categoryFacade;
        private readonly IFileService _fileService;
        public AjaxController(ICourseCategoryFacade categoryFacade, IFileService fileService)
        {
            _categoryFacade = categoryFacade;
            _fileService = fileService;
        }

        [Route("/ajax/getCategoryChildren")]
        public async Task<IActionResult> GetCategoryChildren(Guid id)
        {
            var text = "";
            var children = await _categoryFacade.GetChildren(id);
            foreach (var item in children)
            {
                text += $"<option value='{item.Id}'>{item.Title}</option>";
            }
            return new ObjectResult(text);
        }


        [Route("/Upload/ImageUploader")]
        public async Task<IActionResult> UploadImage(IFormFile upload)
        {
            if (upload == null)
            {
                return null;
            }
            var fileName = await _fileService.SaveFileAndGenerateName(upload, "wwwroot/images/upload");

            var url = $"/images/upload/{fileName}";
            return Json(new { uploaded = true, url });
        }
    }
}
