using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.appData
{
    public class Userr
    {
        public List<Users> U()
        {
			try
			{
				var user = ConDB.context.Users.ToList();
				return user;
			}
			catch (Exception ex)
			{
                throw new Exception($"{ex.Message}");
            }
        }
        public Users CreateNewUser(string username, string password, int rolID)
		{
			try
			{
				Users userr = new Users()
				{
                    Username = username,
                    Password = password,
                    RoleID = rolID,


                };
				ConDB.context.Users.Add(userr);
				ConDB.context.SaveChanges();
				return userr;
			}
			catch (Exception ex){ throw new Exception($"{ex.Message}");}
		}
        public Users SingUp(string userName, string pass)
        {
            try
            {
                var user = ConDB.context.Users.Where(x => x.Username == userName && x.Password == pass).First();
                return user;
            }
            catch (Exception ex) { throw new Exception($"{ex.Message}"); }
        }
    }
	
}
