using ConsoleTableExt;
using PhonebookUI.Contacts;

namespace PhonebookUI
{
    internal class VisualizePhonebook
    {
        public static void ShowTableList<T>(List<T> tableData, string tableName) where T : class
        {
            Console.WriteLine("\n\n");

            ConsoleTableBuilder.From(tableData).WithTitle(tableName).WithColumn("").ExportAndWriteLine(TableAligntment.Center);
        }
    }
}
