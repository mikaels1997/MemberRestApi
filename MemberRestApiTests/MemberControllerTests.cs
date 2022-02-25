using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MemberRestApi;
using MemberRestApi.Controllers;
using MemberRestApi.Dtos;
using MemberRestApi.Entities;
using MemberRestApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MemberRestApiTests
{
    /// <summary>
    /// Contains few basic unit tests for member controller
    /// </summary>
    public class MemberControllerTests
    {
        Mock<IMemberRepository> repositoryStub = new();

        [Fact]
        public void GetMember_UnexistingMember_ReturnNotFound()
        {
            repositoryStub.Setup(repo => repo.GetMember(It.IsAny<Guid>()))
                .Returns((Member)null);
            var contollerStub = new MemberController(repositoryStub.Object);

            var result = contollerStub.GetMember(Guid.NewGuid());

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetMembers_ExistingItems_ReturnsAllMembers()
        {
            var expectedMembers = new[] { RandomMember(), RandomMember() };
            repositoryStub.Setup(repo => repo.GetMembers())
                .Returns(expectedMembers);
            var contollerStub = new MemberController(repositoryStub.Object);

            var actualMembers = contollerStub.GetMembers();

            actualMembers.Should().BeEquivalentTo(expectedMembers);
        }

        [Fact]
        public void CreateMember_ValidMember_ReturnCreated()
        {
            var memberToCreate = new CreateMemberDto()
            {
                Name = "TestName",
                Age = "30",
                Email = "TestEmail",
                VipMember = false
            };
            var contollerStub = new MemberController(repositoryStub.Object);

            var result = contollerStub.CreateMember(memberToCreate);
            var createdMember = (result.Result as CreatedAtActionResult).Value as MemberDto;
            memberToCreate.Should().BeEquivalentTo(createdMember,
                options => options.ComparingByMembers<MemberDto>().ExcludingMissingMembers());
            createdMember.Id.Should().NotBeEmpty();
        }

        private Member RandomMember()
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Name = "TestName",
                Age = "30",
                Email = "TestEmail",
                VipMember = false,
                CreatedDate = DateTimeOffset.UtcNow
            };
        }
    }
}
