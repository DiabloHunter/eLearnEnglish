using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eLearnEnglish_ASP.Data.Migrations
{
    public partial class addfirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AddColumn<int>(
                name: "VocabularyId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Music",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MusicUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vocabulary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vocabulary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Word",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exprassion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WordTranslation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Example = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExampleTranslation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Word", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VocabularyWord",
                columns: table => new
                {
                    VocabularyId = table.Column<int>(type: "int", nullable: false),
                    WordsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyWord", x => new { x.VocabularyId, x.WordsId });
                    table.ForeignKey(
                        name: "FK_VocabularyWord_Vocabulary_VocabularyId",
                        column: x => x.VocabularyId,
                        principalTable: "Vocabulary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VocabularyWord_Word_WordsId",
                        column: x => x.WordsId,
                        principalTable: "Word",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_VocabularyId",
                table: "AspNetUsers",
                column: "VocabularyId");

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyWord_WordsId",
                table: "VocabularyWord",
                column: "WordsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Vocabulary_VocabularyId",
                table: "AspNetUsers",
                column: "VocabularyId",
                principalTable: "Vocabulary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Vocabulary_VocabularyId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Music");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "VocabularyWord");

            migrationBuilder.DropTable(
                name: "Vocabulary");

            migrationBuilder.DropTable(
                name: "Word");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_VocabularyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VocabularyId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "MusicModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusicUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoModel", x => x.Id);
                });
        }
    }
}
