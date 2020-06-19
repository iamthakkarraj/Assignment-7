using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Database.EDMX;
using System.Threading.Tasks;

namespace DAL.Repository {

    public class AuthenticationRepository : IAuthenticationRepository {

        CSharpAssignmentEntities DBContext;        

        public AuthenticationRepository() {
            DBContext = new CSharpAssignmentEntities();
        }
        
        public bool SignUp(User user) {
            try {
                DBContext.Users.Add(user);
                DBContext.SaveChanges();
                return true;
            }catch{
                return false;
            }
        }

        public bool VerifyCredentials(User user) {
            try {
                return (DBContext
                            .Users
                            .Where(x => x.Email == user.Email)
                            .Where(x => x.Password == user.Password)
                            .Count() >= 1);            
            } catch {
                return false;
            }
        }

        public bool VerifyUser(User user) {
            throw new NotImplementedException();
        }

    }

}