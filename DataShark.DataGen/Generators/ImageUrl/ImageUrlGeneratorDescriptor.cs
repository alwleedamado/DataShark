using DataShark.DataGen.Models;

namespace DataShark.DataGen.Generators.ImageUrl;

public class ImageUrlGeneratorDescriptor : GeneratorDescriptor
{
    public ImageUrlSource Source
    {
        get => (ImageUrlSource)_arguments["Source"];
        set => _arguments["Source"] = value;
    }
    public required int Width { get; set; }
    public required int Height { get; set; }
    public override string GeneratorName => "ImageUrl";
}