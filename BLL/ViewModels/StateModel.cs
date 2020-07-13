using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels {

    public class StateModel {

        public int StateId { get; set; }
        public string Name { get; set; }
        public Nullable<int> CountryId { get; set; }

    }

}