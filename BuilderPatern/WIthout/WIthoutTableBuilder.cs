using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatern.WIthoutTable

{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DynamicTable
    {
        public List<string> Columns { get; set; } = new List<string>();
        public List<List<string>> Rows { get; set; } = new List<List<string>>();

        public void AddColumn(string columnName)
        {
            Columns.Add(columnName);
        }

        public void AddRow(List<string> rowData)
        {
            if (rowData.Count != Columns.Count)
            {
                throw new InvalidOperationException("Row data must match the number of columns.");
            }
            Rows.Add(rowData);
        }

        public override string ToString()
        {
            var table = new StringBuilder();

            // Build Header
            table.AppendLine(string.Join(" | ", Columns));
            table.AppendLine(new string('-', Columns.Count * 10));

            // Build Rows
            foreach (var row in Rows)
            {
                table.AppendLine(string.Join(" | ", row));
            }

            return table.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create the table
            DynamicTable table = new DynamicTable();

            // Add columns
            table.AddColumn("Name");
            table.AddColumn("Age");
            table.AddColumn("Country");

            // Add rows
            table.AddRow(new List<string> { "Alice", "25", "USA" });
            table.AddRow(new List<string> { "Bob", "30", "UK" });
            table.AddRow(new List<string> { "Charlie", "35", "Canada" });

            // Display the table
            Console.WriteLine(table);

            // Create another table
            DynamicTable productTable = new DynamicTable();
            productTable.AddColumn("Product");
            productTable.AddColumn("Price");
            productTable.AddRow(new List<string> { "Laptop", "1000" });
            productTable.AddRow(new List<string> { "Phone", "500" });

            Console.WriteLine(productTable);
        }
    }

}
