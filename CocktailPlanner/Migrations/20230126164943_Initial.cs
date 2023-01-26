using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CocktailPlanner.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventPlans",
                columns: table => new
                {
                    IdEvent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPlans", x => x.IdEvent);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IdIngredient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Quantity = table.Column<double>(type: "float", maxLength: 255, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IdIngredient);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    IdItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.IdItem);
                });

            migrationBuilder.CreateTable(
                name: "Cocktails",
                columns: table => new
                {
                    IdCocktail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Image = table.Column<byte>(type: "tinyint", nullable: false),
                    EventPlanIdEvent = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cocktails", x => x.IdCocktail);
                    table.ForeignKey(
                        name: "FK_Cocktails_EventPlans_EventPlanIdEvent",
                        column: x => x.EventPlanIdEvent,
                        principalTable: "EventPlans",
                        principalColumn: "IdEvent");
                });

            migrationBuilder.CreateTable(
                name: "EventPlanInventory",
                columns: table => new
                {
                    EventPlansIdEvent = table.Column<int>(type: "int", nullable: false),
                    InventoriesIdItem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPlanInventory", x => new { x.EventPlansIdEvent, x.InventoriesIdItem });
                    table.ForeignKey(
                        name: "FK_EventPlanInventory_EventPlans_EventPlansIdEvent",
                        column: x => x.EventPlansIdEvent,
                        principalTable: "EventPlans",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventPlanInventory_Inventories_InventoriesIdItem",
                        column: x => x.InventoriesIdItem,
                        principalTable: "Inventories",
                        principalColumn: "IdItem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CocktailIngredient",
                columns: table => new
                {
                    CocktailsIdCocktail = table.Column<int>(type: "int", nullable: false),
                    IngredientsIdIngredient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailIngredient", x => new { x.CocktailsIdCocktail, x.IngredientsIdIngredient });
                    table.ForeignKey(
                        name: "FK_CocktailIngredient_Cocktails_CocktailsIdCocktail",
                        column: x => x.CocktailsIdCocktail,
                        principalTable: "Cocktails",
                        principalColumn: "IdCocktail",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CocktailIngredient_Ingredients_IngredientsIdIngredient",
                        column: x => x.IngredientsIdIngredient,
                        principalTable: "Ingredients",
                        principalColumn: "IdIngredient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CocktailIngredient_IngredientsIdIngredient",
                table: "CocktailIngredient",
                column: "IngredientsIdIngredient");

            migrationBuilder.CreateIndex(
                name: "IX_Cocktails_EventPlanIdEvent",
                table: "Cocktails",
                column: "EventPlanIdEvent");

            migrationBuilder.CreateIndex(
                name: "IX_EventPlanInventory_InventoriesIdItem",
                table: "EventPlanInventory",
                column: "InventoriesIdItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CocktailIngredient");

            migrationBuilder.DropTable(
                name: "EventPlanInventory");

            migrationBuilder.DropTable(
                name: "Cocktails");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "EventPlans");
        }
    }
}
