using PC1.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PC1.Models;

namespace PC1
{
    public class DatabaseClass
    {
        private readonly DbContextDb _context;
        public static string dbVar = @$"{Properties.Settings.Default.dailyFolder}\PC1db.sqlite";
        //string sql = "";
        public SQLiteConnection m_dbConnection = new SQLiteConnection($"Data Source={dbVar};Version=3;");
        public DatabaseClass(DbContextDb context)
        {
            _context = context;
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection($"Data Source={dbVar};Version=3;");
        }
        
        public SQLiteConnection connect()
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection($"Data Source={dbVar};Version=3;");
            return m_dbConnection;
        }

        public void openUp()
        {
            this.m_dbConnection.Open();
        }
        public void closeUp()
        { this.m_dbConnection.Close(); }

        public void initializeDB(string file)
        {
            if (!Directory.Exists(file)) { 
                SQLiteConnection.CreateFile(file);
            }

            //this.NonQuery("CREATE TABLE IF NOT EXISTS Status (id INTEGER PRIMARY KEY AUTOINCREMENT,status TEXT NOT NULL UNIQUE)");
            //this.NonQuery("CREATE TABLE IF NOT EXISTS Inventory (order_no INTEGER PRIMARY KEY,name TEXT NOT NULL,address TEXT,company_id INTEGER NOT NULL,del_status INTEGER NOT NULL,price REAL,FOREIGN KEY(company_id) REFERENCES Companies(id),FOREIGN KEY(del_status) REFERENCES Status(id))");
            //this.NonQuery("CREATE TABLE IF NOT EXISTS Logging (id INTEGER PRIMARY KEY AUTOINCREMENT, order_no INTEGER NOT NULL, Notes TEXT, Agent TEXT, FOREIGN KEY (order_no) REFERENCES Inventory (order_no))");
            //this.m_dbConnection.Close();
        }

        //public void populateDB()
        //{
        ////this.connect();
        ////this.m_dbConnection.Open();
        //this.NonQuery("INSERT INTO Status VALUES (0,'ΝΕΑ ΑΦΙΞΗ')");
        //this.InsertInto("Status", "1,'ΔΙΑΝΟΜΗ'");
        //this.InsertInto("Status", "2,'ΔΕΝ ΠΑΡΑΔΟΘΗΚΕ'");
        //this.InsertInto("Status", "3,'ΠΑΡΑΔΟΘΗΚΕ'");
        //this.InsertInto("Status", "4,'ΠΑΡΕΛΑΒΕ ΑΠ ΤΟ ΚΑΤΑΣΤΗΜΑ'");
        //this.InsertInto("Status", "5,'ΑΚΥΡΩΘΗΚΕ'");
        //this.NonQuery("INSERT INTO Companies VALUES (0,'PLUS4U'),(1,'PC1'),(2,'E-FRESH'),(3,'E-SHOP')");
        //this.NonQuery("INSERT INTO Inventory VALUES (3248953245,'dasgasdfascasd','This is my address',1,0,32.99)");
        //this.InsertInto("Inventory", "345324345,'asdasdasd','the address is this one',0,0,23.3");
        //this.InsertInto("Inventory", "334534545324345,'asdasdasf','the address is this one',0,0,33.3");
        //this.InsertInto("Inventory", "345324334534645,'fdsgdsfgdf','the address is this one',0,0,26.3");
        //this.InsertInto("Inventory", "3547445324345,'gdfgdfg','the address is this one',0,0,34.3");
        //this.InsertInto("Inventory", "34532434567855,'regereg','the address is this one',0,0,567.3");
        //this.InsertInto("Inventory", "3453254674345,'fsdgsvc','the address is this one',0,0,456.3");
        //this.InsertInto("Inventory", "345324568546345,'bvcxfsf','the address is this one',0,0,56.3");
        ////this.m_dbConnection.Close();
        //}

        public void NonQuery(string query)
        {
            this.openUp();
            SQLiteCommand command = new SQLiteCommand(query, this.m_dbConnection);
            command.ExecuteNonQuery();
            this.closeUp();

        }

        public void InsertInto(string table, string values)
        {
            this.NonQuery("INSERT INTO " + table + " VALUES (" + values + ")");
            //Console.WriteLine("INSERT INTO " + table + " VALUES (" + values + ")");
        }
        public void UpdateIntoID(string table, string values, int id)
        {
            this.NonQuery($"UPDATE {table} SET {values} WHERE id={id}");
            //Console.WriteLine("INSERT INTO " + table + " VALUES (" + values + ")");
        }

        public void AddDParcel(string values)
        {
            //
            this.NonQuery("INSERT INTO Delivered (parcelno,general_numeration,procDate,name,price,dc_type,regDate) VALUES (" + values + ")");
        }
        public void AddAssignedTo(string values)
        {
            //ParcelBarcode,InvBarcode,VoucherBarcode,Name,Address,Price,Driver,regDate
            this.NonQuery("INSERT INTO Parcels (ParcelBarcode,InvBarcode,VoucherBarcode,Name,Address,Price,Driver,regDate) VALUES (" + values + ")");
        }

