using MemberRestApi.Dtos;
using MemberRestApi.Entities;

namespace MemberRestApi
{
    public static class Extensions
    {
        /// <summary>
        /// Converts member object to a data transfer object (DTO)
        /// </summary>
        /// <param name="item">The member object to be converted</param>
        /// <returns>Converted member object</returns>
        public static MemberDto AsDto(this Member item)
        {
            return new MemberDto{
                Id = item.Id,
                Name = item.Name,
                Email = item.Email,
                VipMember = item.VipMember,
                Age = item.Age,
                CreatedDate = item.CreatedDate
            };
        }
    }
}