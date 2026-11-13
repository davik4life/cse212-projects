
using System.Collections.Generic;

/// <summary>
/// Represents the complete USGS GeoJSON earthquake response.
/// </summary>
public class FeatureCollection
{
    public List<EarthquakeFeature> Features { get; set; } = new();
}

/// <summary>
/// Represents an individual earthquake feature.
/// </summary>
public class EarthquakeFeature
{
    public EarthquakeProperties Properties { get; set; }
}

/// <summary>
/// Represents the properties of an earthquake.
/// </summary>
public class EarthquakeProperties
{
    public string Place { get; set; }

    public double? Mag { get; set; }
}
