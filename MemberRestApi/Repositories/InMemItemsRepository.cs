using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using MemberRestApi.Entities;
using MemberRestApi.Dtos;

namespace MemberRestApi.Repositories
{
    public class InMemItemsRepository : IMemberRepository
    {

        public IEnumerable<Member> GetMembers()
        {
            using (var context = new DatabaseContext())
            {
                var test = new List<Member>();
                var query = from b in context.Members
                            orderby b.Name
                            select b;
                foreach(Member item in query)
                {
                    test.Add(item);
                }
                return test;
            }
        }

        public Member GetMember(Guid id)
        {
            using (var context = new DatabaseContext())
            {
                var test = context.Members.Find(id);
                return test;
            }
        }

        public void CreateMember(Member item)
        {
            using (var context = new DatabaseContext())
            {
                context.Members.Add(item);
                context.SaveChanges();
            }
        }

        public void UpdateMember(Member item)
        {
            using (var context = new DatabaseContext())
            {
                context.Members.Update(item);
                context.SaveChanges();
            }
        }

        public void DeleteMember(Guid id)
        {
            using (var context = new DatabaseContext())
            {
                context.Members.Remove(GetMember(id));
                context.SaveChanges();
            }
        }
    }
}