namespace GalleryApi.Models;

public class Location
{
    public int Id { get; set; }

    public string LocationName { get; set; } = string.Empty;

    public string Geolocation {get; set;} = string.Empty;
}
