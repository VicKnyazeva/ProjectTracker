using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTracker.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Completed = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTaskFields",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskFields", x => new { x.TaskId, x.Name });
                    table.ForeignKey(
                        name: "FK_ProjectTaskFields_ProjectTasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "ProjectTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "Id", "Description", "Name", "Priority", "ProjectId", "Status" },
                values: new object[] { 3, "task desc #2.1", "Task #2.1", 0, 3, 0 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Completed", "Created", "Description", "Name", "Priority", "Status" },
                values: new object[] { 2, null, new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "desc #2", "Project #2", 0, 0 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Completed", "Created", "Description", "Name", "Priority", "Status" },
                values: new object[] { 1, null, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "desc #1", "Project #1", 0, 1 });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "Id", "Description", "Name", "Priority", "ProjectId", "Status" },
                values: new object[] { 1, "task desc #1.1", "Task #1.1", 0, 1, 1 });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "Id", "Description", "Name", "Priority", "ProjectId", "Status" },
                values: new object[] { 2, "task desc #1.2", "Task #1.2", 0, 1, 0 });

            migrationBuilder.InsertData(
                table: "ProjectTaskFields",
                columns: new[] { "Name", "TaskId", "Value" },
                values: new object[] { "FIELD1", 2, "f 1" });

            migrationBuilder.InsertData(
                table: "ProjectTaskFields",
                columns: new[] { "Name", "TaskId", "Value" },
                values: new object[] { "Field1", 2, "f 1 low" });

            migrationBuilder.InsertData(
                table: "ProjectTaskFields",
                columns: new[] { "Name", "TaskId", "Value" },
                values: new object[] { "FIELD #2", 2, "f 1" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTaskFields");

            migrationBuilder.DropTable(
                name: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
