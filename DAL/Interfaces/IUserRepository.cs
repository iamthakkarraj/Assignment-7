using DAL.Database.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces {

    public interface IUserRepository {

        bool SignUp(User user);

        bool VerifyUser(User user);

        bool VerifyCredentials(User user);

        int GetUserId(string email);

        List<Country> GetCountries();

        List<State> GetStates(int id);

        List<City> GetCities(int id);

    }

}