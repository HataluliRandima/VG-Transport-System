using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VG_TransportAPI.Models;

public partial class VgtransportContext : DbContext
{
    public VgtransportContext()
    {
    }

    public VgtransportContext(DbContextOptions<VgtransportContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<DriverStorage> DriverStorages { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-K9P6HGH\\SQLEXPRESS;Database=VGTransport;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BId);

            entity.ToTable("Booking");

            entity.Property(e => e.BId).HasColumnName("B_id");
            entity.Property(e => e.BAmountelocal)
                .IsUnicode(false)
                .HasColumnName("B_amountelocal");
            entity.Property(e => e.BAmountesti)
                .IsUnicode(false)
                .HasColumnName("B_amountesti");
            entity.Property(e => e.BCartype)
                .IsUnicode(false)
                .HasColumnName("B_cartype");
            entity.Property(e => e.BDate)
                .HasColumnType("date")
                .HasColumnName("B_Date");
            entity.Property(e => e.BInitam)
                .IsUnicode(false)
                .HasColumnName("B_initam");
            entity.Property(e => e.BLd1)
                .IsUnicode(false)
                .HasColumnName("B_LD1");
            entity.Property(e => e.BLd2)
                .IsUnicode(false)
                .HasColumnName("B_LD2");
            entity.Property(e => e.BLd3)
                .IsUnicode(false)
                .HasColumnName("B_LD3");
            entity.Property(e => e.BLd4)
                .IsUnicode(false)
                .HasColumnName("B_LD4");
            entity.Property(e => e.BLf1)
                .IsUnicode(false)
                .HasColumnName("B_LF1");
            entity.Property(e => e.BLf2)
                .IsUnicode(false)
                .HasColumnName("B_LF2");
            entity.Property(e => e.BLf3)
                .IsUnicode(false)
                .HasColumnName("B_LF3");
            entity.Property(e => e.BLf4)
                .IsUnicode(false)
                .HasColumnName("B_LF4");
            entity.Property(e => e.BNameproduct)
                .IsUnicode(false)
                .HasColumnName("B_nameproduct");
            entity.Property(e => e.BProddesc)
                .IsUnicode(false)
                .HasColumnName("B_proddesc");
            entity.Property(e => e.BStatus)
                .IsUnicode(false)
                .HasColumnName("B_status");
            entity.Property(e => e.BTime).HasColumnName("B_Time");
            entity.Property(e => e.BUrl)
                .IsUnicode(false)
                .HasColumnName("B_url");
            entity.Property(e => e.BUrlcode)
                .IsUnicode(false)
                .HasColumnName("B_urlcode");
            entity.Property(e => e.CId).HasColumnName("C_id");

            entity.HasOne(d => d.CIdNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_Customer");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CrId);

            entity.ToTable("Car");

            entity.Property(e => e.CrId).HasColumnName("CR_id");
            entity.Property(e => e.CrDescription)
                .IsUnicode(false)
                .HasColumnName("CR_Description");
            entity.Property(e => e.CrModel)
                .IsUnicode(false)
                .HasColumnName("CR_model");
            entity.Property(e => e.CrName)
                .IsUnicode(false)
                .HasColumnName("CR_name");
            entity.Property(e => e.CrPaper1)
                .IsUnicode(false)
                .HasColumnName("CR_paper1");
            entity.Property(e => e.CrPaper2)
                .IsUnicode(false)
                .HasColumnName("CR_paper2");
            entity.Property(e => e.CrRegPlate)
                .IsUnicode(false)
                .HasColumnName("CR_RegPlate");
            entity.Property(e => e.CrType)
                .IsUnicode(false)
                .HasColumnName("CR_type");
            entity.Property(e => e.DId).HasColumnName("D_id");

            entity.HasOne(d => d.DIdNavigation).WithMany(p => p.Cars)
                .HasForeignKey(d => d.DId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Car_Driver");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CId);

            entity.ToTable("Customer");

            entity.Property(e => e.CId).HasColumnName("C_id");
            entity.Property(e => e.CAdd1)
                .IsUnicode(false)
                .HasColumnName("C_add1");
            entity.Property(e => e.CAdd2)
                .IsUnicode(false)
                .HasColumnName("C_add2");
            entity.Property(e => e.CAdd3)
                .IsUnicode(false)
                .HasColumnName("C_add3");
            entity.Property(e => e.CAdd4)
                .IsUnicode(false)
                .HasColumnName("C_add4");
            entity.Property(e => e.CBlocked)
                .IsUnicode(false)
                .HasColumnName("C_blocked");
            entity.Property(e => e.CEmail)
                .IsUnicode(false)
                .HasColumnName("C_email");
            entity.Property(e => e.CName)
                .IsUnicode(false)
                .HasColumnName("C_name");
            entity.Property(e => e.CNumber)
                .IsUnicode(false)
                .HasColumnName("C_number");
            entity.Property(e => e.CPassword)
                .IsUnicode(false)
                .HasColumnName("C_password");
            entity.Property(e => e.CStatus)
                .IsUnicode(false)
                .HasColumnName("C_status");
            entity.Property(e => e.CSurname)
                .IsUnicode(false)
                .HasColumnName("C_surname");
            entity.Property(e => e.CUrl)
                .IsUnicode(false)
                .HasColumnName("C_url");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DId);

            entity.ToTable("Driver");

            entity.Property(e => e.DId).HasColumnName("D_id");
            entity.Property(e => e.DAdd1)
                .IsUnicode(false)
                .HasColumnName("D_add1");
            entity.Property(e => e.DAdd2)
                .IsUnicode(false)
                .HasColumnName("D_add2");
            entity.Property(e => e.DAdd3)
                .IsUnicode(false)
                .HasColumnName("D_add3");
            entity.Property(e => e.DAdd4)
                .IsUnicode(false)
                .HasColumnName("D_add4");
            entity.Property(e => e.DBlocked)
                .IsUnicode(false)
                .HasColumnName("D_blocked");
            entity.Property(e => e.DEmail)
                .IsUnicode(false)
                .HasColumnName("D_email");
            entity.Property(e => e.DName)
                .IsUnicode(false)
                .HasColumnName("D_name");
            entity.Property(e => e.DPassword)
                .IsUnicode(false)
                .HasColumnName("D_password");
            entity.Property(e => e.DPhone)
                .IsUnicode(false)
                .HasColumnName("D_phone");
            entity.Property(e => e.DStatus)
                .IsUnicode(false)
                .HasColumnName("D_status");
            entity.Property(e => e.DSurname)
                .IsUnicode(false)
                .HasColumnName("D_surname");
            entity.Property(e => e.DUrl)
                .IsUnicode(false)
                .HasColumnName("D_url");
        });

