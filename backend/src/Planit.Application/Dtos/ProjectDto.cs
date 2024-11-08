namespace Planit.Application.Dtos;
public record ProjectDto(
    Guid Id,
    string Name,
    DateTime? CreatedDate = default,
    DateTime? UpdatedDate = default);
