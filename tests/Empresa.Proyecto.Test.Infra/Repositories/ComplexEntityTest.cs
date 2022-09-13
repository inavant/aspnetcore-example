using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Empresa.Proyecto.Core.Entities;
using Empresa.Proyecto.Core.Interfaces;
using Empresa.Proyecto.Core.Specifications;
using Empresa.Proyecto.Infra.Data;

namespace Empresa.Proyecto.Test.Infra.Repositories
{
    public class ComplexEntityTest
    {
        private readonly IAsyncRepository<ComplexEntity> complexEntityRepo;
        private readonly MyProjectContext dbContext;

        public ComplexEntityTest()
        {
            dbContext = SetupDB.GetDefaultContext();
            complexEntityRepo = new EFRepository<ComplexEntity>(dbContext);
        }

        [Theory]
        [InlineData(600, 1)]
        [InlineData(1500, 0)]
        [InlineData(400, 2)]
        public async Task ShouldFilterByHighAmount(decimal amountToFilter, int expectedResult )
        {
            //arrange
            dbContext.ComplexEntity.Add(new Builders.ComplexEntityBuilder()
                .WithDefaultValues()
                .Amount(200)
                .Build()
                );
            dbContext.ComplexEntity.Add(new Builders.ComplexEntityBuilder()
            .WithDefaultValues()
            .Amount(500)
            .Build()
            );
            dbContext.ComplexEntity.Add(new Builders.ComplexEntityBuilder()
                .WithDefaultValues()
                .Amount(800)
                .Build()
                );
            dbContext.SaveChanges();

            var spec = new ComplexEntityHighAmountSpecification(amountToFilter);

            //act
            var list = await complexEntityRepo.ListAsync(spec);

            //assert
            list.Should().NotBeNull().And.HaveCount(expectedResult);
        }
    }
}
