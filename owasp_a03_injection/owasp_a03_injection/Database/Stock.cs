using SQLite;

namespace owasp_a1_injection.Database
{
    [Table("Stocks")]
    public class Stock
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("reference")]
        public string Reference { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }
    }
}
