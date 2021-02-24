using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace test_api
{
    public class CategoriaControllerTest
    {
        private readonly Mock<DbSet<Category>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Category _category;
        //
        public CategoriaControllerTest()
        {
            _mockSet = new Mock<DbSet<Category>>();
            _mockContext = new Mock<Context>();
            _category = new Category {Id= 1, Descricao = "Teste Categoria"};

            _mockContext.Setup(expression:m => m.Category).Returns(_mockSet.Object);
            _mockContext.Setup(expression:m => m.Category.FindAsync(params keyValues:1));

        }

        [Fact]

        public async Task Get_Category()
        {
            var service = new CategoryController(_mockContext.Object);
            await service.GetCategory(Id: 1);
            _mockSet.Verify(expression: m => m.FindAsync(params keyValues: 1), TimeSpan.Once());
        }
        
    }
}
