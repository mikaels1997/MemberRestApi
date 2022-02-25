using System;

namespace MemberRestApi.Entities
{
    public record Member
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Age { get; init; }
        public string Email { get; init; }
        public bool VipMember { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}