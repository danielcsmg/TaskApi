using TaskApi.Data.Dtos;

namespace TaskApi.Data.Daos.Interfaces;

public interface ICategoryDao : IDisposable
{
    Task Add(CreateCategoryDto categoryDto);
    IList<ReadCategoryDto> Categories();
    Task Remove(string id);
}
