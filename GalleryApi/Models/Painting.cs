namespace GalleryApi.Models;

#nullable disable

public class Painting
{
    public int Id { get; set; }

    public string PaintingName { get; set; } = string.Empty;

    public string Genre {get; set;} = string.Empty;

    public string Size {get; set;} = string.Empty;

    public string DateOfCreation { get; set; } = string.Empty;

    public int? AuthorId { get; set; }

    public int? LocationId { get; set; }

    public virtual Author Author { get; set; }

    public virtual Location Location { get; set; }

}
