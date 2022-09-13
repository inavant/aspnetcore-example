using Xunit;
using FluentAssertions;



namespace Empresa.Proyecto.Test.Core.Entities
{
    public class ComplexEntityTest
    {
        [Theory]
        [InlineData(150)]
        [InlineData(300)]
        public void ShouldCalculateTax(decimal amount)
        {
            //arrange
            var complexEntity = new Builders.ComplexEntityBuilder().WithDefaultValues()
                .Amount(amount).Build();
            var expectedTax = amount * 0.16m;

            //act
            var calculatedTax = complexEntity.Tax;

            //assert
            calculatedTax.Should().Be(expectedTax);
        }

    }
    
     
  
}