        public List<DateTime> GetDates(string table)
        {
            try
            {
                var rr = new List<string>();
                if (table == "Parcels")
                {
                    rr = _context.AssignedtoModel.Select(m => m.regDate).Distinct().ToList();
                }

                if (table == "Delivered")
                {
                    rr = _context.DeliveredModel.Select(m => m.regDate).Distinct().ToList();
                }

                List<DateTime> dates = rr.Select(date => DateTime.Parse(date)).ToList();
                return dates;
            }
            catch
            {
                return new List<DateTime>();
            }

            //string cs = @$"URI=file:{Properties.Settings.Default.dailyFolder}\PC1db.sqlite";
            //using var con = new SQLiteConnection(cs);
            //con.Open();
            //List<DateTime> dates2 = new();
            //string sql = $"SELECT DISTINCT regDate from {table}";
            //SQLiteCommand command = new SQLiteCommand(sql, con);
            //using (SQLiteDataReader read = command.ExecuteReader())
            //{
            //    while (read.Read())
            //    {
            //        dates.Add(DateTime.Parse(read.GetString(0)));
            //    }
            //}
            //con.Close();
            //return dates;
        }

        public List<DeliveredModel> GetDataByDate2(string date)
        {
            return _context.DeliveredModel.Where(m => m.regDate == date).ToList();
            string cs = @$"URI=file:{Properties.Settings.Default.dailyFolder}\PC1db.sqlite";
            using var con = new SQLiteConnection(cs);
            con.Open();
            string stm = $"SELECT * FROM Delivered WHERE regDate='{date}'";
            List<DeliveredModel> result = new List<DeliveredModel>();

            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader read = cmd.ExecuteReader();
            {
                while (read.Read())
                {
                    result.Add(new DeliveredModel()
                    {
                        id = read.GetInt32(0),
                        parcelno = read.GetString(1),
                        general_numeration = read.GetString(2),
                        procDate = read.GetString(3),
                        name = read.GetString(4),
                        price = read.GetString(5),
                        dc_type = read.GetString(6),
                        regDate = read.GetString(7)
                    });
                    Console.WriteLine(read.GetInt32(0));
                }
            }
            con.Dispose();
            return result;
        }
        public List<AssignedtoModel> GetLoadedDataByDate(string date)
        {
            var dd = _context.AssignedtoModel.Where(m => m.regDate == date).ToList();
            return dd ?? new List<AssignedtoModel>();

            string cs = @$"URI=file:{Properties.Settings.Default.dailyFolder}\PC1db.sqlite";
            using var con = new SQLiteConnection(cs);
            con.Open();
            string stm = $"SELECT * FROM Parcels WHERE regDate = '{date}'";
            //string stm = "SELECT * FROM Parcels WHERE regDate = '26/09/2022'";
            List<AssignedtoModel> result = new List<AssignedtoModel>();
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader read = cmd.ExecuteReader();
            {
                while (read.Read())
                {
                    result.Add(new AssignedtoModel()
                    {//ParcelBarcode,InvBarcode,VoucherBarcode,Name,Address,Price,Driver,regDate
                        id = read.GetInt32(0),
                        ParcelBarcode = read.GetString(1),
                        InvBarcode = read.GetString(2),
                        VoucherBarcode = read.GetString(3),
                        Name = read.GetString(4),
                        Address = read.GetString(5),
                        Price = read.GetString(6),
                        Driver = read.GetString(7),
                        regDate = read.GetString(8)
                    });
                    Console.WriteLine(read.GetInt32(0));
                }
            }
            con.Dispose();
            return result;
        }
        public AssignedtoModel GetLoadedByID(int id)
        {
            try
            {
                return _context.AssignedtoModel.FirstOrDefault(m => m.id == id);
            }
            catch
            {
                return new AssignedtoModel() { id = id, Name = "No results" };
            }

            string cs = @$"URI=file:{Properties.Settings.Default.dailyFolder}\PC1db.sqlite";
            using var con = new SQLiteConnection(cs);
            con.Open();
            string stm = $"SELECT * FROM Parcels WHERE id = '{id}'";
            //string stm = "SELECT * FROM Parcels WHERE regDate = '26/09/2022'";
            AssignedtoModel result = new();
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader read = cmd.ExecuteReader();
            {
                while (read.Read())
                {
                    //ParcelBarcode,InvBarcode,VoucherBarcode,Name,Address,Price,Driver,regDate
                    result.id = read.GetInt32(0);
                    result.ParcelBarcode = read.GetString(1);
                    result.InvBarcode = read.GetString(2);
                    result.VoucherBarcode = read.GetString(3);
                    result.Name = read.GetString(4);
                    result.Address = read.GetString(5);
                    result.Price = read.GetString(6);
                    result.Driver = read.GetString(7);
                    result.regDate = read.GetString(8);
                }
                //Console.WriteLine(read.GetInt32(0));
            }
            con.Dispose();
            return result;
        }
    }
}
