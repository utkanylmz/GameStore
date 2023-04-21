using Core.Security.Entities;
using GameStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Persistance.Context
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GameDeveloper> GameDevelopers { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<GameType> GameTypes { get; set; }



        public BaseDbContext(DbContextOptions dbContextOptions,IConfiguration configuration):base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("GameStoreProjectConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(game => {
                game.ToTable("Games").HasKey(pk => pk.Id);
                game.Property(cl => cl.Id).HasColumnName("Id");
                game.Property(cl => cl.Name).HasColumnName("Name");
                game.Property(cl => cl.GameTypeId).HasColumnName("GameTypeId");
                game.Property(cl => cl.GameDeveleporId).HasColumnName("GameDeveleporId");
                game.Property(cl => cl.Price).HasColumnName("Price");
                game.Property(cl => cl.Platform).HasColumnName("Platform");
                game.Property(cl => cl.ReleaseDate).HasColumnName("ReleaseDate");
                
                });

            modelBuilder.Entity<GameDeveloper>(gamedevop =>
            {
                gamedevop.ToTable("GameDevelopers").HasKey(pk => pk.Id);
                gamedevop.Property(cl => cl.Id).HasColumnName("Id");
                gamedevop.Property(cl => cl.DeveloperCompanyName).HasColumnName("DeveloperCompanyName");
                gamedevop.Property(cl => cl.DeveloperCompanyMail).HasColumnName("DeveloperCompanyMail");
                gamedevop.Property(cl => cl.DeveloperCompanyCountry).HasColumnName("DeveloperCompanyCountry");

            });

            modelBuilder.Entity<GameType>(gametyp =>
            {
                gametyp.ToTable("GameTypes").HasKey(pk => pk.Id);
                gametyp.Property(cl => cl.Id).HasColumnName("Id");
                gametyp.Property(cl => cl.TypeName).HasColumnName("TypeName");
                gametyp.Property(cl => cl.TypeDescription).HasColumnName("TypeDescription");
                
            });

            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("Users").HasKey(pk => pk.Id);
                user.Property(cl => cl.Id).HasColumnName("Id");
                user.Property(cl => cl.FirstName).HasColumnName("FirstName");
                user.Property(cl => cl.LastName).HasColumnName("LastName");
                user.Property(cl => cl.Email).HasColumnName("Email");
                user.Property(cl => cl.TelNumber).HasColumnName("TelNumber");
                user.Property(cl => cl.BirthDate).HasColumnName("BirthDate");
                user.Property(cl => cl.IsActive).HasColumnName("Status");
                user.Property(cl=>cl.NickName).HasColumnName("NickName");
                user.Property(cl=>cl.PasswordHash).HasColumnName("PasswordHash");
                user.Property(cl=>cl.PasswordSalt).HasColumnName("PasswordSalt");
                

            });

           

           
            GameDeveloper[] gameDeveloperEntitySeeds =
            {
                new(1,"Valve","Valve@valve.com","Abd"),
                new(2,"EA Sport","EaSport@EaSport.com","Canada")
            };
            modelBuilder.Entity<GameDeveloper>().HasData(gameDeveloperEntitySeeds);

            GameType[] gameTypeEntitySeeds = {new(1,"Fps", "It is a type of video game in which the " +
                "player tries to shoot down enemies using a gun from a first-person perspective.") ,
            new(2,"Sport Game","Sports games are video games that aim to give players " +
            "the rules and experience of related sports by simulating various sports.")
            };

            modelBuilder.Entity<GameType>().HasData(gameTypeEntitySeeds);

            Game[] gameEntitySeeds =
            {
                new(1,"Cs Go",1,1,"Pc",DateTime.Now,120),
                new(2,"Fifa",2,2,"Pc/Console",DateTime.Now,600)
            };
            modelBuilder.Entity<Game>().HasData(gameEntitySeeds);



            //User[] userEntitySeeds =
            //{
            //    new(1,"Utkan","Yılmaz","Utkan@utkan.gmail.com",DateTime.Now,"0545545545",true,"utkanylmz"),
            //    new(2,"Hasan","Sanık","Hasan@sanık.gmail.com",DateTime.Now,"0532532532",true,"HsnSnk"),
            //};
            //modelBuilder.Entity<User>().HasData(userEntitySeeds);
        }
    }
}
