namespace MyBlogApi.Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _ctx;

        public UnitOfWork(Context ctx)
        {
            _ctx = ctx;
        }
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await _ctx.SaveEntitiesAsync(cancellationToken);
        }
    }
}
