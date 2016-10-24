namespace SimpleBankATM.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        //private readonly DataContext _propertyButlerContext;
        //private readonly UserManager<IdentityUser> _userManager;

        //public AuthRepository()
        //{
        //    _propertyButlerContext = new DataContext();
        //}
        //USE USING STATEMENTS HERE UNTIL AUTOFAC dbContext is refactored.  Error earlier when autofac managed dbContext,
        //Context was not being disposed and was delivering old data not in sync w/ db
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