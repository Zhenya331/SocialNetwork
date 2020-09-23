using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Models
{
    public partial class Social_networkContext : DbContext
    {
        public Social_networkContext()
        {
            Database.EnsureCreated();
        }

        public Social_networkContext(DbContextOptions<Social_networkContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Friend> Friend { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<RequestFriend> RequestFriend { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddFriendDate).HasColumnType("date");

                entity.Property(e => e.FriendId).HasColumnName("FriendID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.FriendNavigation)
                    .WithMany(p => p.FriendFriendNavigation)
                    .HasForeignKey(d => d.FriendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Friend_User1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FriendUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Friend_User");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MessageText).IsRequired();

                entity.Property(e => e.RecieveId).HasColumnName("RecieveID");

                entity.Property(e => e.SendDate).HasColumnType("date");

                entity.Property(e => e.SendId).HasColumnName("SendID");

                entity.HasOne(d => d.Recieve)
                    .WithMany(p => p.MessageRecieve)
                    .HasForeignKey(d => d.RecieveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_User1");

                entity.HasOne(d => d.Send)
                    .WithMany(p => p.MessageSend)
                    .HasForeignKey(d => d.SendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_User");
            });

            modelBuilder.Entity<RequestFriend>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateSend).HasColumnType("date");

                entity.Property(e => e.RecieveUserId).HasColumnName("RecieveUserID");

                entity.Property(e => e.SendUserId).HasColumnName("SendUserID");

                entity.HasOne(d => d.RecieveUser)
                    .WithMany(p => p.RequestFriendRecieveUser)
                    .HasForeignKey(d => d.RecieveUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestFriend_User1");

                entity.HasOne(d => d.SendUser)
                    .WithMany(p => p.RequestFriendSendUser)
                    .HasForeignKey(d => d.SendUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestFriend_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateRegistration).HasColumnType("date");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
