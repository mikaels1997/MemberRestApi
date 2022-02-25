using System;
using System.Collections.Generic;
using MemberRestApi.Controllers;
using MemberRestApi.Entities;


namespace MemberRestApi.Repositories
{
    /// <summary>
    /// A general interface of the member repository.
    /// </summary>
    public interface IMemberRepository
    {
        Member GetMember(Guid id);
        IEnumerable<Member> GetMembers();
        void CreateMember(Member item);
        void UpdateMember(Member item);
        void DeleteMember(Guid id);
    }
    
}