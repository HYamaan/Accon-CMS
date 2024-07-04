using AcconAPI.Domain.Auth;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Faq;
using AcconAPI.Domain.Entities.File;
using AcconAPI.Domain.Entities.File.News;
using AcconAPI.Domain.Entities.File.Portfolio;
using AcconAPI.Domain.Entities.File.Service;
using AcconAPI.Domain.Entities.File.Testimonial;
using AcconAPI.Domain.Entities.File.WhyChooseUs;
using AcconAPI.Domain.Entities.Language;
using AcconAPI.Domain.Entities.News;
using AcconAPI.Domain.Entities.Page;
using AcconAPI.Domain.Entities.Partner;
using AcconAPI.Domain.Entities.Portfolio;
using AcconAPI.Domain.Entities.Service;
using AcconAPI.Domain.Entities.Slider;
using AcconAPI.Domain.Entities.SocialMedia;
using AcconAPI.Domain.Entities.TeamMember;
using AcconAPI.Domain.Entities.Testimonial;
using AcconAPI.Domain.Entities.WhyChooseUs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using File = AcconAPI.Domain.Entities.File.File;
using Gallery = AcconAPI.Domain.Entities.Gallery.Gallery;

namespace AcconAPI.Persistence.Context;

public class AcconAPIDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public AcconAPIDbContext(DbContextOptions<AcconAPIDbContext> options) : base(options)
    {
    }

    public DbSet<File> ImageFiles { get; set; }
    public DbSet<Faq> Faqs { get; set; }
    public DbSet<Gallery> Galleries { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<News>News { get; set; }
    public DbSet<NewsCategory> NewsCategories { get; set; }
    public DbSet<Partner> Partners { get; set; }
    public DbSet<PortfolioCategory> PortfolioCategories { get; set; }
    public DbSet<ServiceSection> ServiceSections { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }

    public DbSet<Designation> Designations { get; set; }
    public DbSet<TeamMember> TeamMembers { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<WhyChoose> WhyChooses { get; set; }

    public DbSet<PageEntity> Pages { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Discriminator column ayarı
        modelBuilder.Entity<File>()
            .HasDiscriminator<string>("FileType")
            .HasValue<NewsBanner>("NewsBanner")
            .HasValue<TestimonialPhoto>("TestimonialPhoto")
            .HasValue<PartnerPhoto>("PartnerPhoto")
            .HasValue<NewsPhoto>("NewsPhoto")
            .HasValue<BannerPhoto>("BannerPhoto")
            .HasValue<FeaturedPhoto>("FeaturedPhoto")
            .HasValue<OtherPhotos>("OtherPhotos")
            .HasValue<ServiceBanner>("ServiceBanner")
            .HasValue<ServicePhoto>("ServicePhoto")
            .HasValue<TestimonialMainPhoto>("TestimonialMain")
            .HasValue<ChooseUsIconPhoto>("ChooseUsIcon")
            .HasValue<ChooseUsMainPhoto>("ChooseUsMainPhoto")
            .HasValue<ChooseUseBackgroundPhoto>("ChooseUsBackgroundPhoto")
            .HasValue<AboutPagePhoto>("AboutPagePhotos")
            .HasValue<FaqMainPhoto>("FaqMainPhotos")
            .HasValue<GalleryPhoto>("GalleryPhotos")
            .HasValue<PartnerPhoto>("PartnerPhotos")
            .HasValue<SliderPhoto>("SliderPhotos")
            .HasValue<TeamMemberPhoto>("TeamMemberPhotos");

        modelBuilder.Entity<PageEntity>()
            .HasDiscriminator<string>("Page")
            .HasValue<AboutPage>("AboutPage")
            .HasValue<ContactPage>("ContactPage")
            .HasValue<FaqPage>("FaqPage")
            .HasValue<GalleryPage>("GalleryPage")
            .HasValue<HomePage>("HomePage")
            .HasValue<NewsPage>("NewsPage")
            .HasValue<PortfolioPage>("PortfolioPage")
            .HasValue<PrivacyPage>("PrivacyPage")
            .HasValue<ServicePage>("ServicePage")
            .HasValue<TermsPage>("TermsPage")
            .HasValue<TestimonialPage>("TestimonialPage");

    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var datas = ChangeTracker.Entries<BaseEntity>();
        foreach (var data in datas)
        {
            var currentTime = DateTime.UtcNow;
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreatedDate = currentTime,
                EntityState.Modified => data.Entity.UpdatedDate = currentTime,
                _ => currentTime
            };
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}
