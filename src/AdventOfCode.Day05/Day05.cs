namespace AdventOfCode.Day05;

public class Day05
{
    private readonly string[] _input;

    private const string SeedsKey = "seeds";
    private const string SeedToSoilMapKey = "seed-to-soil";
    private const string SoilToFertilizerMapKey = "soil-to-fertilizer";
    private const string FertilizerToWaterMapKey = "fertilizer-to-water";
    private const string WaterToLightMapKey = "water-to-light";
    private const string LightToTemperatureMapKey = "light-to-temperature";
    private const string TemperatureToHumidityMapKey = "temperature-to-humidity";
    private const string HumidityToLocationMapKey = "humidity-to-location";

    private readonly IList<ulong> _seeds = new List<ulong>();
    private readonly List<SeedRange> _seedRanges = new();
    
    private readonly IList<Range> _seedToSoilList = new List<Range>();
    private readonly IList<Range> _soilToFertilizerList = new List<Range>();
    private readonly IList<Range> _fertilizerToWaterList = new List<Range>();
    private readonly IList<Range> _waterToLightList = new List<Range>();
    private readonly IList<Range> _lightToTemperatureList = new List<Range>();
    private readonly IList<Range> _temperatureToHumidityList = new List<Range>();
    private readonly IList<Range> _humidityToLocationList = new List<Range>();

    private readonly IDictionary<string, IList<Range>> _lists =
        new Dictionary<string, IList<Range>>();

    private record Range(ulong Source, ulong Destination, ulong Length);

    private record SeedRange(ulong Start, ulong Length)
    {
        public ulong End => Start + Length;
    }

    public Day05(string[] input)
    {
        _input = input;

        _lists.Add(SeedToSoilMapKey, _seedToSoilList);
        _lists.Add(SoilToFertilizerMapKey, _soilToFertilizerList);
        _lists.Add(FertilizerToWaterMapKey, _fertilizerToWaterList);
        _lists.Add(WaterToLightMapKey, _waterToLightList);
        _lists.Add(LightToTemperatureMapKey, _lightToTemperatureList);
        _lists.Add(TemperatureToHumidityMapKey, _temperatureToHumidityList);
        _lists.Add(HumidityToLocationMapKey, _humidityToLocationList);
    }

    public ulong Part1()
    {
        ReadSeeds(_input[0]);

        PrepareLists();

        var locations = new List<ulong>();

        foreach (var seed in _seeds)
        {
            var soil = Map(seed, SeedToSoilMapKey);
            var fertilizer = Map(soil, SoilToFertilizerMapKey);
            var water = Map(fertilizer, FertilizerToWaterMapKey);
            var light = Map(water, WaterToLightMapKey);
            var temperature = Map(light, LightToTemperatureMapKey);
            var humidity = Map(temperature, TemperatureToHumidityMapKey);
            var location = Map(humidity, HumidityToLocationMapKey);

            locations.Add(location);
        }

        return locations.Min();
    }

    public ulong Part2()
    {
        CalculateSeeds(_input[0]);

        PrepareLists();

        var minimumLocation = ulong.MaxValue;

        foreach (var seedRange in _seedRanges)
        {
            for (ulong i = 0; i <= seedRange.Length - 1; i++)
            {
                var seed = seedRange.Start + i;

                var soil = Map(seed, SeedToSoilMapKey);
                var fertilizer = Map(soil, SoilToFertilizerMapKey);
                var water = Map(fertilizer, FertilizerToWaterMapKey);
                var light = Map(water, WaterToLightMapKey);
                var temperature = Map(light, LightToTemperatureMapKey);
                var humidity = Map(temperature, TemperatureToHumidityMapKey);
                var location = Map(humidity, HumidityToLocationMapKey);

                if (location < minimumLocation) minimumLocation = location;
            }

        }

        return minimumLocation;
    }

    private void ReadSeeds(string line)
    {
        var seeds = line.Split(": ")[1].Split(" ").Select(ulong.Parse).ToList();

        foreach (var seed in seeds)
        {
            _seeds.Add(seed);
        }
    }

    private void PrepareLists()
    {
        var activeMapperKey = string.Empty;

        foreach (var line in _input)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            if (line.Contains(SeedsKey)) continue;

            if (line.Contains(SeedToSoilMapKey))
            {
                activeMapperKey = SeedToSoilMapKey;
            }

            if (line.Contains(SoilToFertilizerMapKey))
            {
                activeMapperKey = SoilToFertilizerMapKey;
            }

            if (line.Contains(FertilizerToWaterMapKey))
            {
                activeMapperKey = FertilizerToWaterMapKey;
            }

            if (line.Contains(WaterToLightMapKey))
            {
                activeMapperKey = WaterToLightMapKey;
            }

            if (line.Contains(LightToTemperatureMapKey))
            {
                activeMapperKey = LightToTemperatureMapKey;
            }

            if (line.Contains(TemperatureToHumidityMapKey))
            {
                activeMapperKey = TemperatureToHumidityMapKey;
            }

            if (line.Contains(HumidityToLocationMapKey))
            {
                activeMapperKey = HumidityToLocationMapKey;
            }

            if (!char.IsDigit(line[0])) continue;

            var numbers = line.Split(" ").Select(ulong.Parse).ToList();

            if (numbers.Count != 3) throw new Exception("Invalid input line. Expected 3 numbers.");

            var destination = numbers[0];
            var source = numbers[1];
            var length = numbers[2];

            var list = _lists[activeMapperKey];

            list.Add(new Range(source, destination, length));
        }
    }

    private ulong Map(ulong value, string mapKey)
    {
        var list = _lists[mapKey];

        foreach (var range in list)
        {
            if (value >= range.Source && value <= range.Source + range.Length)
            {
                return range.Destination + (value - range.Source);
            }
        }

        return value;
    }

    private void CalculateSeeds(string line)
    {
        var seeds = line.Split(": ")[1].Split(" ").Select(ulong.Parse).ToList();

        if (seeds.Count % 2 != 0) throw new Exception("Invalid input line. Expected even number of seeds.");

        for(var i = 0; i <= seeds.Count - 1; i += 2)
        {
            _seedRanges.Add(new SeedRange(seeds[i], seeds[i + 1]));
        }
    }
}
