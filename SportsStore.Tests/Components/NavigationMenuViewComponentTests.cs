using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using SportsStore.Components;
using SportsStore.Models;
using SportsStore.Persistance.Interfaces;

namespace SportsStore.Tests.Components
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Can_Select_Category()
        {
            //Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product()
                {
                    ProductId = 1,
                    Name = "P1",
                    Category = "Apples"
                },
                new Product{
                    ProductId = 2,
                    Name = "P2",
                    Category = "Apples"
                },
                new Product
                {
                    ProductId = 3,
                    Name = "P3",
                    Category = "Plums"
                }
            }).AsQueryable<Product>());

            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);

            //Act
            string[] categories = ((IEnumerable<string>?)(target.Invoke() as ViewViewComponentResult)?
                                        .ViewData?.Model ?? Enumerable.Empty<string>()).ToArray();

            //Assert
            Assert.True(categories.Any());
        }
    }
}
