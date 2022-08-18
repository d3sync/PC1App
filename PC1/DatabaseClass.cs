using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC1
{
    class DatabaseClass
    {
        static string dbVar = "PC1db";
        //string sql = "";
        public SQLiteConnection m_dbConnection = new SQLiteConnection($"Data Source={dbVar}.sqlite;Version=3;");
        public DatabaseClass()
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection($"Data Source={dbVar}.sqlite;Version=3;");
        }

        public SQLiteConnection connect()
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection($"Data Source={dbVar}.sqlite;Version=3;");
            return m_dbConnection;
        }

        public void openUp()
        {
            this.m_dbConnection.Open();
        }
        public void closeUp()
        { this.m_dbConnection.Close(); }

        public void initializeDB()
        {
            //this.connect();
            //this.m_dbConnection.Open();
/*
 *                         txtParcelNo.Text,
            txtGeneralNumeration.Text,
            procDate.Value.ToString("dd/MM/yy"),
            txtName.Text,
            txtPrice.Text,
            cmbType.Text,
            deliveredDate.Value.ToString("dd/MM/yy"),
*/
SQLiteConnection.CreateFile($"{dbVar}.sqlite");
this.NonQuery("CREATE TABLE IF NOT EXISTS Companies (id INTEGER PRIMARY KEY AUTOINCREMENT,parcelno TEXT NOT NULL, general_numeration TEXT NOT NULL, procDate DATE NOT NULL, name TEXT NOT NULL, price DECIMAL NOT NULL, dc_type TEXT NOT NULL, regDate DATE NOT NULL)");

this.NonQuery("CREATE TABLE IF NOT EXISTS Status (id INTEGER PRIMARY KEY AUTOINCREMENT,status TEXT NOT NULL UNIQUE)");
this.NonQuery("CREATE TABLE IF NOT EXISTS Inventory (order_no INTEGER PRIMARY KEY,name TEXT NOT NULL,address TEXT,company_id INTEGER NOT NULL,del_status INTEGER NOT NULL,price REAL,FOREIGN KEY(company_id) REFERENCES Companies(id),FOREIGN KEY(del_status) REFERENCES Status(id))");
this.NonQuery("CREATE TABLE IF NOT EXISTS Logging (id INTEGER PRIMARY KEY AUTOINCREMENT, order_no INTEGER NOT NULL, Notes TEXT, Agent TEXT, FOREIGN KEY (order_no) REFERENCES Inventory (order_no))");
//this.m_dbConnection.Close();
}

public void populateDB()
{
//this.connect();
//this.m_dbConnection.Open();
this.NonQuery("INSERT INTO Status VALUES (0,'ΝΕΑ ΑΦΙΞΗ')");
this.InsertInto("Status", "1,'ΔΙΑΝΟΜΗ'");
this.InsertInto("Status", "2,'ΔΕΝ ΠΑΡΑΔΟΘΗΚΕ'");
this.InsertInto("Status", "3,'ΠΑΡΑΔΟΘΗΚΕ'");
this.InsertInto("Status", "4,'ΠΑΡΕΛΑΒΕ ΑΠ ΤΟ ΚΑΤΑΣΤΗΜΑ'");
this.InsertInto("Status", "5,'ΑΚΥΡΩΘΗΚΕ'");
this.NonQuery("INSERT INTO Companies VALUES (0,'PLUS4U'),(1,'PC1'),(2,'E-FRESH'),(3,'E-SHOP')");
this.NonQuery("INSERT INTO Inventory VALUES (3248953245,'dasgasdfascasd','This is my address',1,0,32.99)");
this.InsertInto("Inventory", "345324345,'asdasdasd','the address is this one',0,0,23.3");
this.InsertInto("Inventory", "334534545324345,'asdasdasf','the address is this one',0,0,33.3");
this.InsertInto("Inventory", "345324334534645,'fdsgdsfgdf','the address is this one',0,0,26.3");
this.InsertInto("Inventory", "3547445324345,'gdfgdfg','the address is this one',0,0,34.3");
this.InsertInto("Inventory", "34532434567855,'regereg','the address is this one',0,0,567.3");
this.InsertInto("Inventory", "3453254674345,'fsdgsvc','the address is this one',0,0,456.3");
this.InsertInto("Inventory", "345324568546345,'bvcxfsf','the address is this one',0,0,56.3");
//this.m_dbConnection.Close();
}

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
Console.WriteLine("INSERT INTO " + table + " VALUES (" + values + ")");
}

}
}
