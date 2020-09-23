﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialNetwork;
using SocialNetwork.Models;

namespace SocialNetwork.Migrations
{
    [DbContext(typeof(Social_networkContext))]
    [Migration("20200913173428_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SocialNetwork.Friend", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddFriendDate")
                        .HasColumnType("date");

                    b.Property<long>("FriendId")
                        .HasColumnName("FriendID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnName("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FriendId");

                    b.HasIndex("UserId");

                    b.ToTable("Friend");
                });

            modelBuilder.Entity("SocialNetwork.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RecieveId")
                        .HasColumnName("RecieveID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("date");

                    b.Property<long>("SendId")
                        .HasColumnName("SendID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RecieveId");

                    b.HasIndex("SendId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("SocialNetwork.RequestFriend", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateSend")
                        .HasColumnType("date");

                    b.Property<long>("RecieveUserId")
                        .HasColumnName("RecieveUserID")
                        .HasColumnType("bigint");

                    b.Property<long>("SendUserId")
                        .HasColumnName("SendUserID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RecieveUserId");

                    b.HasIndex("SendUserId");

                    b.ToTable("RequestFriend");
                });

            modelBuilder.Entity("SocialNetwork.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("date");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SocialNetwork.Friend", b =>
                {
                    b.HasOne("SocialNetwork.User", "FriendNavigation")
                        .WithMany("FriendFriendNavigation")
                        .HasForeignKey("FriendId")
                        .HasConstraintName("FK_Friend_User1")
                        .IsRequired();

                    b.HasOne("SocialNetwork.User", "User")
                        .WithMany("FriendUser")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Friend_User")
                        .IsRequired();
                });

            modelBuilder.Entity("SocialNetwork.Message", b =>
                {
                    b.HasOne("SocialNetwork.User", "Recieve")
                        .WithMany("MessageRecieve")
                        .HasForeignKey("RecieveId")
                        .HasConstraintName("FK_Message_User1")
                        .IsRequired();

                    b.HasOne("SocialNetwork.User", "Send")
                        .WithMany("MessageSend")
                        .HasForeignKey("SendId")
                        .HasConstraintName("FK_Message_User")
                        .IsRequired();
                });

            modelBuilder.Entity("SocialNetwork.RequestFriend", b =>
                {
                    b.HasOne("SocialNetwork.User", "RecieveUser")
                        .WithMany("RequestFriendRecieveUser")
                        .HasForeignKey("RecieveUserId")
                        .HasConstraintName("FK_RequestFriend_User1")
                        .IsRequired();

                    b.HasOne("SocialNetwork.User", "SendUser")
                        .WithMany("RequestFriendSendUser")
                        .HasForeignKey("SendUserId")
                        .HasConstraintName("FK_RequestFriend_User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}