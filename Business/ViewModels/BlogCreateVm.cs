using FluentValidation;

namespace Business.ViewModels
{
    public class BlogCreateVm
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImgUrl { get; set; }
        public IFormFile? ImgFile { get; set; }
    }
    public class BlogCreateVmValidation : AbstractValidator<BlogCreateVm>
    {
        public BlogCreateVmValidation()
        {
            RuleFor(b=>b.Title).NotNull().WithMessage("Title Bos olammaz");
            RuleFor(b=>b.Description).NotNull().WithMessage("Description Bos olammaz");
        }
    }
}
