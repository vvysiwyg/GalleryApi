using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GalleryApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    author_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    place_of_birth = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    dob = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    place_of_study = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    location_name = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    geolocation = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "painting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    painting_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    genre = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    size = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    date_of_creation = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    author_id = table.Column<int>(type: "integer", nullable: true),
                    location_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_painting", x => x.Id);
                    table.ForeignKey(
                        name: "FK1",
                        column: x => x.author_id,
                        principalTable: "author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK2",
                        column: x => x.location_id,
                        principalTable: "location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_painting_author_id",
                table: "painting",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_painting_location_id",
                table: "painting",
                column: "location_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "painting");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "location");
        }
    }
}
