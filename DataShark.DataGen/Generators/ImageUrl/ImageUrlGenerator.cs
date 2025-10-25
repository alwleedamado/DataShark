using Bogus;
using DataShark.DataGen.Models;

namespace DataShark.DataGen.Generators.ImageUrl;

public class ImageUrlGenerator(ImageUrlSource source) : Generator
{
    public ImageUrlSource Source { get; set; } = source;
    public required int Width { get; set; }
    public required int Height { get; set; }
    public override Func<Faker, T, TPropType> Generate<T, TPropType>()
    {
        return Source switch
        {
            ImageUrlSource.Placeholder => (f, _) => Convert<TPropType>(f.Image.PlaceholderUrl(Width, Height)),
            ImageUrlSource.PlaceImg => (f, _) => Convert<TPropType>(f.Image.PlaceImgUrl(Width, Height)),
            _ => throw new NotImplementedException(),
        };
    }
}
