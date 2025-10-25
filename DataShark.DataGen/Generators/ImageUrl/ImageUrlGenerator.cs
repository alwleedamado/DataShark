using Bogus;
using DataShark.DataGen.Models;

namespace DataShark.DataGen.Generators.ImageUrl;

public class ImageUrlGenerator(GeneratorDescriptor descriptor) : Generator(descriptor)
{
    public override Func<Faker, T, TPropType> Generate<T, TPropType>()
    {
        var descriptor = (ImageUrlGeneratorDescriptor)base.Descriptor;

        return descriptor.Source switch
        {
            ImageUrlSource.Placeholder => (f, _) => Convert<TPropType>(f.Image.PlaceholderUrl(descriptor.Width, descriptor.Height)),
            ImageUrlSource.PlaceImg => (f, _) => Convert<TPropType>(f.Image.PlaceImgUrl(descriptor.Width, descriptor.Height)),
            _ => throw new NotImplementedException(),
        };
    }
}
