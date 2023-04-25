﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VG_TransportAPI.Models;

#nullable disable

namespace VG_TransportAPI.Migrations
{
    [DbContext(typeof(VgtransportContext))]
    [Migration("20230425174924_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VG_TransportAPI.Models.Booking", b =>
                {
                    b.Property<int>("BId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("B_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BId"));

                    b.Property<string>("BAmountelocal")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("B_amountelocal");

                    b.Property<string>("BAmountesti")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("B_amountesti");

                    b.Property<string>("BCartype")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("B_cartype");

                    b.Property<DateTime?>("BDate")
                        .HasColumnType("date")
                        .HasColumnName("B_Date");

                    b.Property<string>("BInitam")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("B_initam");

                    b.Property<string>("BLd1")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("B_LD1");

                    b.Property<string>("BLd2")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("B_LD2");

                    b.Property<string>("BLd3")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("B_LD3");

                    b.Property<string>("BLd4")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("B_LD4");

                    b.Property<string>("BLf1")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("B_LF1");

                    b.Property<string>("BLf2")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("B_LF2");

                    b.Property<string>("BLf3")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("B_LF3");

                    b.Property<string>("BLf4")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("B_LF4");

                    b.Property<string>("BNameproduct")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("B_nameproduct");

                    b.Property<string>("BProddesc")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("B_proddesc");

                    b.Property<string>("BStatus")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("B_status");

                    b.Property<TimeSpan?>("BTime")
                        .HasColumnType("time")
                        .HasColumnName("B_Time");

                    b.Property<string>("BUrl")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("B_url");

                    b.Property<string>("BUrlcode")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("B_urlcode");

                    b.Property<int>("CId")
                        .HasColumnType("int")
                        .HasColumnName("C_id");

                    b.HasKey("BId");

                    b.HasIndex("CId");

                    b.ToTable("Booking", (string)null);
                });

            modelBuilder.Entity("VG_TransportAPI.Models.Car", b =>
                {
                    b.Property<int>("CrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CR_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CrId"));

                    b.Property<string>("CrDescription")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("CR_Description");

                    b.Property<string>("CrModel")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("CR_model");

                    b.Property<string>("CrName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("CR_name");

                    b.Property<string>("CrPaper1")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("CR_paper1");

                    b.Property<string>("CrPaper2")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("CR_paper2");

                    b.Property<string>("CrRegPlate")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("CR_RegPlate");

                    b.Property<string>("CrType")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("CR_type");

                    b.Property<int>("DId")
                        .HasColumnType("int")
                        .HasColumnName("D_id");

                    b.HasKey("CrId");

                    b.HasIndex("DId");

                    b.ToTable("Car", (string)null);
                });

            modelBuilder.Entity("VG_TransportAPI.Models.Customer", b =>
                {
                    b.Property<int>("CId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("C_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CId"));

                    b.Property<string>("CAdd1")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("C_add1");

                    b.Property<string>("CAdd2")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("C_add2");

                    b.Property<string>("CAdd3")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("C_add3");

                    b.Property<string>("CAdd4")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("C_add4");

                    b.Property<string>("CBlocked")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("C_blocked");

                    b.Property<string>("CEmail")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("C_email");

                    b.Property<string>("CName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("C_name");

                    b.Property<string>("CNumber")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("C_number");

                    b.Property<string>("CPassword")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("C_password");

                    b.Property<string>("CStatus")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("C_status");

                    b.Property<string>("CSurname")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("C_surname");

                    b.Property<string>("CUrl")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("C_url");

                    b.HasKey("CId");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("VG_TransportAPI.Models.Driver", b =>
                {
                    b.Property<int>("DId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("D_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DId"));

                    b.Property<string>("DAdd1")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("D_add1");

                    b.Property<string>("DAdd2")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("D_add2");

                    b.Property<string>("DAdd3")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("D_add3");

                    b.Property<string>("DAdd4")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("D_add4");

                    b.Property<string>("DBlocked")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("D_blocked");

                    b.Property<string>("DEmail")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("D_email");

                    b.Property<string>("DName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("D_name");

                    b.Property<string>("DPassword")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("D_password");

                    b.Property<string>("DPhone")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("D_phone");

                    b.Property<string>("DStatus")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("D_status");

                    b.Property<string>("DSurname")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("D_surname");

                    b.Property<string>("DUrl")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("D_url");

                    b.HasKey("DId");

                    b.ToTable("Driver", (string)null);
                });

            modelBuilder.Entity("VG_TransportAPI.Models.DriverStorage", b =>
                {
                    b.Property<int>("DsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Ds_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DsId"));

                    b.Property<string>("DsDoc1")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Ds_Doc1");

                    b.Property<string>("DsDoc2")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Ds_Doc2");

                    b.Property<string>("DsDoc3")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Ds_Doc3");

                    b.Property<string>("DsEmail")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Ds_email");

                    b.Property<string>("DsName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Ds_name");

                    b.Property<string>("DsNumber")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Ds_number");

                    b.Property<string>("DsStatus")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Ds_status");

                    b.Property<string>("DsStatusAct")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Ds_statusAct");

                    b.Property<string>("DsSurname")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Ds_surname");

                    b.HasKey("DsId");

                    b.ToTable("DriverStorage", (string)null);
                });

            modelBuilder.Entity("VG_TransportAPI.Models.Feedback", b =>
                {
                    b.Property<int>("FId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("F_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FId"));

                    b.Property<int?>("CId")
                        .HasColumnType("int")
                        .HasColumnName("C_id");

                    b.Property<int?>("DId")
                        .HasColumnType("int")
                        .HasColumnName("D_id");

                    b.Property<string>("FMessageC")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("F_messageC");

                    b.Property<string>("FMessageD")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("F_messageD");

                    b.Property<string>("FRateC")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("F_rateC");

                    b.Property<string>("FRateD")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("F_rateD");

                    b.Property<int?>("OId")
                        .HasColumnType("int")
                        .HasColumnName("O_id");

                    b.HasKey("FId");

                    b.HasIndex("CId");

                    b.HasIndex("DId");

                    b.HasIndex("OId");

                    b.ToTable("Feedback", (string)null);
                });

            modelBuilder.Entity("VG_TransportAPI.Models.Order", b =>
                {
                    b.Property<int>("OId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("O_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OId"));

                    b.Property<int>("BId")
                        .HasColumnType("int")
                        .HasColumnName("B_id");

                    b.Property<int?>("CId")
                        .HasColumnType("int")
                        .HasColumnName("C_id");

                    b.Property<int?>("DId")
                        .HasColumnType("int")
                        .HasColumnName("D_id");

                    b.Property<string>("OAmtesti")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("O_amtesti");

                    b.Property<string>("ODesc")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("O_desc");

                    b.Property<string>("ODetailRec1")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("O_DetailRec1");

                    b.Property<string>("ODetailRec2")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("O_DetailRec2");

                    b.Property<string>("ODetailRec3")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("O_DetailRec3");

                    b.Property<string>("ODetailSen1")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("O_DetailSen1");

                    b.Property<string>("ODetailSen2")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("O_DetailSen2");

                    b.Property<string>("ODetailSen3")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("O_DetailSen3");

                    b.Property<string>("OPaydriver")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("O_paydriver");

                    b.Property<string>("OStatus")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("O_status");

                    b.Property<string>("OStatus1")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("O_status1");

                    b.Property<string>("OUrlcode")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("O_urlcode");

                    b.HasKey("OId");

                    b.HasIndex("BId");

                    b.HasIndex("CId");

                    b.HasIndex("DId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("VG_TransportAPI.Models.Payment", b =>
                {
                    b.Property<int>("PId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("P_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PId"));

                    b.Property<int?>("CId")
                        .HasColumnType("int")
                        .HasColumnName("C_id");

                    b.Property<int>("OId")
                        .HasColumnType("int")
                        .HasColumnName("O_id");

                    b.Property<string>("PAmount")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("P_amount");

                    b.Property<string>("PPaydrive")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("P_paydrive");

                    b.Property<string>("PStatus")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("P_status");

                    b.Property<string>("PTotamount")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("P_totamount");

                    b.Property<string>("PType")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("P_type");

                    b.HasKey("PId");

                    b.HasIndex("CId");

                    b.HasIndex("OId");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("VG_TransportAPI.Models.Booking", b =>
                {
                    b.HasOne("VG_TransportAPI.Models.Customer", "CIdNavigation")
                        .WithMany("Bookings")
                        .HasForeignKey("CId")
                        .IsRequired()
                        .HasConstraintName("FK_Booking_Customer");

                    b.Navigation("CIdNavigation");
                });

            modelBuilder.Entity("VG_TransportAPI.Models.Car", b =>
                {
                    b.HasOne("VG_TransportAPI.Models.Driver", "DIdNavigation")
                        .WithMany("Cars")
                        .HasForeignKey("DId")
                        .IsRequired()
                        .HasConstraintName("FK_Car_Driver");

                    b.Navigation("DIdNavigation");
                });

            modelBuilder.Entity("VG_TransportAPI.Models.Feedback", b =>
                {
                    b.HasOne("VG_TransportAPI.Models.Customer", "CIdNavigation")
                        .WithMany("Feedbacks")
                        .HasForeignKey("CId")
                        .HasConstraintName("FK_Feedback_Customer");

                    b.HasOne("VG_TransportAPI.Models.Driver", "DIdNavigation")
                        .WithMany("Feedbacks")
                        .HasForeignKey("DId")
                        .HasConstraintName("FK_Feedback_Driver");

                    b.HasOne("VG_TransportAPI.Models.Order", "OIdNavigation")
                        .WithMany("Feedbacks")
                        .HasForeignKey("OId")
                        .HasConstraintName("FK_Feedback_Order");

                    b.Navigation("CIdNavigation");

                    b.Navigation("DIdNavigation");

                    b.Navigation("OIdNavigation");
                });

            modelBuilder.Entity("VG_TransportAPI.Models.Order", b =>
                {
                    b.HasOne("VG_TransportAPI.Models.Booking", "BIdNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("BId")
                        .IsRequired()
                        .HasConstraintName("FK_Order_Booking");

                    b.HasOne("VG_TransportAPI.Models.Customer", "CIdNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("CId")
                        .HasConstraintName("FK_Order_Customer");

                    b.HasOne("VG_TransportAPI.Models.Driver", "DIdNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("DId")
                        .HasConstraintName("FK_Order_Driver");

                    b.Navigation("BIdNavigation");

                    b.Navigation("CIdNavigation");

                    b.Navigation("DIdNavigation");
                });

            modelBuilder.Entity("VG_TransportAPI.Models.Payment", b =>
                {
                    b.HasOne("VG_TransportAPI.Models.Customer", "CIdNavigation")
                        .WithMany("Payments")
                        .HasForeignKey("CId")
                        .HasConstraintName("FK_Payment_Customer");

                    b.HasOne("VG_TransportAPI.Models.Order", "OIdNavigation")
                        .WithMany("Payments")
                        .HasForeignKey("OId")
                        .IsRequired()
                        .HasConstraintName("FK_Payment_Order");

                    b.Navigation("CIdNavigation");

                    b.Navigation("OIdNavigation");
                });

            modelBuilder.Entity("VG_TransportAPI.Models.Booking", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("VG_TransportAPI.Models.Customer", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Feedbacks");

                    b.Navigation("Orders");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("VG_TransportAPI.Models.Driver", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Feedbacks");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("VG_TransportAPI.Models.Order", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
