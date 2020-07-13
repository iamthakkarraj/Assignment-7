using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Database.EDMX;
using System.Threading.Tasks;

namespace DAL.Repository {

    public class UserRepository : IUserRepository {

        CSharpAssignmentEntities DBContext;

        public UserRepository() {
            DBContext = new CSharpAssignmentEntities();
        }

        public bool SignUp(User user) {
            try {
                DBContext.Users.Add(user);
                DBContext.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }

        public bool VerifyCredentials(User user) {
            return (DBContext
                        .Users
                        .Where(x => x.Email == user.Email)
                        .Where(x => x.Password == user.Password)
                        .Count() >= 1);
        }

        public bool VerifyUser(User user) {
            throw new NotImplementedException();
        }

        public int GetUserId(string email) {
            return DBContext.Users.Where(x => x.Email == email).FirstOrDefault().UserId;
        }

        public List<Country> GetCountries() {
            return DBContext.Countries.OrderBy(x => x.Name).ToList();
        }

        public List<State> GetStates(int id) {
            return DBContext.States.Where(x => x.CountryId == id).OrderBy(x => x.Name).ToList();
        }

        public List<City> GetCities(int id) {
            return DBContext.Cities.Where(x => x.StateId == id).OrderBy(x => x.Name).ToList();
        }

    }

}