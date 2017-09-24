using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BsacTimetableCore.DBContextAndModelsfolder
{
    public partial class bsac_timetableContext : DbContext
    {
        public bsac_timetableContext(DbContextOptions<bsac_timetableContext> options) : base(options)
        {
        }
        public virtual DbSet<Cancellation> Cancellation { get; set; }
        public virtual DbSet<Chair> Chair { get; set; }
        public virtual DbSet<Classroom> Classroom { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<Flow> Flow { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Lecturer> Lecturer { get; set; }
        public virtual DbSet<Record> Record { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<SubjectFor> SubjectFor { get; set; }
        public virtual DbSet<SubjectType> SubjectType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cancellation>(entity =>
            {
                entity.HasKey(e => e.IdCancellation);

                entity.ToTable("cancellation");

                entity.HasIndex(e => e.IdRecord)
                    .HasName("fk_cancellation_main1");

                entity.Property(e => e.IdCancellation)
                    .HasColumnName("id_cancellation")
                    .HasColumnType("int(10) unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdRecord)
                    .HasColumnName("id_record")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.IdRecordNavigation)
                    .WithMany(p => p.Cancellation)
                    .HasForeignKey(d => d.IdRecord)
                    .HasConstraintName("fk_cancellation_main1");
            });

            modelBuilder.Entity<Chair>(entity =>
            {
                entity.HasKey(e => e.IdChair);

                entity.ToTable("chair");

                entity.HasIndex(e => e.NameChair)
                    .HasName("name_chair_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdChair)
                    .HasColumnName("id_chair")
                    .HasColumnType("tinyint(2) unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameChair)
                    .IsRequired()
                    .HasColumnName("name_chair")
                    .HasMaxLength(70)
                    .HasDefaultValueSql("Unknown");
            });

            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.HasKey(e => e.IdClassroom);

                entity.ToTable("classroom");

                entity.HasIndex(e => new { e.Name, e.Building })
                    .HasName("number_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdClassroom)
                    .HasColumnName("id_classroom")
                    .HasColumnType("smallint(3) unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Building)
                    .HasColumnName("building")
                    .HasColumnType("tinyint(2) unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.HasKey(e => e.IdFaculty);

                entity.ToTable("faculty");

                entity.HasIndex(e => e.NameFaculty)
                    .HasName("name_faculty_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdFaculty)
                    .HasColumnName("id_faculty")
                    .HasColumnType("tinyint(2) unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameFaculty)
                    .IsRequired()
                    .HasColumnName("name_faculty")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("Unknown");
            });

            modelBuilder.Entity<Flow>(entity =>
            {
                entity.HasKey(e => e.IdFlow);

                entity.ToTable("flow");

                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdFlow)
                    .HasColumnName("id_flow")
                    .HasColumnType("smallint(2) unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.IdGroup);

                entity.ToTable("group");

                entity.HasIndex(e => e.IdFaculty)
                    .HasName("id_fac_idx");

                entity.HasIndex(e => e.IdFlow)
                    .HasName("fk_groups_flows1_idx");

                entity.HasIndex(e => e.NameGroup)
                    .HasName("name_group_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdGroup)
                    .HasColumnName("id_group")
                    .HasColumnType("smallint(3) unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.EduLevel)
                    .HasColumnName("edu_level")
                    .HasColumnType("tinyint(2) unsigned");

                entity.Property(e => e.IdFaculty)
                    .HasColumnName("id_faculty")
                    .HasColumnType("tinyint(2) unsigned");

                entity.Property(e => e.IdFlow)
                    .HasColumnName("id_flow")
                    .HasColumnType("smallint(2) unsigned");

                entity.Property(e => e.NameGroup)
                    .IsRequired()
                    .HasColumnName("name_group")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("Unknown");

                entity.HasOne(d => d.IdFacultyNavigation)
                    .WithMany(p => p.Group)
                    .HasForeignKey(d => d.IdFaculty)
                    .HasConstraintName("id_fac");

                entity.HasOne(d => d.IdFlowNavigation)
                    .WithMany(p => p.Group)
                    .HasForeignKey(d => d.IdFlow)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_groups_flows1");
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.HasKey(e => e.IdLecturer);

                entity.ToTable("lecturer");

                entity.HasIndex(e => e.IdChair)
                    .HasName("id_chair_idx");

                entity.Property(e => e.IdLecturer)
                    .HasColumnName("id_lecturer")
                    .HasColumnType("smallint(3) unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdChair)
                    .HasColumnName("id_chair")
                    .HasColumnType("tinyint(2) unsigned");

                entity.Property(e => e.NameLecturer)
                    .IsRequired()
                    .HasColumnName("name_lecturer")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("Unknown");

                entity.HasOne(d => d.IdChairNavigation)
                    .WithMany(p => p.Lecturer)
                    .HasForeignKey(d => d.IdChair)
                    .HasConstraintName("id_chair_fk");
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.HasKey(e => e.IdRecord);

                entity.ToTable("record");

                entity.HasIndex(e => e.IdClassroom)
                    .HasName("fk_main_classroom1_idx");

                entity.HasIndex(e => e.IdGroup)
                    .HasName("id_group_idx");

                entity.HasIndex(e => e.IdLecturer)
                    .HasName("id_lect_idx");

                entity.HasIndex(e => e.IdSubject)
                    .HasName("id_subj_idx");

                entity.HasIndex(e => e.IdSubjectFor)
                    .HasName("fk_main_subject_for1_idx");

                entity.HasIndex(e => e.IdSubjectType)
                    .HasName("fk_main_subject_type1_idx");

                entity.Property(e => e.IdRecord)
                    .HasColumnName("id_record")
                    .HasColumnType("int(10) unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdClassroom)
                    .HasColumnName("id_classroom")
                    .HasColumnType("smallint(3) unsigned");

                entity.Property(e => e.IdGroup)
                    .HasColumnName("id_group")
                    .HasColumnType("smallint(3) unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IdLecturer)
                    .HasColumnName("id_lecturer")
                    .HasColumnType("smallint(3) unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IdSubject)
                    .HasColumnName("id_subject")
                    .HasColumnType("smallint(4) unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IdSubjectFor)
                    .HasColumnName("id_subject_for")
                    .HasColumnType("tinyint(2) unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IdSubjectType)
                    .HasColumnName("id_subject_type")
                    .HasColumnType("tinyint(2) unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.SubjOrdinalNumber)
                    .HasColumnName("subj_ordinal_number")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.WeekDay)
                    .HasColumnName("week_day")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.WeekNumber)
                    .HasColumnName("week_number")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.IdClassroomNavigation)
                    .WithMany(p => p.Record)
                    .HasForeignKey(d => d.IdClassroom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_main_classroom1");

                entity.HasOne(d => d.IdGroupNavigation)
                    .WithMany(p => p.Record)
                    .HasForeignKey(d => d.IdGroup)
                    .HasConstraintName("id_group");

                entity.HasOne(d => d.IdLecturerNavigation)
                    .WithMany(p => p.Record)
                    .HasForeignKey(d => d.IdLecturer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_lect");

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.Record)
                    .HasForeignKey(d => d.IdSubject)
                    .HasConstraintName("id_subj");

                entity.HasOne(d => d.IdSubjectForNavigation)
                    .WithMany(p => p.Record)
                    .HasForeignKey(d => d.IdSubjectFor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_main_subject_for1");

                entity.HasOne(d => d.IdSubjectTypeNavigation)
                    .WithMany(p => p.Record)
                    .HasForeignKey(d => d.IdSubjectType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_main_subject_type1");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.IdSubject);

                entity.ToTable("subject");

                entity.HasIndex(e => e.IdChair)
                    .HasName("id_chair_idx");

                entity.Property(e => e.IdSubject)
                    .HasColumnName("id_subject")
                    .HasColumnType("smallint(4) unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.AbnameSubject)
                    .IsRequired()
                    .HasColumnName("abname_subject")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("Unknown");

                entity.Property(e => e.EduLevel)
                    .HasColumnName("edu_level")
                    .HasColumnType("tinyint(2) unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IdChair)
                    .HasColumnName("id_chair")
                    .HasColumnType("tinyint(2) unsigned");

                entity.Property(e => e.NameSubject)
                    .IsRequired()
                    .HasColumnName("name_subject")
                    .HasMaxLength(80)
                    .HasDefaultValueSql("Unknown");

                entity.HasOne(d => d.IdChairNavigation)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.IdChair)
                    .HasConstraintName("id_chairS");
            });

            modelBuilder.Entity<SubjectFor>(entity =>
            {
                entity.ToTable("subject_for");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("tinyint(2) unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<SubjectType>(entity =>
            {
                entity.ToTable("subject_type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("tinyint(2) unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20);
            });
        }
    }
}
