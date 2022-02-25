using System.ComponentModel.DataAnnotations;

namespace MemberRestApi.Dtos
{
    public record UpdateMemberDto
    {
        public string Name { get; init; }
        public string Age { get; init; }
        public string Email { get; init; }
        public bool VipMember { get; init; }
    }
}