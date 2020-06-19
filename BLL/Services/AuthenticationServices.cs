using BLL.Interfaces;
using BLL.ViewModels;
using DAL.Interfaces;
using DAL.Repository;
using DAL.Database.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services {

    public class AuthenticationServices : IAuthenticationServices {

        private IAuthenticationRepository AuthenticationRepository;

        public AuthenticationServices() {
            AuthenticationRepository = new AuthenticationRepository();
        }

        public bool SignUp(SignUpModel user) {
            return AuthenticationRepository.SignUp(ModelMapperServices.Map<SignUpModel, User>(user));
        }

        public bool VerifyCredentials(LoginModel user) {
            return AuthenticationRepository.VerifyCredentials(ModelMapperServices.Map<LoginModel, User>(user));
        }

        public bool VerifyUser(LoginModel user) {
            throw new NotImplementedException();
        }

    }

}