using MauiApp8.Common;
using MauiApp8.Models;
namespace MauiApp8.Services;


public interface IUserService
{
    Task<ServiceResult<List<UserDisplayModel>>> GetAllUsersAsync();
    Task<ServiceResult<UserDisplayModel>> GetUserByIdAsync(int id);
    Task<ServiceResult<UserDisplayModel>> AddUserAsync(UserViewModel viewModel);
    Task<ServiceResult<UserDisplayModel>> UpdateUserAsync(int id, UserViewModel viewModel);
    Task<ServiceResult<bool>> DeleteUserAsync(int id);
}