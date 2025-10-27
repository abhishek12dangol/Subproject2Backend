using Microsoft.EntityFrameworkCore;
using IMDB.DataServiceLayer.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;

namespace IMDB.DataServiceLayer;

public class ImdbContext : DbContext
{
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<PersonKnownFor> PersonKnownFors { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=imdb;Username=postgres;Password=root");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>().ToTable("appuser");
        modelBuilder.Entity<AppUser>().HasKey(u => u.Id);
        modelBuilder.Entity<AppUser>().Property(u => u.Id).HasColumnName("user_id");
        modelBuilder.Entity<AppUser>().Property(u => u.Email).HasColumnName("email");
        modelBuilder.Entity<AppUser>().Property(u => u.Username).HasColumnName("username");
        modelBuilder.Entity<AppUser>().Property(u => u.Password).HasColumnName("password");
        modelBuilder.Entity<AppUser>().Property(u => u.CreatedAt).HasColumnName("created_at")
            .HasDefaultValueSql("NOW()");
        modelBuilder.Entity<AppUser>().Property(u => u.LastLoginAt).HasColumnName("last_login_at");
        modelBuilder.Entity<AppUser>().Property(u => u.Status).HasColumnName("status");
        
        modelBuilder.Entity<Movie>().ToTable("movie");
        modelBuilder.Entity<Movie>().HasKey(m => m.Id);
        modelBuilder.Entity<Movie>().Property(m => m.Id).HasColumnName("movie_id");
        modelBuilder.Entity<Movie>().Property(m => m.Tconst).HasColumnName("tconst");
        modelBuilder.Entity<Movie>().Property(m => m.TitleType).HasColumnName("title_type");
        modelBuilder.Entity<Movie>().Property(m => m.PrimaryTitle).HasColumnName("primary_title");
        modelBuilder.Entity<Movie>().Property(m => m.OriginalTitle).HasColumnName("original_title");
        modelBuilder.Entity<Movie>().Property(m => m.IsAdult).HasColumnName("is_adult");
        modelBuilder.Entity<Movie>().Property(m => m.StartYear).HasColumnName("start_year");
        modelBuilder.Entity<Movie>().Property(m => m.EndYear).HasColumnName("end_year");
        modelBuilder.Entity<Movie>().Property(m => m.RunTimeMinutes).HasColumnName("runtime_minutes");
        modelBuilder.Entity<Movie>().Property(m => m.PlotSummary).HasColumnName("plot_summary");
        modelBuilder.Entity<Movie>().Property(m => m.PosterUrl).HasColumnName("poster_url");
        
        modelBuilder.Entity<Person>().ToTable("person");
        modelBuilder.Entity<Person>().HasKey(p => p.PersonId);
        modelBuilder.Entity<Person>().Property(p => p.PersonId).HasColumnName("person_id");
        modelBuilder.Entity<Person>().Property(p => p.Nconst).HasColumnName("nconst");
        modelBuilder.Entity<Person>().Property(p => p.PrimaryName).HasColumnName("primary_name");
        modelBuilder.Entity<Person>().Property(p => p.BirthYear).HasColumnName("birth_year");
        modelBuilder.Entity<Person>().Property(p => p.DeathYear).HasColumnName("death_year");
        
        modelBuilder.Entity<PersonKnownFor>().ToTable("personknownfor");
        modelBuilder.Entity<PersonKnownFor>().HasKey(pk => new { pk.PersonId, pk.MovieId});
        modelBuilder.Entity<PersonKnownFor>().Property(pk => pk.PersonId).HasColumnName("person_id");
        modelBuilder.Entity<PersonKnownFor>().Property(pk => pk.MovieId).HasColumnName("movie_id");
        modelBuilder.Entity<PersonKnownFor>().HasOne(pk => pk.Person).WithMany(p => p.KnownFors)
            .HasForeignKey(pk => pk.PersonId);
        modelBuilder.Entity<PersonKnownFor>().HasOne(pk => pk.Movie).WithMany(m => m.KnownFors)
            .HasForeignKey(pk => pk.MovieId);
    }
}