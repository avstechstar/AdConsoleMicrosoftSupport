using System.Data;
using System.DirectoryServices;

namespace TestAD
{
    class DirectoryEntry_filter
    {

        public DataSet Main()
        {
            string username = "userId"; // Who has the permission to access the AD

            string Password = "Password"; //Password for the user

            string Path = "Server Address";




            DirectoryEntry entry = new DirectoryEntry(Path, username, Password);

            DirectorySearcher searcher = new DirectorySearcher(entry);

            searcher.Filter = ("(username=username*)");

            DataSet ds = new DataSet();

            DataTable dtUsers = new DataTable("Users");

            dtUsers.Columns.Add("Column1");

            dtUsers.Columns.Add("Column2");

            dtUsers.Constraints.Add("UniqueUserId", dtUsers.Columns["userid"], true);



            foreach (SearchResult temp in searcher.FindAll())

            {

                //Do Something

            }

            ds.Tables.Add(dtUsers);

            return ds;
        }

    }
}
