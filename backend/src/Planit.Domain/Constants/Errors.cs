using Planit.Domain.Models;

namespace Planit.Domain.Constants;
public static class Errors
{
    public static Error Generic = new Error(nameof(Generic), "An error occurred.");
    public static Error NotFound = new Error(nameof(NotFound), "The entity was not found.");
    public static Error Validation = new Error(nameof(Validation), "The request is invalid.");
}
