using Common.L4.Query;

namespace CoreModule.Query._DTOS;

public class CoreModuleUserDto : BaseDto
{
    public string? Avatar { get; set; }
    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? Email { get; set; }
    public string PhoneNumber { get; set; }
}