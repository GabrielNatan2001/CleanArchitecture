using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" +
                "values('Caderno espiral', 'Caderno espiral 100 folhas', 7.45, 50,'caderno.jpg',1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
