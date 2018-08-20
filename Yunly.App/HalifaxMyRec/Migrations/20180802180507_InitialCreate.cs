using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yunly.App.Crawler.HalifaxMyRec.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecProgram",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProgramId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Location = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Instructor = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    StartDate = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    TotalSessions = table.Column<int>(nullable: true),
                    RemainingSessions = table.Column<int>(nullable: true),
                    TotalCapacity = table.Column<int>(nullable: true),
                    AvailableCapacity = table.Column<int>(nullable: true),
                    MinAgeMonths = table.Column<int>(nullable: true),
                    MaxAgeMonths = table.Column<int>(nullable: true),
                    SessionDurationMins = table.Column<int>(nullable: true),
                    PaymentPlanTemplateId = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    NextSessionStartDate = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Language = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    WholeCourseBookingType = table.Column<int>(nullable: true),
                    DirectDebitPayment = table.Column<bool>(nullable: true),
                    BlockBookingPayment = table.Column<bool>(nullable: true),
                    WeekDays = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    PaymentPlanAvailable = table.Column<bool>(nullable: true),
                    StartDateFormatted = table.Column<DateTime>(type: "datetime", nullable: true),
                    NextSessionStartDateFormatted = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecProgram", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecProgram");
        }
    }
}
