using System;
using System.Collections.Generic;
using System.Text;

namespace parking_Artem
{
    public class SQLite
    {
        public interface ISQLite
        {
            string GetDatabasePath(string filename);
        }
    }
}
