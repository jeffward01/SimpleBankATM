using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleBankATM.Data.Infrastructure;
using SimpleBankATM.Models;
using System.Threading.Tasks;

namespace SimpleBankATM.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        //private readonly DataContext _propertyButlerContext;
        //private readonly UserManager<IdentityUser> _userManager;

        //public AuthRepository()
        //{
        //    _propertyButlerContext = new DataContext();
        //    _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_propertyButlerContext));
        //}

        //public async Task<IdentityResult> RegisterUser(UserModel userModel)
        //{
        //    IdentityUser user = new IdentityUser();
        //    user.UserName = userModel.UserName;

        //    var result = await _userManager.CreateAsync(user, userModel.Password);
        //    return result;
        //}

        //public async Task<IdentityUser> FindUser(string userName, string password)
        //{
        //    IdentityUser user = await _userManager.FindAsync(userName, password);

        //    return user;
        //}

        //public void Dispose()
        //{
        //    _propertyButlerContext.Dispose();
        //    _userManager.Dispose();
        //}
    }
}