using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixDiagramModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rooms_RoomId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.Sql(
                "ALTER TABLE \"Edges\" ALTER COLUMN \"TargetNodeId\" TYPE text USING \"TargetNodeId\"::text;");

            migrationBuilder.Sql(
                "ALTER TABLE \"Edges\" ALTER COLUMN \"SourceNodeId\" TYPE text USING \"SourceNodeId\"::text;");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rooms_RoomId",
                table: "Users",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rooms_RoomId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.Sql(
                "ALTER TABLE \"Edges\" ALTER COLUMN \"TargetNodeId\" TYPE integer USING \"TargetNodeId\"::integer;");

            migrationBuilder.Sql(
                "ALTER TABLE \"Edges\" ALTER COLUMN \"SourceNodeId\" TYPE integer USING \"SourceNodeId\"::integer;");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rooms_RoomId",
                table: "Users",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