        modelBuilder.Entity<DriverStorage>(entity =>
        {
            entity.HasKey(e => e.DsId);

            entity.ToTable("DriverStorage");

            entity.Property(e => e.DsId).HasColumnName("Ds_id");
            entity.Property(e => e.DsDoc1)
                .IsUnicode(false)
                .HasColumnName("Ds_Doc1");
            entity.Property(e => e.DsDoc2)
                .IsUnicode(false)
                .HasColumnName("Ds_Doc2");
            entity.Property(e => e.DsDoc3)
                .IsUnicode(false)
                .HasColumnName("Ds_Doc3");
            entity.Property(e => e.DsEmail)
                .IsUnicode(false)
                .HasColumnName("Ds_email");
            entity.Property(e => e.DsName)
                .IsUnicode(false)
                .HasColumnName("Ds_name");
            entity.Property(e => e.DsNumber)
                .IsUnicode(false)
                .HasColumnName("Ds_number");
            entity.Property(e => e.DsStatus)
                .IsUnicode(false)
                .HasColumnName("Ds_status");
            entity.Property(e => e.DsStatusAct)
                .IsUnicode(false)
                .HasColumnName("Ds_statusAct");
            entity.Property(e => e.DsSurname)
                .IsUnicode(false)
                .HasColumnName("Ds_surname");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FId);

            entity.ToTable("Feedback");

            entity.Property(e => e.FId).HasColumnName("F_id");
            entity.Property(e => e.CId).HasColumnName("C_id");
            entity.Property(e => e.DId).HasColumnName("D_id");
            entity.Property(e => e.FMessageC)
                .IsUnicode(false)
                .HasColumnName("F_messageC");
            entity.Property(e => e.FMessageD)
                .IsUnicode(false)
                .HasColumnName("F_messageD");
            entity.Property(e => e.FRateC)
                .IsUnicode(false)
                .HasColumnName("F_rateC");
            entity.Property(e => e.FRateD)
                .IsUnicode(false)
                .HasColumnName("F_rateD");
            entity.Property(e => e.OId).HasColumnName("O_id");

            entity.HasOne(d => d.CIdNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CId)
                .HasConstraintName("FK_Feedback_Customer");

            entity.HasOne(d => d.DIdNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.DId)
                .HasConstraintName("FK_Feedback_Driver");

            entity.HasOne(d => d.OIdNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.OId)
                .HasConstraintName("FK_Feedback_Order");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OId);

