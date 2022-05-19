using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ConsoleApp1
{
    public partial class DBContent : DbContext
    {
        public DBContent()
            : base("name=DBContent11")
        {
        }

        public virtual DbSet<TB_Address> TB_Address { get; set; }
        public virtual DbSet<TB_Admin> TB_Admin { get; set; }
        public virtual DbSet<TB_BLOCK> TB_BLOCK { get; set; }
        public virtual DbSet<TB_Broad> TB_Broad { get; set; }
        public virtual DbSet<TB_Com> TB_Com { get; set; }
        public virtual DbSet<TB_COMMENT> TB_COMMENT { get; set; }
        public virtual DbSet<TB_DISCUSS> TB_DISCUSS { get; set; }
        public virtual DbSet<TB_EXAMINE> TB_EXAMINE { get; set; }
        public virtual DbSet<TB_Followed> TB_Followed { get; set; }
        public virtual DbSet<TB_Friends> TB_Friends { get; set; }
        public virtual DbSet<TB_Goods> TB_Goods { get; set; }
        public virtual DbSet<TB_NumOfPost> TB_NumOfPost { get; set; }
        public virtual DbSet<TB_Order> TB_Order { get; set; }
        public virtual DbSet<TB_POST> TB_POST { get; set; }
        public virtual DbSet<TB_RECOMMEND> TB_RECOMMEND { get; set; }
        public virtual DbSet<TB_Req> TB_Req { get; set; }
        public virtual DbSet<TB_USER> TB_USER { get; set; }
        public virtual DbSet<TB_Collection> TB_Collection { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TB_Address>()
                .Property(e => e.Account)
                .IsFixedLength();

            modelBuilder.Entity<TB_Address>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Address>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Address>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Address>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Address>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Admin>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<TB_BLOCK>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Broad>()
                .Property(e => e.BroadContent)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Broad>()
                .Property(e => e.BroadTitle)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Com>()
                .Property(e => e.Account)
                .IsFixedLength();

            modelBuilder.Entity<TB_Com>()
                .Property(e => e.ComName)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Com>()
                .Property(e => e.ComTele)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Com>()
                .Property(e => e.ComAddress)
                .IsUnicode(false);

            modelBuilder.Entity<TB_COMMENT>()
                .Property(e => e.Userid)
                .IsUnicode(false);

            modelBuilder.Entity<TB_COMMENT>()
                .Property(e => e.CommentContent)
                .IsUnicode(false);

            modelBuilder.Entity<TB_DISCUSS>()
                .Property(e => e.Account)
                .IsFixedLength();

            modelBuilder.Entity<TB_DISCUSS>()
                .Property(e => e.Dicscuss)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Followed>()
                .Property(e => e.Account)
                .IsFixedLength();

            modelBuilder.Entity<TB_Followed>()
                .Property(e => e.FollowedAccount)
                .IsFixedLength();

            modelBuilder.Entity<TB_Friends>()
                .Property(e => e.Account)
                .IsFixedLength();

            modelBuilder.Entity<TB_Friends>()
                .Property(e => e.FriendAccount)
                .IsFixedLength();

            modelBuilder.Entity<TB_Goods>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Goods>()
                .Property(e => e.Introduce)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Goods>()
                .Property(e => e.Path)
                .IsUnicode(false);

            modelBuilder.Entity<TB_NumOfPost>()
                .Property(e => e.Userid)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Order>()
                .Property(e => e.Userid)
                .IsFixedLength();

            modelBuilder.Entity<TB_POST>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<TB_POST>()
                .Property(e => e.Userid)
                .IsUnicode(false);

            modelBuilder.Entity<TB_POST>()
                .Property(e => e.Lable)
                .IsUnicode(false);

            modelBuilder.Entity<TB_RECOMMEND>()
                .Property(e => e.Recommender)
                .IsUnicode(false);

            modelBuilder.Entity<TB_RECOMMEND>()
                .Property(e => e.Userid)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Req>()
                .Property(e => e.Account)
                .IsFixedLength();

            modelBuilder.Entity<TB_Req>()
                .Property(e => e.ReqAccount)
                .IsFixedLength();

            modelBuilder.Entity<TB_USER>()
                .Property(e => e.Account)
                .IsFixedLength();

            modelBuilder.Entity<TB_USER>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<TB_USER>()
                .Property(e => e.Nickname)
                .IsFixedLength();

            modelBuilder.Entity<TB_USER>()
                .Property(e => e.Region)
                .IsFixedLength();

            modelBuilder.Entity<TB_USER>()
                .Property(e => e.Sex)
                .IsFixedLength();

            modelBuilder.Entity<TB_USER>()
                .Property(e => e.Signature)
                .IsFixedLength();

            modelBuilder.Entity<TB_Collection>()
                .Property(e => e.Userid)
                .IsUnicode(false);
        }
    }
}
