using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.Dto
{
    public class UserDto : BaseDto
    {
        [MaxLength(12)]
        [MinLength(3)]
        public string UserName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        
        [MaxLength(12)]
        [MinLength(8)]
        public string Password { get; set; } = string.Empty;
        public List<RoleDto> Roles { get; set; } = new();
    }
}