            entity.ToTable("Order");

            entity.Property(e => e.OId).HasColumnName("O_id");
            entity.Property(e => e.BId).HasColumnName("B_id");
            entity.Property(e => e.CId).HasColumnName("C_id");
            entity.Property(e => e.DId).HasColumnName("D_id");
            entity.Property(e => e.OAmtesti)
                .IsUnicode(false)
                .HasColumnName("O_amtesti");
            entity.Property(e => e.ODesc)
                .IsUnicode(false)
                .HasColumnName("O_desc");
            entity.Property(e => e.ODetailRec1)
                .IsUnicode(false)
                .HasColumnName("O_DetailRec1");
            entity.Property(e => e.ODetailRec2)
                .IsUnicode(false)
                .HasColumnName("O_DetailRec2");
            entity.Property(e => e.ODetailRec3)
                .IsUnicode(false)
                .HasColumnName("O_DetailRec3");
            entity.Property(e => e.ODetailSen1)
                .IsUnicode(false)
                .HasColumnName("O_DetailSen1");
            entity.Property(e => e.ODetailSen2)
                .IsUnicode(false)
                .HasColumnName("O_DetailSen2");
            entity.Property(e => e.ODetailSen3)
                .IsUnicode(false)
                .HasColumnName("O_DetailSen3");
            entity.Property(e => e.OPaydriver)
                .IsUnicode(false)
                .HasColumnName("O_paydriver");
            entity.Property(e => e.OStatus)
                .IsUnicode(false)
                .HasColumnName("O_status");
            entity.Property(e => e.OStatus1)
                .IsUnicode(false)
                .HasColumnName("O_status1");
            entity.Property(e => e.OUrlcode)
                .IsUnicode(false)
                .HasColumnName("O_urlcode");

            entity.HasOne(d => d.BIdNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.BId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Booking");

            entity.HasOne(d => d.CIdNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CId)
                .HasConstraintName("FK_Order_Customer");

            entity.HasOne(d => d.DIdNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DId)
                .HasConstraintName("FK_Order_Driver");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PId);

            entity.ToTable("Payment");

            entity.Property(e => e.PId).HasColumnName("P_id");
            entity.Property(e => e.CId).HasColumnName("C_id");
            entity.Property(e => e.OId).HasColumnName("O_id");
            entity.Property(e => e.PAmount)
                .IsUnicode(false)
                .HasColumnName("P_amount");
            entity.Property(e => e.PPaydrive)
                .IsUnicode(false)
                .HasColumnName("P_paydrive");
            entity.Property(e => e.PStatus)
                .IsUnicode(false)
                .HasColumnName("P_status");
            entity.Property(e => e.PTotamount)
                .IsUnicode(false)
                .HasColumnName("P_totamount");
            entity.Property(e => e.PType)
                .IsUnicode(false)
                .HasColumnName("P_type");

            entity.HasOne(d => d.CIdNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CId)
                .HasConstraintName("FK_Payment_Customer");

            entity.HasOne(d => d.OIdNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Order");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
