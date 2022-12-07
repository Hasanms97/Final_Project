using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newspaper.Core.Common;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using Newspaper.Infra.Common;
using Newspaper.Infra.Repository;
using Newspaper.Infra.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newspaper.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            //note//note//note//note//note//note//note//note//note//note



            //Session
            //services.AddDistributedMemoryCache();
            //services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(60)); //you can set time 

            //DbContext
            services.AddScoped<IDbContext, DbContext>();

            //User
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUserServices, UserServices>();

            //Role
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleServices, RoleServices>();

            //Login
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ILoginServices, LoginServices>();


            //AuthJWT
            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<String>("JWT:KeyJWT")))
                };
            });

            services.AddScoped<IAuthJWTRepository, AuthJWTRepository>();
            services.AddScoped<IAuthJWTServices, AuthJWTServices>();

            //Feedback
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IFeedbackServices, FeedbackServices>();

            //CategoryAds
            services.AddScoped<ICategoryAdsRepository, CategoryAdsRepository>();
            services.AddScoped<ICategoryAdsServices, CategoryAdsServices>();

            //Category
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryServices, CategoryServices>();

            //FavoriteNews
            services.AddScoped<IFavoriteNewsRepository, FavoriteNewsRepository>();
            services.AddScoped<IFavoriteNewsServices, FavoriteNewsServices>();


            //Send Email
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddScoped<IMailingRepository, MailingRepository>();
            services.AddScoped<IMailingService, MailingService>();


            //OurWebsite
            services.AddScoped<IOurWebsiteRepository, OurWebsiteRepository>();
            services.AddScoped<IOurWebsiteServices, OurWebsiteServices>();

            //LiveTV
            services.AddScoped<ILiveTVRepository, LiveTVRepository>();
            services.AddScoped<ILiveTVServices, LiveTVServices>();

            //Advertisement
            services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            services.AddScoped<IAdvertisementServices, AdvertisementServices>();

            //News
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<INewsServices, NewsServices>();

            //comment
            services.AddScoped<ICommentServices, CommentServices>();
            services.AddScoped<ICommentRepository, CommentRepository>();


            //likeDislike
            services.AddScoped<ILikeDisLikeRepository, LikeDisLikeRepository>();
            services.AddScoped<ILikeDisLikeServices, LikeDisLikeServices>();

            //newsPhoto
            services.AddScoped<INewsPhotoServices, NewsPhotoServices>();
            services.AddScoped<INewsPhotoRepository, NewsPhotoRepository>();

            //newsVideo
            services.AddScoped<INewsVideoServices, NewsVideoServices>();
            services.AddScoped<INewsVideoRepository, NewsVideoRepository>();

            //Bankvisa
            services.AddScoped<IBankvisaRepository, BankvisaRepository>();
            services.AddScoped<IBankvisaServices, BankvisaServices>();


            //News
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<INewsServices, NewsServices>();

            //comment
            services.AddScoped<ICommentServices, CommentServices>();
            services.AddScoped<ICommentRepository, CommentRepository>();


            //likeDislike
            services.AddScoped<ILikeDisLikeRepository, LikeDisLikeRepository>();
            services.AddScoped<ILikeDisLikeServices, LikeDisLikeServices>();

            //newsPhoto
            services.AddScoped<INewsPhotoServices, NewsPhotoServices>();
            services.AddScoped<INewsPhotoRepository, NewsPhotoRepository>();


            //newsVideo
            services.AddScoped<INewsVideoServices, NewsVideoServices>();
            services.AddScoped<INewsVideoRepository, NewsVideoRepository>();

            //Bankvisa
            services.AddScoped<IBankvisaRepository, BankvisaRepository>();
            services.AddScoped<IBankvisaServices, BankvisaServices>();

            //ContactUsMessage
            services.AddScoped<IContactUsMessageRepository, ContactUsMessageRepository>();
            services.AddScoped<IContactUsMessageService, ContactUsMessageService>();

            //Page
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<IPageService, PageService>();

            //Content
            services.AddScoped<IContentRepository, ContentRepository>();
            services.AddScoped<IContentService, ContentService>();

            //Image
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IImageService, ImageService>();

            //Video
            services.AddScoped<IVideoRepository, VideoRepositroy>();
            services.AddScoped<IVideoService, VideoService>();

            //Follow
            services.AddScoped<IFollowRepository, FollowRepository>();
            services.AddScoped<IFollowService, FollowService>();


            //ReplayComment
            services.AddScoped<IReplayCommentRepository, ReplayCommentRepository>();
            services.AddScoped<IReplayCommentService, ReplayCommentService>();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
