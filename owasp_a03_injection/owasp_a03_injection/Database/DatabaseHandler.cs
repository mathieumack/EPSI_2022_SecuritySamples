using SQLite;
using System.Text.RegularExpressions;

namespace owasp_a1_injection.Database
{
    internal class DatabaseHandler
    {
        private SQLiteConnection db;

        public DatabaseHandler()
        {

            db = new SQLiteConnection("sampleDb.sqlite3");
            db.CreateTable<Stock>();
        }

        public void FillDatabase()
        {
            for (int i = 1; i < 10; i++)
            {
                AddStock(Guid.NewGuid().ToString(), i);
            }
        }

        public void AddStock(string reference, int quantity)
        {
            var stock = new Stock
            {
                Reference = reference,
                Quantity = quantity
            };

            db.Insert(stock);
        }

        public void GetStocks()
        {
            var stocks = db.Query<Stock>("SELECT * FROM Stocks");

            foreach (var stock in stocks)
            {
                Console.WriteLine($"Ref : {stock.Reference} : {stock.Quantity}");
            }
        }

        public void GetStocks(string reference)
        {
            if (!Regex.IsMatch(reference, @"[a-f0-9\-]{36}"))
                return;

            // You can try with this reference : '1' OR '1' ='1.
            // It will generate this SQL query :    SELECT * FROM Stocks where reference == ''1' OR '1' ='1'
            var stocks = db.Query<Stock>("SELECT * FROM Stocks where reference == '" + reference.Replace("'", "''") + "'");

            foreach (var stock in stocks)
            {
                Console.WriteLine($"Ref : {stock.Reference} : {stock.Quantity}");
            }
        }
    }
}
