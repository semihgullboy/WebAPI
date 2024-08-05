using Business.Constants;
using Core.Utilities.Results;
using Microsoft.Extensions.Configuration;
using System.DirectoryServices;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Business.Constants;
using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.Authentication;
using ViewModels;

namespace TekhnelogosOkr.Business.Concrete
{
    public class LdapAuthenticationManager : IAuthenticationService
    {
        private readonly string ldapPath;
        private readonly string ldapUser;
        private readonly string ldapPassword;

        public LdapAuthenticationManager(IConfiguration configuration)
        {
            ldapPath = configuration.GetSection("LdapSettings:Path").Value;
            ldapUser = configuration.GetSection("LdapSettings:Username").Value;
            ldapPassword = configuration.GetSection("LdapSettings:Password").Value;
        }

        public async Task<IResult> Login(UserLoginViewModel user)
        {
            try
            {
                using (var ldapConnection = new DirectoryEntry($"LDAP://{ldapPath}", ldapUser, ldapPassword))
                {
                    ldapConnection.RefreshCache();
                    ldapConnection.AuthenticationType = AuthenticationTypes.Secure;

                    using (var searcher = new DirectorySearcher(ldapConnection))
                    {
                        searcher.Filter = $"(&(objectClass=user)(mail={user.Email}))";
                        searcher.PropertiesToLoad.Add("distinguishedName");

                        SearchResult searchResult = searcher.FindOne();

                        if (searchResult != null)
                        {
                            var distinguishedName = searchResult.Properties["distinguishedName"].OfType<string>().FirstOrDefault();
                            if (distinguishedName != null)
                            {
                                return await AuthenticateUser(distinguishedName, user.Password);
                            }
                            else
                            {
                                return new ErrorResult(Messages.UserNotFound);
                            }
                        }
                        else
                        {
                            return new ErrorResult(Messages.UserNotFound);
                        }
                    }
                }
            }
            catch (COMException comEx)
            {
                return new ErrorResult($"{Messages.ComException} {comEx.Message} (Error Code: {comEx.ErrorCode})");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"{Messages.GeneralException} {ex.Message}");
            }
        }

        private async Task<IResult> AuthenticateUser(string distinguishedName, string password)
        {
            try
            {
                using (var userEntry = new DirectoryEntry($"LDAP://{distinguishedName}", null, password))
                {
                    userEntry.AuthenticationType = AuthenticationTypes.Secure;

                    object nativeObject = userEntry.NativeObject;
                    if (nativeObject != null)
                    {
                        return new SuccessResult(Messages.UserAuthenticated);
                    }
                    else
                    {
                        return new ErrorResult(Messages.UserAuthenticationFailed);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ErrorResult($"{Messages.GeneralException} {ex.Message}");
            }
        }
    }
}
