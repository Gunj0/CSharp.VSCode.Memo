using VSCode.Memo.Domain.Entities;

namespace VSCode.Memo.Domain.Repositories
{
    public interface IAreaRepository
    {
        IReadOnlyList<AreaEntity> GetData();
    }
}