using System.Collections;
using System.Globalization;
using CsvHelper;

public record Faction(int Index, string Name, string Style);

public class FactionCollection : IEnumerable<Faction>
{
    private FactionCollection() {}

    public static FactionCollection Create() => new FactionCollection();

    private static Lazy<IReadOnlyCollection<Faction>> Read { get; } = new Lazy<IReadOnlyCollection<Faction>>(() =>
    {
        var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Factions.csv");
        var csv = File.OpenText(file);
        using var reader = new CsvReader(csv, CultureInfo.InvariantCulture);
        return reader.GetRecords<Faction>().ToList();
    });

    public IEnumerator<Faction> GetEnumerator() => Read.Value.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
