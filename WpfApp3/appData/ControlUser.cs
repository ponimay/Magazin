using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.appData
{
    public class ControlUser
    {
        public List<Roles> GetRole()
        {
            try
            {
                var rol = ConDB.context.Roles.ToList();
                return rol;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
