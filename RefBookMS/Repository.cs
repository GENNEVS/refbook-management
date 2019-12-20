using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RefBookMS
{
    class Repository
    {
        //string RefBookMSDB = "refbook.dat";

        public void CreateDB(string dbName, string dbIndex = "index.dat")
        {
            if (File.Exists(dbName)) {
                RenameDB(dbName, GetBackupName(dbName));
            }

            FileStream dbf = File.Create(dbName);
            dbf.Close();
            FileStream indf = File.Create(dbIndex);
            indf.Close();
        }

        private string GetBackupName(string dbName)
        {
            FileInfo info = new FileInfo(dbName);
            string dbNewName = $"{info.Name}_{DateTime.Now.ToString("yyyMMdd")}";
            int count = Directory.GetFiles(".", dbNewName).Length;

            return count > 0 ? $"{dbNewName}_count" : dbNewName;
        }

        private void RenameDB(string dbName, string dbNewName)
        {
            FileInfo info = new FileInfo(dbName);
            info.CopyTo(dbNewName);
            info.Delete();
        }

        public object GetRecord(string pathToDB, long position, int count)
        {
            using (FileStream rf = new FileStream(pathToDB, FileMode.Open))
            {
                byte[] bytesOfObj = new byte[count];
                rf.Position = position;
                rf.Read(bytesOfObj, 0, count);
                return GetObjFromBytes(bytesOfObj);
            }
        }

        private object GetObjFromBytes(byte[] bytesOfObj)
        {
            object obj;

            BinaryFormatter bf = new BinaryFormatter();

            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(bytesOfObj, 0, bytesOfObj.Length);
                long p = ms.Position;
                ms.Position = 0;
                obj = bf.Deserialize(ms);
            }

            return obj;
        }

    }
}
