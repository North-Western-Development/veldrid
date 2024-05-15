using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Veldrid.ImageSharp;

public static class PixelSpanExtensions
{
    public static bool TryGetSinglePixelSpan<T>(this Image<T> input, out Span<T> data) where T : unmanaged, IPixel<T>
    {
        try
        {
            var memoryFootprint = new T[input.Width * input.Height];
            data = new Span<T>(memoryFootprint);
            input.CopyPixelDataTo(data);
            return true;
        }
        catch
        {
            data = null;
            return false;
        }
    }
}
