using OnlineLibraryProject.Application.Services;

namespace OnlineLibraryProject.Application.Abstraction.AbstractHandlers
{
    public abstract class CategoryHandler
    {
        public ICategoryService _categoryService { get; set; }

        protected CategoryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
    }
}
