using System;
using System.Collections.Generic;
using System.IO;
using parking_Artem.Droid;
using System.Text;
using static parking_Artem.SQLite;
using parking_Artem;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace parking_Artem.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}