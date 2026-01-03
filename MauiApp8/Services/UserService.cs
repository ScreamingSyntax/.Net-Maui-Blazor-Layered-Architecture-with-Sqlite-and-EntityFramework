using MauiApp8.Common;
using MauiApp8.Data;
using MauiApp8.Entities;
using MauiApp8.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiApp8.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    // ✅ Private helper method to map Entity to DisplayModel
    private UserDisplayModel MapToDisplayModel(User user)
    {
        return new UserDisplayModel
        {
            Id = user.Id,
            Name = user.FullName,
            Email = user.Email,
        };
    }

    public async Task<ServiceResult<List<UserDisplayModel>>> GetAllUsersAsync()
    {
        try
        {
            var users = await _context.Users.ToListAsync();
            
            // ✅ Map entities to display models
            var displayModels = users.Select(MapToDisplayModel).ToList();
            
            return ServiceResult<List<UserDisplayModel>>.SuccessResult(displayModels);
        }
        catch (Exception ex)
        {
            return ServiceResult<List<UserDisplayModel>>.FailureResult($"Error retrieving users: {ex.Message}");
        }
    }

    public async Task<ServiceResult<UserDisplayModel>> GetUserByIdAsync(int id)
    {
        try
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return ServiceResult<UserDisplayModel>.FailureResult($"User with ID {id} not found");
            }
            
            // ✅ Map entity to display model
            var displayModel = MapToDisplayModel(user);
            
            return ServiceResult<UserDisplayModel>.SuccessResult(displayModel);
        }
        catch (Exception ex)
        {
            return ServiceResult<UserDisplayModel>.FailureResult($"Error retrieving user: {ex.Message}");
        }
    }

    public async Task<ServiceResult<UserDisplayModel>> AddUserAsync(UserViewModel viewModel)
    {
        try
        {
            // Business logic: Check for duplicate email
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == viewModel.Email);
            
            if (existingUser != null)
            {
                return ServiceResult<UserDisplayModel>.FailureResult($"User with email {viewModel.Email} already exists");
            }

            // ✅ Map ViewModel to Entity
            var user = new User
            {
                FullName = viewModel.Name,
                Email = viewModel.Email,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
            // ✅ Map entity to display model
            var displayModel = MapToDisplayModel(user);
            
            return ServiceResult<UserDisplayModel>.SuccessResult(displayModel);
        }
        catch (Exception ex)
        {
            return ServiceResult<UserDisplayModel>.FailureResult($"Error adding user: {ex.Message}");
        }
    }

    public async Task<ServiceResult<UserDisplayModel>> UpdateUserAsync(int id, UserViewModel viewModel)
    {
        try
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return ServiceResult<UserDisplayModel>.FailureResult($"User with ID {id} not found");
            }

            // Check for duplicate email (excluding current user)
            var duplicateEmail = await _context.Users
                .AnyAsync(u => u.Email == viewModel.Email && u.Id != id);
            
            if (duplicateEmail)
            {
                return ServiceResult<UserDisplayModel>.FailureResult($"Email {viewModel.Email} is already in use");
            }

            // ✅ Map ViewModel to Entity
            existingUser.FullName = viewModel.Name;
            existingUser.Email = viewModel.Email;
            
            await _context.SaveChangesAsync();
            
            // ✅ Map entity to display model
            var displayModel = MapToDisplayModel(existingUser);
            
            return ServiceResult<UserDisplayModel>.SuccessResult(displayModel);
        }
        catch (Exception ex)
        {
            return ServiceResult<UserDisplayModel>.FailureResult($"Error updating user: {ex.Message}");
        }
    }

    public async Task<ServiceResult<bool>> DeleteUserAsync(int id)
    {
        try
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return ServiceResult<bool>.FailureResult($"User with ID {id} not found");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            
            return ServiceResult<bool>.SuccessResult(true);
        }
        catch (Exception ex)
        {
            return ServiceResult<bool>.FailureResult($"Error deleting user: {ex.Message}");
        }
    }
}