using MyBlogApi.Domain;
using MyBlogApi.Dto;
using MyBlogApi.Extensions;
using MyBlogApi.Infrastructure;
using MyBlogApi.Infrastructure.Data.UoW;
using static MyBlogApi.Infrastructure.Data.IRepository;

namespace MyBlogApi.Services
{
    public class PostService : IService<Post, PostDto>
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IRepository<Post> postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public List<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public int Create(PostDto postDto)
        {
            if (postDto == null)
            {
                throw new Exception($"{nameof(postDto)} not found");
            }

            Post postEntity = postDto.ConvertToPosts();

            int id = _postRepository.Create(postEntity);
            _unitOfWork.SaveEntitiesAsync();

            return id;
        }

        public void Update(PostDto postDto)
        {
            if (postDto == null)
            {
                throw new Exception($"{nameof(postDto)} not found");
            }
            Post post = postDto.ConvertToPosts();

            _postRepository.Update(post);
            _unitOfWork.SaveEntitiesAsync();
        }

        public void Delete(int Id)
        {
            Post post = _postRepository.GetById(Id);
            if (post == null)
            {
                throw new Exception($"{nameof(post)} not found, #id - {Id}");
            }
            _postRepository.Delete(post);
            _unitOfWork.SaveEntitiesAsync();
        }

        public Post GetById(int Id)
        {
            Post post = _postRepository.GetById(Id);
            if (post == null)
            {
                throw new Exception($"{nameof(post)} not found, #id - {Id}");
            }

            return post;
        }
    }
}
