namespace NLayerArch.Project.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task SaveChangesAsync();
    }
}
