using DAL.Database.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces {

    public interface IAuthenticationRepository {
        
        bool SignUp(User user);

        bool VerifyUser(User user);

        bool VerifyCredentials(User user);
        
    }

}