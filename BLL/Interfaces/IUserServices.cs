using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces {

    public interface IUserServices {

        bool SignUp(SignUpModel user);

        bool VerifyUser(LoginModel user);

        bool VerifyCredentials(LoginModel user);

        int GetUserId(string email);

        List<CountryModel> GetCountries();

        List<StateModel> GetStates(int id);

        List<CityModel> GetCities(int id);


    }

}