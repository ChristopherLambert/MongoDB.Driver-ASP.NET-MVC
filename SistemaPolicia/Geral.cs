using System.Web.Helpers;

namespace SistemaPolicia
{
    public static class Geral
    {
        public static string Sorter(string columnName, string columnHeader, WebGrid grid)
        {
            return string.Format("{0} {1}", columnHeader, grid.SortColumn == columnName ?
                grid.SortDirection == SortDirection.Ascending ? "▲" : "▼" : string.Empty);
        }
    }
}