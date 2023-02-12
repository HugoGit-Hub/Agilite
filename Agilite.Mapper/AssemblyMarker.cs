using System.Reflection;

namespace Agilite.Mapper;

public static class AssemblyMarker
{
    public static readonly Assembly Assembly = typeof(AssemblyMarker).Assembly;
}