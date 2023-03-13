namespace FastFood.Services.Data;

using FastFood.Core.ViewModels.Positions;

public interface IPositionsService
{
    Task CreateAsync(CreatePositionInputModel inputModel);

    Task<IEnumerable<PositionsAllViewModel>> GetAllAsync();
}
