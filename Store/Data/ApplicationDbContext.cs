using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Store.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        //public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        //public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        //public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<CheckEntry> CheckEntry { get; set; }
        public virtual DbSet<Checks> Checks { get; set; }
        public virtual DbSet<CpuclockFreqs> CpuclockFreqs { get; set; }
        public virtual DbSet<Cpumanufacturers> Cpumanufacturers { get; set; }
        public virtual DbSet<Cpumodels> Cpumodels { get; set; }
        public virtual DbSet<Cpus> Cpus { get; set; }
        public virtual DbSet<Cpuseries> Cpuseries { get; set; }
        public virtual DbSet<DirectXversions> DirectXversions { get; set; }
        public virtual DbSet<GalleryImagesPaths> GalleryImagesPaths { get; set; }
        public virtual DbSet<GalleryVideosPaths> GalleryVideosPaths { get; set; }
        public virtual DbSet<GameGenre> GameGenre { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<GpuVrams> GpuVrams { get; set; }
        public virtual DbSet<GpuclockFreqs> GpuclockFreqs { get; set; }
        public virtual DbSet<Gpumanufacturers> Gpumanufacturers { get; set; }
        public virtual DbSet<Gpumodels> Gpumodels { get; set; }
        public virtual DbSet<Gpus> Gpus { get; set; }
        public virtual DbSet<Gpuseries> Gpuseries { get; set; }
        public virtual DbSet<LibraryItem> LibraryItem { get; set; }
        public virtual DbSet<MagazineNote> MagazineNote { get; set; }
        public virtual DbSet<Magazines> Magazines { get; set; }
        public virtual DbSet<MinSysReqCpu> MinSysReqCpu { get; set; }
        public virtual DbSet<MinSysReqDirectXversion> MinSysReqDirectXversion { get; set; }
        public virtual DbSet<MinSysReqFreeSpace> MinSysReqFreeSpace { get; set; }
        public virtual DbSet<MinSysReqGpu> MinSysReqGpu { get; set; }
        public virtual DbSet<MinSysReqRamsize> MinSysReqRamsize { get; set; }
        public virtual DbSet<Platforms> Platforms { get; set; }
        public virtual DbSet<Ramsizes> Ramsizes { get; set; }
        public virtual DbSet<StorageFreeSpaces> StorageFreeSpaces { get; set; }
        public virtual DbSet<SysReqPlatform> SysReqPlatform { get; set; }
        public virtual DbSet<UsersReviews> UsersReviews { get; set; }
        public virtual DbSet<WishlistEntry> WishlistEntry { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=DESKTOP-FSH2FML\\DVISERVER;Database=Store;password=;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {/*
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });
            
            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });
            
            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ_Users_Email")
                    .IsUnique();

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });
            */
            modelBuilder.Entity<CheckEntry>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => new { e.GameId, e.Number })
                    .HasName("UQ_CheckEntry_GameID_Number")
                    .IsUnique();

                entity.Property(e => e.BasePrice).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CheckEntry_GameID");

                entity.HasOne(d => d.NumberNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Number)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CheckEntry_Number");
            });

            modelBuilder.Entity<Checks>(entity =>
            {
                entity.HasKey(e => e.Number);

                entity.HasIndex(e => new { e.Number, e.UserId })
                    .HasName("UQ_Checks_Number_User")
                    .IsUnique();

                entity.Property(e => e.CheckDatetime).HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.GeneralSum).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(/*p => p.Checks*/)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Checks_UserID");
            });

            modelBuilder.Entity<CpuclockFreqs>(entity =>
            {
                entity.ToTable("CPUClockFreqs");

                entity.HasIndex(e => e.FrequencyMgh)
                    .HasName("UQ_CPUClockFreqs_FrequencyMGh")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FrequencyMgh).HasColumnName("FrequencyMGh");
            });

            modelBuilder.Entity<Cpumanufacturers>(entity =>
            {
                entity.ToTable("CPUManufacturers");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_CPUManufacturers_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Cpumodels>(entity =>
            {
                entity.ToTable("CPUModels");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_CPUModels_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Cpus>(entity =>
            {
                entity.ToTable("CPUs");

                entity.HasIndex(e => new { e.ManufacturerId, e.ModelId, e.SeriesId, e.FrequencyMghId })
                    .HasName("UQ_CPUs")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FrequencyMghId).HasColumnName("FrequencyMGhID");

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.SeriesId).HasColumnName("SeriesID");

                entity.HasOne(d => d.FrequencyMgh)
                    .WithMany(p => p.Cpus)
                    .HasForeignKey(d => d.FrequencyMghId)
                    .HasConstraintName("FK_CPUs_FrequencyMGhID");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Cpus)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_CPUs_ManufacturerID");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Cpus)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_CPUs_ModelID");

                entity.HasOne(d => d.Series)
                    .WithMany(p => p.Cpus)
                    .HasForeignKey(d => d.SeriesId)
                    .HasConstraintName("FK_CPUs_SeriesID");
            });

            modelBuilder.Entity<Cpuseries>(entity =>
            {
                entity.ToTable("CPUSeries");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_CPUSeries_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DirectXversions>(entity =>
            {
                entity.ToTable("DirectXVersions");

                entity.HasIndex(e => e.Version)
                    .HasName("UQ_DirectXVersions_Version")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Version).HasMaxLength(30);
            });

            modelBuilder.Entity<GalleryImagesPaths>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.Path).IsRequired();

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GalleryImagesPaths)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GalleryImagesPaths");
            });

            modelBuilder.Entity<GalleryVideosPaths>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.Path).IsRequired();

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GalleryVideosPaths)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GalleryVideosPaths");
            });

            modelBuilder.Entity<GameGenre>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => new { e.GameId, e.GenreId })
                    .HasName("UQ_GameGenre")
                    .IsUnique();

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameGenre_GameID");

                entity.HasOne(d => d.Genre)
                    .WithMany()
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameGenre_GenreID");
            });

            modelBuilder.Entity<Games>(entity =>
            {
                entity.HasIndex(e => e.Title)
                    .HasName("UQ_Games_Title")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BasePrice).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.CoverPath).IsRequired();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasDefaultValueSql("('No description')");

                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(3, 2)")
                    .HasDefaultValueSql("((1.0))");

                entity.Property(e => e.FaviconPath)
                    .IsRequired()
                    .HasDefaultValueSql("('\\Store\\Data\\Images\\favicon.*')");

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(850);
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ_Genres_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<GpuVrams>(entity =>
            {
                entity.ToTable("GPU_VRAMs");

                entity.HasIndex(e => e.SizeMb)
                    .HasName("UQ_GPU_VRAMs_SizeMB")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SizeMb).HasColumnName("SizeMB");
            });

            modelBuilder.Entity<GpuclockFreqs>(entity =>
            {
                entity.ToTable("GPUClockFreqs");

                entity.HasIndex(e => e.FrequencyMgh)
                    .HasName("UQ_GPUClockFreqs_FrequencyMGh")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FrequencyMgh).HasColumnName("FrequencyMGh");
            });

            modelBuilder.Entity<Gpumanufacturers>(entity =>
            {
                entity.ToTable("GPUManufacturers");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_GPUManufacturers_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Gpumodels>(entity =>
            {
                entity.ToTable("GPUModels");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_GPUModels_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Gpus>(entity =>
            {
                entity.ToTable("GPUs");

                entity.HasIndex(e => new { e.ManufacturerId, e.ModelId, e.SeriesId, e.FrequencyMghId, e.VramMbId })
                    .HasName("UQ_GPUs")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FrequencyMghId).HasColumnName("FrequencyMGhID");

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.SeriesId).HasColumnName("SeriesID");

                entity.Property(e => e.VramMbId).HasColumnName("VRAM_MB_ID");

                entity.HasOne(d => d.FrequencyMgh)
                    .WithMany(p => p.Gpus)
                    .HasForeignKey(d => d.FrequencyMghId)
                    .HasConstraintName("FK_GPUs_FrequencyMGhID");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Gpus)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_GPUs_ManufacturerID");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Gpus)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_GPUs_ModelID");

                entity.HasOne(d => d.Series)
                    .WithMany(p => p.Gpus)
                    .HasForeignKey(d => d.SeriesId)
                    .HasConstraintName("FK_GPUs_SeriesID");

                entity.HasOne(d => d.VramMb)
                    .WithMany(p => p.Gpus)
                    .HasForeignKey(d => d.VramMbId)
                    .HasConstraintName("FK_GPUs_VRAM_MB_ID");
            });

            modelBuilder.Entity<Gpuseries>(entity =>
            {
                entity.ToTable("GPUSeries");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_GPUSeries_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LibraryItem>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => new { e.UserId, e.GameId })
                    .HasName("UQ_LibraryItem")
                    .IsUnique();

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LibraryItem_GameID");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LibraryItem_UserID");
            });

            modelBuilder.Entity<MagazineNote>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => new { e.MagazineId, e.GameId })
                    .HasName("UQ_MagazineNote_MagazineID_GameID")
                    .IsUnique();

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.MagazineId).HasColumnName("MagazineID");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MagazineNote_GameID");

                entity.HasOne(d => d.Magazine)
                    .WithMany()
                    .HasForeignKey(d => d.MagazineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MagazineNote_MagazineID");
            });

            modelBuilder.Entity<Magazines>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ_Magazines_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MinSysReqCpu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MinSysReqCPU");

                entity.HasIndex(e => new { e.Cpuid, e.GameId })
                    .HasName("UQ_MinSysReqCPU")
                    .IsUnique();

                entity.Property(e => e.Cpuid).HasColumnName("CPUID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.HasOne(d => d.Cpu)
                    .WithMany()
                    .HasForeignKey(d => d.Cpuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MinSysReqCPU_CPUID");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MinSysReqCPU_GameID");
            });

            modelBuilder.Entity<MinSysReqDirectXversion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MinSysReqDirectXVersion");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.VersionId).HasColumnName("VersionID");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MinSysReqDirectXVersion_GameID");

                entity.HasOne(d => d.Version)
                    .WithMany()
                    .HasForeignKey(d => d.VersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MinSysReqDirectXVersion_VersionID");
            });

            modelBuilder.Entity<MinSysReqFreeSpace>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FreeSpaceMbid).HasColumnName("FreeSpaceMBID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.HasOne(d => d.FreeSpaceMb)
                    .WithMany()
                    .HasForeignKey(d => d.FreeSpaceMbid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MinSysReqFreeSpace_FreeSpaceMBID");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MinSysReqFreeSpace_GameID");
            });

            modelBuilder.Entity<MinSysReqGpu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MinSysReqGPU");

                entity.HasIndex(e => new { e.Gpuid, e.GameId })
                    .HasName("UQ_MinSysReqGPU")
                    .IsUnique();

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.Gpuid).HasColumnName("GPUID");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MinSysReqGPU_GameID");

                entity.HasOne(d => d.Gpu)
                    .WithMany()
                    .HasForeignKey(d => d.Gpuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MinSysReqGPU_GPUID");
            });

            modelBuilder.Entity<MinSysReqRamsize>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MinSysReqRAMSize");

                entity.HasIndex(e => new { e.RamsizeId, e.GameId })
                    .HasName("UQ_MinSysReqRAMSize")
                    .IsUnique();

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.RamsizeId).HasColumnName("RAMSizeID");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MinSysReqRAMSize_GameID");

                entity.HasOne(d => d.Ramsize)
                    .WithMany()
                    .HasForeignKey(d => d.RamsizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MinSysReqRAMSize_RAMSizeID");
            });

            modelBuilder.Entity<Platforms>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ_Platforms_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Ramsizes>(entity =>
            {
                entity.ToTable("RAMSizes");

                entity.HasIndex(e => e.SizeMb)
                    .HasName("UQ_RAMSizes_SizeMB")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SizeMb).HasColumnName("SizeMB");
            });

            modelBuilder.Entity<StorageFreeSpaces>(entity =>
            {
                entity.HasIndex(e => e.FreeSpaceMb)
                    .HasName("UQ_StorageFreeSpaces_FreeSpaceMB")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FreeSpaceMb).HasColumnName("FreeSpaceMB");
            });

            modelBuilder.Entity<SysReqPlatform>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => new { e.GameId, e.PlatformId })
                    .HasName("UQ_SysReqPlatform")
                    .IsUnique();

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.PlatformId).HasColumnName("PlatformID");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SysReqPlatform_GameID");

                entity.HasOne(d => d.Platform)
                    .WithMany()
                    .HasForeignKey(d => d.PlatformId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SysReqPlatform_PlatformID");
            });

            modelBuilder.Entity<UsersReviews>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatetimeWritten).HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(450);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.UsersReviews)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersReviews_GameID");

                entity.HasOne(d => d.User)
                    .WithMany(/*p => p.UsersReviews*/)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersReviews_UserID");
            });

            modelBuilder.Entity<WishlistEntry>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => new { e.UserId, e.GameId })
                    .HasName("UQ_WishlistEntry")
                    .IsUnique();

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WishlistEntry_GameID");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WishlistEntry_UserID");
            });

            OnModelCreatingPartial(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
