using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlServerCe;

namespace SQLiteCeExample.Repository
{
    /// <summary>
    /// https://blogs.msdn.microsoft.com/windows-embedded/2013/02/14/sqlite-and-windows-embedded-compact/
    /// </summary>
    public class Database
    {
        private const string db = "test.db";
        private const string password = "asdf";

        private readonly string  dbPath;

        public Database()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            string dir = Path.GetDirectoryName(path);
            dbPath = Path.Combine(dir, db);
        }

        public void CreateDb()
        {
            if (File.Exists(dbPath))
            {
                File.Delete(dbPath);
            }

            string connectionString = string.Format("DataSource='{0}'; LCID=1033; Password='{1}'", dbPath, password);
            using (SqlCeEngine engine = new SqlCeEngine(connectionString))
            {
                engine.CreateDatabase();
            }
        }
    }
}
