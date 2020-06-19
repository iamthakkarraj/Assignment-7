using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces {

    public interface IAuthenticationServices {

        bool SignUp(SignUpModel user);

        bool VerifyUser(LoginModel user);

        bool VerifyCredentials(LoginModel user);

    }

}