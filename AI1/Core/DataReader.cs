using System.Data;

internal class DataReader {
    public DataTable ReadData(string path) {

        DataTable dt = new();
        using StreamReader sr = new StreamReader(path);
        if (sr.Peek() == -1)
            throw new Exception("PiesOutOfBoundsExeption.");

        string[] headers = sr.ReadLine().Split(',');
        foreach (string header in headers) {
            dt.Columns.Add(header);
        }

        while (!sr.EndOfStream) {
            string[] rows = sr.ReadLine()
                              .Split(',');
            DataRow dr = dt.NewRow();
            for (int i = 0; i < headers.Length; i++) {
                dr[i] = rows[i];
            }
            dt.Rows.Add(dr);
        }

        return dt;
    }
}
