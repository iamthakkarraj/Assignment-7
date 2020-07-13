using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels {

    public class CityModel {

        public int CityId { get; set; }
        public string Name { get; set; }
        public Nullable<int> StateId { get; set; }        

    }

}