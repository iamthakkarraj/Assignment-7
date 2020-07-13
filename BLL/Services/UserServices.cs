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

    public class UserServices : IUserServices {

        private IUserRepository UserRepository;

        public UserServices() {
            UserRepository = new UserRepository();
        }

        public bool SignUp(SignUpModel user) {
            user.Password = CryptoServices.EnryptString(user.Password);
            return UserRepository.SignUp(ModelMapperServices.Map<SignUpModel, User>(user));
        }

        public bool VerifyCredentials(LoginModel user) {
            user.Password = CryptoServices.EnryptString(user.Password);
            return UserRepository.VerifyCredentials(ModelMapperServices.Map<LoginModel, User>(user));
        }

        public bool VerifyUser(LoginModel user) {
            throw new NotImplementedException();
        }

        public int GetUserId(string email) {
            return UserRepository.GetUserId(email);
        }

        public List<CityModel> GetCities(int id) {
            List<CityModel> destination = new List<CityModel>();            
            foreach (City city in UserRepository.GetCities(id)) {
                destination.Add(ModelMapperServices.Map<City, CityModel>(city));
            }
            return destination;
        }

        public List<StateModel> GetStates(int id) {
            List<StateModel> destination = new List<StateModel>();            
            foreach (State state in UserRepository.GetStates(id)) {
                destination.Add(ModelMapperServices.Map<State, StateModel>(state));
            }

            return destination;
        }

        public List<CountryModel> GetCountries() {
            List<CountryModel> destination = new List<CountryModel>();            
            foreach (Country country in UserRepository.GetCountries()) {
                destination.Add(ModelMapperServices.Map<Country, CountryModel>(country));
            }
            return destination;
        }        

    }

}