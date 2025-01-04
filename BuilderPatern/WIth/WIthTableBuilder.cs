using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatern.WIthTable
{
    // Step 1: Product - Dynamic Table
    public class DynamicTable
    {
        public List<string> Columns { get; set; } = new List<string>();
        public List<List<string>> Rows { get; set; } = new List<List<string>>();

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

    // Step 2: Builder Interface
    public interface ITableBuilder
    {
        void AddColumn(string columnName);
        void AddRow(List<string> rowData);
        DynamicTable GetTable();
    }

    // Step 3: Concrete Builder
    public class TableBuilder : ITableBuilder
    {
        private DynamicTable _table = new DynamicTable();

        public void AddColumn(string columnName)
        {
            _table.Columns.Add(columnName);
        }

        public void AddRow(List<string> rowData)
        {
            if (rowData.Count != _table.Columns.Count)
            {
                throw new InvalidOperationException("Row data must match the number of columns.");
            }
            _table.Rows.Add(rowData);
        }

        public DynamicTable GetTable()
        {
            return _table;
        }
    }

    // Step 4: Director
    public class TableDirector
    {
        private readonly ITableBuilder _builder;

        public TableDirector(ITableBuilder builder)
        {
            _builder = builder;
        }

        public DynamicTable BuildSampleTable()
        {
            // Define columns
            _builder.AddColumn("Name");
            _builder.AddColumn("Age");
            _builder.AddColumn("Country");

            // Add rows
            _builder.AddRow(new List<string> { "Alice", "25", "USA" });
            _builder.AddRow(new List<string> { "Bob", "30", "UK" });
            _builder.AddRow(new List<string> { "Charlie", "35", "Canada" });

            return _builder.GetTable();
        }
    }

    // Step 5: Client
    class Use
    {
        static void Run(string[] args)
        {
            ITableBuilder builder = new TableBuilder();
            TableDirector director = new TableDirector(builder);

            // Build and display a sample table
            DynamicTable table = director.BuildSampleTable();
            Console.WriteLine(table);

            // Custom table example
            builder.AddColumn("Product");
            builder.AddColumn("Price");
            builder.AddRow(new List<string> { "Laptop", "1000" });
            builder.AddRow(new List<string> { "Phone", "500" });
            Console.WriteLine(builder.GetTable());
        }
    }


}
