using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VG_TransportAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    C_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    C_surname = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    C_email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    C_password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    C_number = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    C_status = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    C_blocked = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    C_add1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    C_add2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    C_add3 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    C_add4 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    C_url = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.C_id);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    D_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    D_name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    D_surname = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    D_email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    D_phone = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    D_password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    D_add1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    D_add2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    D_add3 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    D_add4 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    D_status = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    D_blocked = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    D_url = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.D_id);
                });

            migrationBuilder.CreateTable(
                name: "DriverStorage",
                columns: table => new
                {
                    Ds_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ds_name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Ds_surname = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Ds_email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Ds_number = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Ds_status = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Ds_statusAct = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Ds_Doc1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Ds_Doc2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Ds_Doc3 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverStorage", x => x.Ds_id);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    B_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_id = table.Column<int>(type: "int", nullable: false),
                    B_Date = table.Column<DateTime>(type: "date", nullable: true),
                    B_Time = table.Column<TimeSpan>(type: "time", nullable: true),
                    B_status = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    B_urlcode = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    B_amountesti = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    B_amountelocal = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    B_nameproduct = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    B_proddesc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    B_initam = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    B_cartype = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    B_LF1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    B_LF2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    B_LF3 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    B_LF4 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    B_LD1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    B_LD2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    B_LD3 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    B_LD4 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    B_url = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.B_id);
                    table.ForeignKey(
                        name: "FK_Booking_Customer",
                        column: x => x.C_id,
                        principalTable: "Customer",
                        principalColumn: "C_id");
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CR_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CR_name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    CR_model = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CR_type = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CR_RegPlate = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CR_paper1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CR_paper2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CR_Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    D_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CR_id);
                    table.ForeignKey(
                        name: "FK_Car_Driver",
                        column: x => x.D_id,
                        principalTable: "Driver",
                        principalColumn: "D_id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    O_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    O_amtesti = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    O_DetailSen1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    O_DetailSen2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    O_DetailSen3 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    O_status = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    O_urlcode = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    B_id = table.Column<int>(type: "int", nullable: false),
                    D_id = table.Column<int>(type: "int", nullable: true),
                    O_DetailRec1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    O_DetailRec2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    O_DetailRec3 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    O_status1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    O_desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    O_paydriver = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    C_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.O_id);
                    table.ForeignKey(
                        name: "FK_Order_Booking",
                        column: x => x.B_id,
                        principalTable: "Booking",
                        principalColumn: "B_id");
                    table.ForeignKey(
                        name: "FK_Order_Customer",
                        column: x => x.C_id,
                        principalTable: "Customer",
                        principalColumn: "C_id");
                    table.ForeignKey(
                        name: "FK_Order_Driver",
                        column: x => x.D_id,
                        principalTable: "Driver",
                        principalColumn: "D_id");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    F_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_messageC = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    F_messageD = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    F_rateC = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    F_rateD = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    O_id = table.Column<int>(type: "int", nullable: true),
                    C_id = table.Column<int>(type: "int", nullable: true),
                    D_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.F_id);
                    table.ForeignKey(
                        name: "FK_Feedback_Customer",
                        column: x => x.C_id,
                        principalTable: "Customer",
                        principalColumn: "C_id");
                    table.ForeignKey(
                        name: "FK_Feedback_Driver",
                        column: x => x.D_id,
                        principalTable: "Driver",
                        principalColumn: "D_id");
                    table.ForeignKey(
                        name: "FK_Feedback_Order",
                        column: x => x.O_id,
                        principalTable: "Order",
                        principalColumn: "O_id");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    P_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P_type = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    P_status = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    P_amount = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    O_id = table.Column<int>(type: "int", nullable: false),
                    C_id = table.Column<int>(type: "int", nullable: true),
                    P_totamount = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    P_paydrive = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.P_id);
                    table.ForeignKey(
                        name: "FK_Payment_Customer",
                        column: x => x.C_id,
                        principalTable: "Customer",
                        principalColumn: "C_id");
                    table.ForeignKey(
                        name: "FK_Payment_Order",
                        column: x => x.O_id,
                        principalTable: "Order",
                        principalColumn: "O_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_C_id",
                table: "Booking",
                column: "C_id");

            migrationBuilder.CreateIndex(
                name: "IX_Car_D_id",
                table: "Car",
                column: "D_id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_C_id",
                table: "Feedback",
                column: "C_id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_D_id",
                table: "Feedback",
                column: "D_id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_O_id",
                table: "Feedback",
                column: "O_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_B_id",
                table: "Order",
                column: "B_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_C_id",
                table: "Order",
                column: "C_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_D_id",
                table: "Order",
                column: "D_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_C_id",
                table: "Payment",
                column: "C_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_O_id",
                table: "Payment",
                column: "O_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "DriverStorage");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
