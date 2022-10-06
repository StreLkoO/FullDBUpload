using Oracle.ManagedDataAccess.Client;
namespace ЦАД2
{
    public class OracleReader
    {
        private string ConString;
        private static OracleReader? instance;

        private OracleReader(string ConString)
        {
            this.ConString = ConString;
        }

        public static OracleReader Get(string ConString)
        {
            if (instance == null)
            {
                instance = new OracleReader(ConString);
            }
            else
            {
                instance.ConString = ConString;
            }
            return instance;
        }


        public void QueryData<T>(Dictionary<string, List<T>> values, string path, ViewFile view, string year, string month) where T : IObjects, new()
        {
            using OracleConnection connection = new(ConString);
            try
            {
                connection.Open();
                OracleCommand oc = ReadComand(connection, path);
                AddParams(oc, view, year, month);
                ReadMap(values, oc, view);
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void ReadMap<T>(Dictionary<string, List<T>> values, OracleCommand oc, ViewFile view) where T : IObjects, new()
        {
            using OracleDataReader reader = oc.ExecuteReader();
            object[] n = new object[reader.FieldCount];
            while (reader.Read())
            {
                reader.GetValues(n);
                T t = new();
                t.Fill(n, view.TypeFile);
                if (!values.ContainsKey(t.GetCode()))
                {
                    values[t.GetCode()] = new List<T>();
                }
                values[t.GetCode()].Add(t);
            }
        }

        private static OracleCommand ReadComand(OracleConnection connection, string path)
        {
            OracleCommand Command = connection.CreateCommand();
            using (StreamReader sr = new(Directory.GetCurrentDirectory() + "\\запросы\\ЦАД\\" + path))
            {
                Command.CommandText = sr.ReadToEnd();
            }
            return Command;
        }

        private void AddParams(OracleCommand oc, ViewFile view, string year, string month)
        {
            oc.CommandText = oc.CommandText.Replace("%typeFile%", view.Text);
            oc.CommandText = oc.CommandText.Replace("%PR%", view.Name);
            oc.CommandText = oc.CommandText.Replace("%DISP%", view.Disp);
            oc.BindByName = true;
            oc.Parameters.Clear();
            oc.Parameters.Add(":year", year);
            oc.Parameters.Add(":month", month);
        }


    }
}
