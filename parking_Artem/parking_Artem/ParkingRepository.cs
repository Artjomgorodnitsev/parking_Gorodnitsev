using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using static parking_Artem.SQLite;

namespace parking_Artem
{
    public class ParkingRepository
    {
        SQLiteConnection database;
        static object locker = new object();


        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<Parking>(id);
            }
        }
        public ParkingRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Parking>();
        }
        public IEnumerable<Parking> GetItems()
        {
            return (from i in database.Table<Parking>() select i).ToList();

        }
        public Parking GetItem(int id) //позволяет получить элемент типа T по id
        {
            return database.Get<Parking>(id);
        }
        public int SaveItem(Parking item)
        {
            if (item.Id != 0)
            {
                database.Update(item); //обновляет объект
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
