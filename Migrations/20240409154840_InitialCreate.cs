using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi_5b.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    AssignmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AssignmentPriority = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignment_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("06c65d54-2c86-40f7-ba8e-d0265486f1b5"), "Tareas relacionadas con el autocuidado, el desarrollo personal, pasatiempos, etc.", "Personal" },
                    { new Guid("1bbc3cae-8cea-48e1-9ba4-07ec45d981e0"), "Tareas relacionadas con la escuela, universidad, cursos, exámenes, etc.", "Estudios" },
                    { new Guid("4d7d29b4-f1c8-44f5-882b-14f0d586392f"), "Tareas relacionadas con eventos, reuniones con amigos, actividades sociales, etc.", "Social" },
                    { new Guid("6541e05c-69a6-4829-b037-86ddc19b1240"), "Tareas relacionadas con el presupuesto, pagos, inversiones, etc.", "Finanzas" },
                    { new Guid("8e50a50e-7347-458d-9b14-87b47a19103d"), "Tareas relacionadas con el ejercicio, la nutrición, las citas médicas, etc.", "Salud" },
                    { new Guid("9d728f3a-903b-4ba1-88c3-9f171b84b5a6"), "Tareas relacionadas con la planificación de viajes, reservas, preparativos, etc.", "Viajes" },
                    { new Guid("c2643f9a-06fd-4cc8-a95a-44d63536aa3a"), "Tareas que son simplemente recordatorios generales sin una categoría específica.", "Recordatorios" },
                    { new Guid("cb0ee61c-b0f3-439a-9315-3f2f589f71e0"), "Tareas relacionadas con proyectos personales o pasatiempos específicos.", "Proyectos personales" },
                    { new Guid("e530a381-1f4e-4f02-b04e-506e9e3ed818"), "Tareas domésticas como limpieza, compras, mantenimiento, etc.", "Hogar" },
                    { new Guid("ea6202de-5314-4ce0-903b-94fa7c8ef5ed"), "Tareas relacionadas con tu empleo, proyectos, reuniones, etc.", "Trabajo" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Name", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("46c33b69-cccf-44cb-99f3-d74454f77dc1"), "Christian Osorio", "cosorio", "cosorio" },
                    { new Guid("956f8f95-d67a-4501-96c6-b362fada236d"), "Usuario 5B", "user5b", "user5b" }
                });

            migrationBuilder.InsertData(
                table: "Assignment",
                columns: new[] { "AssignmentId", "AssignmentPriority", "CategoryId", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("0cc233a3-1739-44c1-9c1b-63ed5192b9a3"), 1, new Guid("1bbc3cae-8cea-48e1-9ba4-07ec45d981e0"), "Descripción de la tarea 2", "Tarea 2", new Guid("46c33b69-cccf-44cb-99f3-d74454f77dc1") },
                    { new Guid("74b5d8e3-f076-45ee-8981-9236c7d86895"), 2, new Guid("ea6202de-5314-4ce0-903b-94fa7c8ef5ed"), "Descripción de la tarea 1", "Tarea 1", new Guid("956f8f95-d67a-4501-96c6-b362fada236d") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_CategoryId",
                table: "Assignment",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_UserId",
                table: "Assignment",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
