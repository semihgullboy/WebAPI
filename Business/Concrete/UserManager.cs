using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using ViewModel;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        var user = await _userDal.GetUserByEmailAsync(email);
        return user;
    }

}
