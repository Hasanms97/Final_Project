using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<Bankvisa> Bankvisas { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Categoryad> Categoryads { get; set; }
        public virtual DbSet<Commentt> Commentts { get; set; }
        public virtual DbSet<Contactusmessage> Contactusmessages { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Favoritenews> Favoritenews { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Follow> Follows { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<LikeDislike> LikeDislikes { get; set; }
        public virtual DbSet<Livetv> Livetvs { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Newsphoto> Newsphotos { get; set; }
        public virtual DbSet<Newsvideo> Newsvideos { get; set; }
        public virtual DbSet<Ourwebsite> Ourwebsites { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Replycommentt> Replycommentts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=JOR_FP1;PASSWORD=Fp.12345;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("JOR_FP1")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Advertisement>(entity =>
            {
                entity.ToTable("ADVERTISEMENT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Categoryadsid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CATEGORYADSID");

                entity.Property(e => e.Checkadminonads)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CHECKADMINONADS")
                    .HasDefaultValueSql("'NO'");

                entity.Property(e => e.Checkadmintopay)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CHECKADMINTOPAY")
                    .HasDefaultValueSql("'NO'");

                entity.Property(e => e.Datefrom)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEFROM");

                entity.Property(e => e.Dateto)
                    .HasColumnType("DATE")
                    .HasColumnName("DATETO");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Link)
                    .IsUnicode(false)
                    .HasColumnName("LINK");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.Property(e => e.Videopath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("VIDEOPATH");

                entity.HasOne(d => d.Categoryads)
                    .WithMany(p => p.Advertisements)
                    .HasForeignKey(d => d.Categoryadsid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ADVERTISEMENTCATEGORYADSID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Advertisements)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ADVERTISEMENTUSERID");
            });

            modelBuilder.Entity<Bankvisa>(entity =>
            {
                entity.ToTable("BANKVISA");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Availableamount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVAILABLEAMOUNT");

                entity.Property(e => e.Cardholdername)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CARDHOLDERNAME");

                entity.Property(e => e.Cardnumber)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CARDNUMBER");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CVV");

                entity.Property(e => e.Expirationdate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRATIONDATE");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Categoryad>(entity =>
            {
                entity.ToTable("CATEGORYADS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Durationinmonth)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATIONINMONTH");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Type)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<Commentt>(entity =>
            {
                entity.ToTable("COMMENTT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.DateComment)
                    .HasPrecision(6)
                    .HasColumnName("DATECOMMENT");

                entity.Property(e => e.Newsid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("NEWSID");

                entity.Property(e => e.Text)
                    .IsUnicode(false)
                    .HasColumnName("TEXT");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.Commentts)
                    .HasForeignKey(d => d.Newsid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NEWSIDCOMMENT");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Commentts)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_USERIDCOMMENT");
            });

            modelBuilder.Entity<Contactusmessage>(entity =>
            {
                entity.ToTable("CONTACTUSMESSAGE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Message)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Phone)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Respondadmin)
                    .IsUnicode(false)
                    .HasColumnName("RESPONDADMIN")
                    .HasDefaultValueSql("'No'");

                entity.Property(e => e.Subject)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");

                entity.Property(e => e.Websiteid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("WEBSITEID");

                entity.HasOne(d => d.Website)
                    .WithMany(p => p.Contactusmessages)
                    .HasForeignKey(d => d.Websiteid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_WEBSITE_ID");
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.ToTable("CONTENT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Pageid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PAGEID");

                entity.Property(e => e.Text)
                    .IsUnicode(false)
                    .HasColumnName("TEXT");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.Pageid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CONENTPAGE_ID");
            });

            modelBuilder.Entity<Favoritenews>(entity =>
            {
                entity.ToTable("FAVORITENEWS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Favoritenews)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CATEGORYIDFAVORITENEWS");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Favoritenews)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_USERIDFAVORITENEWS");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("FEEDBACK");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Checkadmin)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CHECKADMIN")
                    .HasDefaultValueSql("'NO'");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Evaluation)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EVALUATION");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_USERIDFEEDBACK");
            });

            modelBuilder.Entity<Follow>(entity =>
            {
                entity.ToTable("FOLLOW");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Pressmanid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PRESSMANID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Pressman)
                    .WithMany(p => p.FollowPressmen)
                    .HasForeignKey(d => d.Pressmanid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PRESSMANIDFOLLOW");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FollowUsers)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_USERIDFOLLOW");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("IMAGE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Imagepath)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Pageid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PAGEID");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.Pageid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_IMAGEPAGE_ID");
            });

            modelBuilder.Entity<LikeDislike>(entity =>
            {
                entity.ToTable("LIKE_DISLIKE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.DateLikedislike)
                    .HasPrecision(6)
                    .HasColumnName("DATELIKEDISLIKE");

                entity.Property(e => e.Newsid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("NEWSID");

                entity.Property(e => e.Type)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.LikeDislikes)
                    .HasForeignKey(d => d.Newsid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NEWSIDLIKEDISLIKE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LikeDislikes)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_USERIDLIKEDISLIKE");
            });

            modelBuilder.Entity<Livetv>(entity =>
            {
                entity.ToTable("LIVETV");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Imagepath)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Link)
                    .IsUnicode(false)
                    .HasColumnName("LINK");

                entity.Property(e => e.Tvname)
                    .IsUnicode(false)
                    .HasColumnName("TVNAME");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Password)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ROLEIDLOGIN");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_USERIDLOGIN");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("NEWS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Checkadmin)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CHECKADMIN")
                    .HasDefaultValueSql("'NO'");

                entity.Property(e => e.Country)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Newsdate)
                    .HasPrecision(6)
                    .HasColumnName("NEWSDATE");

                entity.Property(e => e.Newstitle)
                    .IsUnicode(false)
                    .HasColumnName("NEWSTITLE");

                entity.Property(e => e.UseridPressman)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERIDPRESSMAN");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CATEGORYIDNEWS");

                entity.HasOne(d => d.UseridPressmanNavigation)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.UseridPressman)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_USERIDPRESSMANNEWS");
            });

            modelBuilder.Entity<Newsphoto>(entity =>
            {
                entity.ToTable("NEWSPHOTOS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Newsid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("NEWSID");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.Newsphotos)
                    .HasForeignKey(d => d.Newsid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NEWSIDNEWSPHOTOS");
            });

            modelBuilder.Entity<Newsvideo>(entity =>
            {
                entity.ToTable("NEWSVIDEOS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Newsid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("NEWSID");

                entity.Property(e => e.Videopath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("VIDEOPATH");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.Newsvideos)
                    .HasForeignKey(d => d.Newsid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NEWSIDNEWSVIDEOS");
            });

            modelBuilder.Entity<Ourwebsite>(entity =>
            {
                entity.ToTable("OURWEBSITE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Copyright)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("COPYRIGHT");

                entity.Property(e => e.Costhostanddomainperyear)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COSTHOSTANDDOMAINPERYEAR");

                entity.Property(e => e.Country)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY");

                entity.Property(e => e.Fax)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("FAX");

                entity.Property(e => e.Linkfacebook)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("LINKFACEBOOK");

                entity.Property(e => e.Linkinstagram)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("LINKINSTAGRAM");

                entity.Property(e => e.Linklinkedin)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("LINKLINKEDIN");

                entity.Property(e => e.Linktwitter)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("LINKTWITTER");

                entity.Property(e => e.Logopath)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("LOGOPATH");

                entity.Property(e => e.Mappath)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("MAPPATH");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PHONENUMBER");

                entity.Property(e => e.Websitename)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("WEBSITENAME");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.ToTable("PAGE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Pagename)
                    .IsUnicode(false)
                    .HasColumnName("PAGENAME");

                entity.Property(e => e.Websiteid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("WEBSITEID");

                entity.HasOne(d => d.Website)
                    .WithMany(p => p.Pages)
                    .HasForeignKey(d => d.Websiteid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_WEBSITEID");
            });

            modelBuilder.Entity<Replycommentt>(entity =>
            {
                entity.ToTable("REPLYCOMMENTT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Commenttid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("COMMENTTID");

                entity.Property(e => e.DateReplycomment)
                    .HasPrecision(6)
                    .HasColumnName("DATE_REPLYCOMMENT");

                entity.Property(e => e.Text)
                    .IsUnicode(false)
                    .HasColumnName("TEXT");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Commentt)
                    .WithMany(p => p.Replycommentts)
                    .HasForeignKey(d => d.Commenttid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NEWSIDREPLYCOMMENTT");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Replycommentts)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_USERIDREPLYCOMMENTT");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Checkadmin)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CHECKADMIN")
                    .HasDefaultValueSql("'No'");

                entity.Property(e => e.Country)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFBIRTH");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Emailnotifications)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("EMAILNOTIFICATIONS")
                    .HasDefaultValueSql("'Yes'");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Gender)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH")
                    .HasDefaultValueSql("'Test.jpg'");

                entity.Property(e => e.Journalistcertificatepath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("JOURNALISTCERTIFICATEPATH")
                    .HasDefaultValueSql("'Test.pdf'");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Owner)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("OWNER")
                    .HasDefaultValueSql("'No'");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PHONENUMBER");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SALARY")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.ToTable("VIDEO");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Pageid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PAGEID");

                entity.Property(e => e.Videopath)
                    .IsUnicode(false)
                    .HasColumnName("VIDEOPATH");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.Pageid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_VIDEOPAGE_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
