using System.DirectoryServices.AccountManagement;

namespace TestAD
{
    class PrincipalContextFilter
    {

        public object Main()
        {

            PrincipalContext context = new PrincipalContext(ContextType.Domain, "YOURDOMAIN", "OU=Ingegneria,DC=xxx,DC=xxx");

            //Searching for a UserPrincipal 
            UserPrincipal demoUser = new UserPrincipal(context);
            demoUser.GivenName = "s*";


            // creating your principal searcher   
            PrincipalSearcher srch = new PrincipalSearcher(demoUser);

            var result = srch.FindAll();

            return result;
        }
    }
}
