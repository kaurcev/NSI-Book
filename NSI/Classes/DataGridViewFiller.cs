using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NSI.Classes
{
    public class DataGridViewFiller
    {
        public static void FillDataGridView(DataGridView dataGridView, string jsonString)
        {
            try
            {
                var json = JObject.Parse(jsonString);
                var list = json["list"].ToObject<List<List<Dictionary<string, string>>>>();
                var columns = list
                    .SelectMany(item => item)
                    .Select(d => d["column"])
                    .Distinct()
                    .ToList();

                dataGridView.Columns.Clear();

                foreach (var column in columns)
                {
                    dataGridView.Columns.Add(column, column);
                }

                foreach (var item in list)
                {
                    var row = new DataGridViewRow();
                    row.CreateCells(dataGridView);

                    foreach (var dict in item)
                    {
                        var columnName = dict["column"];
                        var value = dict["value"];
                        var columnIndex = dataGridView.Columns[columnName].Index;
                        row.Cells[columnIndex].Value = value;
                    }

                    dataGridView.Rows.Add(row);
                }
            }
            catch
            {
                MessageBox.Show("Кажется, что что-то пошло не так");
            }

        }
    }
}