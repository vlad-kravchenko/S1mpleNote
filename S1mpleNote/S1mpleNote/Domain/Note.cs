using SQLite;

namespace S1mpleNote.Domain
{
    [Table("Notes")]
    public class Note
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Text { get; set; }
    }
}