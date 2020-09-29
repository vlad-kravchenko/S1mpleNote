using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;

namespace S1mpleNote.Domain
{
    public class NoteRepository
    {
        SQLiteConnection database;

        public NoteRepository(string filename)
        {
            var service = DependencyService.Get<ISQLite>();
            string databasePath = service.GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Note>();
        }

        public IEnumerable<Note> GetItems()
        {
            return database.Table<Note>().ToList();
            //return (from i in database.Table<Note>() select i).ToList();
        }

        public Note GetItem(int id)
        {
            return database.Get<Note>(id);
        }

        public int DeleteItem(int id)
        {
            return database.Delete<Note>(id);
        }

        public int SaveItem(Note item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}