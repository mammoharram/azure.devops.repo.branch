using CsvHelper;

namespace azure.devops.repo.branch.Helpers;

internal class HelperMethods
{
    internal static void SaveToCsv<T>(List<T> output, string filePath)
    {
        using var writer = new StreamWriter(filePath);
        using var csv = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture);
        csv.WriteRecords(output);
    }
}
