using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace AdConsoleMicrosoftSupport
{
    class Program
    {
        public static void Main()
        {
            List<string> lstADUsers = new List<string>();
            using (var context = new PrincipalContext(ContextType.Domain, "fractech.local"))
            // using (var context = new PrincipalContext(ContextType.Domain, null, "LDAPPATH"))
            {
                using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                {
                    foreach (var result in searcher.FindAll())
                    {
                        DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                        string usersWithName;
                        if (!String.IsNullOrEmpty((String)de.Properties["samaccountname"].Value))
                        {
                            usersWithName = de.Properties["samaccountname"].Value.ToString();
                            lstADUsers.Add(usersWithName);
                        }
                    }
                }
            }
            // test comment  
            List<string> listData = null;
            var query = "c-hzh";
            if (!string.IsNullOrEmpty(query))
            {
                listData = lstADUsers.Where(q => q.ToLower().StartsWith(query.ToLower())).ToList();
            }
            var  subList =  new { Data = listData };
            return;
        }


        //static void Main(string[] args)
        //{

        //  //  PrincipalContext context = new PrincipalContext(ContextType.Domain, "LDAP://fractech.local/DC=fractech", "CN=Users, DC = fractech, DC=Local");
        //    PrincipalContext context = new PrincipalContext(ContextType.Domain, "fractech.local");

        //    //Searching for a UserPrincipal 
        //    UserPrincipal demoUser = new UserPrincipal(context);
        //    demoUser.GivenName = "s*";


        //    // creating your principal searcher   
        //    PrincipalSearcher srch = new PrincipalSearcher(demoUser);

        //    var results = srch.FindAll();

        //    foreach (var result in results)
        //    {
        //        string actn = result.SamAccountName;
        //        string dn = result.DisplayName;
        //        string gn = result.Sid.ToString();
        //        string fn = result.Name;
        //       // string fn = result.Surname;


        //    }

        //    return ;
        //}
    }
}
