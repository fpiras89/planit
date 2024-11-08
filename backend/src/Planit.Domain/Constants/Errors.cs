using Planit.Domain.Models;

namespace Planit.Domain.Constants;
public static class Errors
{
    public static Error Generic = new Error("GENERIC", "An error occurred.");
    public static Error NotFound = new Error("NOT_FOUND", "The entity was not found.");
}
