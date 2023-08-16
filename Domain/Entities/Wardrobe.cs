namespace Domain;

public class Wardrobe
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public ICollection<ClothingItem> ClothingItems { get; set; }
    public ICollection<Outfit> Outfits { get; set; }
}
