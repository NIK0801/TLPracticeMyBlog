using MyBlogApi.Domain;
using MyBlogApi.Dto;
using MyBlogApi.Extensions;
using MyBlogApi.Infrastructure;
using MyBlogApi.Infrastructure.Data.UoW;
using static MyBlogApi.Infrastructure.Data.IRepository;

namespace MyBlogApi.Services
{
    public class TagService : IService<Tag, TagDto>
    {
        private readonly IRepository<Tag> _tagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TagService(IRepository<Tag> tagsRepository, IUnitOfWork unitOfWork)
        {
            _tagRepository = tagsRepository;
            _unitOfWork = unitOfWork;
        }

        public List<Tag> GetAll()
        {
            return _tagRepository.GetAll();
        }

        public int Create(TagDto tagDto)
        {
            if (tagDto == null)
            {
                throw new Exception($"{nameof(tagDto)} not found");
            }

            Tag tagEntity = tagDto.ConvertToTags();

            int id = _tagRepository.Create(tagEntity);
            _unitOfWork.SaveEntitiesAsync();

            return id;
        }

        public void Update(TagDto tagDto)
        {
            if (tagDto == null)
            {
                throw new Exception($"{nameof(tagDto)} not found");
            }
            Tag tag = tagDto.ConvertToTags();

            _tagRepository.Update(tag);
            _unitOfWork.SaveEntitiesAsync();
        }

        public void Delete(int Id)
        {
            Tag tag = _tagRepository.GetById(Id);
            if (tag == null)
            {
                throw new Exception($"{nameof(tag)} not found, #id - {Id}");
            }
            _tagRepository.Delete(tag);
            _unitOfWork.SaveEntitiesAsync();
        }

        public Tag GetById(int Id)
        {
            Tag tag = _tagRepository.GetById(Id);
            if (tag == null)
            {
                throw new Exception($"{nameof(tag)} not found, #id - {Id}");
            }

            return tag;
        }
    }
}
