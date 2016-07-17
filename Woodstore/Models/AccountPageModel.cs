using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woodstore.Models
{
   public class AccountPageModel
    {
        public AccountModel Account { get; set; }

        public AccountPageModel(int id)
        {
            //Account = DataBaseHandler.GetAccountByID(id);
        }
        public AccountPageModel()
        { }
    }
}
