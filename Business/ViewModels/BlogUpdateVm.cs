using FluentValidation;

namespace Business.ViewModels
{
    public class BlogUpdateVm:BaseEntityVm
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImgUrl { get; set; }
        public IFormFile? ImgFile { get; set; }
    }
    public class BlogUpdateVmValidation : AbstractValidator<BlogUpdateVm>
    {
        public BlogUpdateVmValidation()
        {
            RuleFor(b => b.Title).NotNull().WithMessage("Title Bos olammaz");
            RuleFor(b => b.Description).NotNull().WithMessage("Description Bos olammaz");
        }
    }
}
