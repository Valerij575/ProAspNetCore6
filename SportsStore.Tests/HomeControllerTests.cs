using Moq;
using SportsStore.Application.Services;
using SportsStore.Controllers;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Tests;

public class HomeControllerTests
{

    [Fact]
    public void Can_Use_Service()
    {
        // Arrange
        Mock<IProductService> mock = new Mock<IProductService>();
        mock.Setup(m => m.GetProducts()).Returns(new List<Product>
        {
            new Product {ProductId = 1, Name = "P1"},
            new Product {ProductId = 2, Name = "P2"}
        });

        HomeController controller= new HomeController(mock.Object);

        // Act
        ProductListViewModel result = controller.Index()?.ViewData.Model as ProductListViewModel ?? new();

        // Assert
        List<Product> products = result.Products.ToList() ?? new List<Product>();

        Assert.True(products.Count == 2);
        Assert.Equal("P1", products[0].Name);
        Assert.Equal("P2", products[1].Name);
    }

    [Fact]
    public void Can_Pagination()
    {
        // Arrange
        Mock<IProductService> mock = new Mock<IProductService>();
        mock.Setup(m => m.GetProducts()).Returns(new List<Product>
        {
            new Product {ProductId = 1, Name = "P1"},
            new Product {ProductId = 2, Name = "P2"},
            new Product {ProductId = 3, Name = "P3"},
            new Product {ProductId = 4, Name = "P4"},
            new Product {ProductId = 5, Name = "P5"},
            new Product {ProductId = 6, Name = "P6"}
        });

        HomeController controller = new HomeController(mock.Object);
        controller.PageSize = 3;

        // Act
        ProductListViewModel result = controller.Index(2) ?.ViewData.Model as ProductListViewModel ?? new();

        // Assert
        List<Product> products = result.Products.ToList() ?? new List<Product>();

        Assert.True(products.Count == 3);
        Assert.Equal("P4", products[0].Name);
        Assert.Equal("P5", products[1].Name);
    }

    [Fact]
    public void Can_Send_Pagination_ViewModel()
    {
        // Arrange
        Mock<IProductService> mock = new Mock<IProductService>();
        mock.Setup(m => m.GetProducts()).Returns(new List<Product>
        {
            new Product {ProductId = 1, Name = "P1"},
            new Product {ProductId = 2, Name = "P2"},
            new Product {ProductId = 3, Name = "P3"},
            new Product {ProductId = 4, Name = "P4"},
            new Product {ProductId = 5, Name = "P5"},
            new Product {ProductId = 6, Name = "P6"}
        });

        HomeController controller = new HomeController(mock.Object);
        controller.PageSize = 3;

        // Act
        ProductListViewModel result = controller.Index(2)?.ViewData.Model as ProductListViewModel ?? new();

        // Assert
        PagingInfo pageInfo = result.PagingInfo;

        Assert.Equal(2, pageInfo.CurrentPage);
        Assert.Equal(3, pageInfo.ItemsPerPage);
        Assert.Equal(6, pageInfo.TotalItems);
        Assert.Equal(2, pageInfo.TotalPages);
    }
}