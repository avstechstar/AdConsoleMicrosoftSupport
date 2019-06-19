using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;

namespace TestAD
{
    class PrincipalContextConventional
    {

        public object Main()
        {
            List<string> lstADUsers = new List<string>();
            using (var context = new PrincipalContext(ContextType.Domain, null, "LDAPPATH"))
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
            List<string> listData = null;
            var query = "username";
            if (!string.IsNullOrEmpty(query))
            {
                listData = lstADUsers.Where(q => q.ToLower().StartsWith(query.ToLower())).ToList();
            }
            return new { Data = listData };
        }
    }

}

