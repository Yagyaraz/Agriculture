using Agriculture;
using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Repositories;
using Agriculture.Data;
using Agriculture.Security;
using Agriculture.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors();
// Add services to the container.
builder.Services.AddDbContext<AgricultureDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AgricultureDbContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JsonWebTokenKeys:ValidIssuer"],
        ValidAudience = builder.Configuration["JsonWebTokenKeys:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JsonWebTokenKeys:IssuerSigningKey"]))
    };
});


// Add services to the container.

builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authorization with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement { { new OpenApiSecurityScheme { Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme, } }, new List<string>() } });
});

//Registe dependancy here
builder.Services.AddScoped<ICommon, CommonRepository>();
builder.Services.AddScoped<IFarmer, FarmerRepository>();
builder.Services.AddScoped<IUtility, Agriculture.Utilities.Utility>();
builder.Services.AddScoped<IAgricultureFarmerGroup, AgricultureFarmerGroupRepository>();
builder.Services.AddScoped<IAgriculturePlan, AgriculturePlanRepository>();
builder.Services.AddScoped<ISubsidy, SubsidyRepository>();
builder.Services.AddScoped<ILibrary, LibraryRepository>();
builder.Services.AddScoped<ITraining, TrainingRepository>();
builder.Services.AddScoped<IAgriCalendar, AgriCalendarRepository>();
builder.Services.AddScoped<IStoresCenter, StoresCenterRepository>();
builder.Services.AddScoped<IMarketPrice, MarketPriceRepository>();
builder.Services.AddScoped<IImageGallery, ImageGalleryRepository>();
builder.Services.AddScoped<IVideoGallery, VideoGalleryRepository>();
builder.Services.AddScoped<IFarmerService, FarmerServiceRepository>();
builder.Services.AddScoped<IWeather, WeatherRepository>();
builder.Services.AddScoped<IDashboard, DashboardRepository>();
builder.Services.AddScoped<IGunaso, GunasoRepository>();
builder.Services.AddScoped<ISuchana, SuchanaRepository>();
builder.Services.AddScoped<INabikaran, NabikaranRepository>();
builder.Services.AddScoped<IApplicationForm, ApplicationFormRepository>();
/// Add Auth
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
//logger added
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger());




var app = builder.Build();
#region app Related Configration Use
app.Logger.LogInformation("Initialize the app");
//roles and user
using (var scope = app.Services.CreateScope())
{
    CreateRolesAndAdminUser(scope.ServiceProvider);
    AddRequiredData(scope.ServiceProvider);
}
// Configure the HTTP request pipeline. for Dovelopement Perpose Only
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseCors(options => options
    .WithOrigins(builder.Configuration.GetSection("AllowOrigins").Get<List<string>>().ToArray())
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
#endregion

app.Run();

#region Create Role and initial User Rergistered
void CreateRolesAndAdminUser(IServiceProvider serviceProvider)
{
    var roleNames = new List<string>
            {
                UserRoles.Administrator,
                UserRoles.SuperAdmin,
                UserRoles.Admin,
                UserRoles.User,
            };
    // Creating roles
    foreach (var role in roleNames) { CreateRole(serviceProvider, role); }

    // Administrator user Setup
    const string administratorUserEmail = "softech@gmail.com";
    const string administratorPwd = "Softech@123!";
    AddUserToRole(serviceProvider, new ApplicationUser()
    {
        FullName = UserRoles.Administrator,
        Email = administratorUserEmail,
        UserName = administratorUserEmail,
        EmailConfirmed = true,
        LockoutEnabled = false,
    }, administratorPwd, UserRoles.Administrator);

    // For Super admin 
    const string superAdminUserEmail = "superadmin@gmail.com";
    const string superAdminPwd = "Softech@123";
    AddUserToRole(serviceProvider, new ApplicationUser()
    {
        FullName = UserRoles.SuperAdmin,
        Email = superAdminUserEmail,
        UserName = superAdminUserEmail,
        EmailConfirmed = true,
    }, superAdminPwd, UserRoles.SuperAdmin);

}

/// <summary>
/// Create a role if not exists.
/// </summary>
/// <param name="serviceProvider">Service Provider</param>
/// <param name="roleName">Role Name</param>
void CreateRole(IServiceProvider serviceProvider, string roleName)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roleExists = roleManager.RoleExistsAsync(roleName);
    roleExists.Wait();

    if (roleExists.Result) return;
    var roleResult = roleManager.CreateAsync(new IdentityRole(roleName));
    roleResult.Wait();
}

/// <summary>
/// Add user to a role if the user exists, otherwise, create the user and adds him to the role.
/// </summary>
/// <param name="serviceProvider">Service Provider</param>
/// <param name="user"></param>
/// <param name="userPwd">User Password. Used to create the user if not exists.</param>
/// <param name="roleName">Role Name</param>
void AddUserToRole(IServiceProvider serviceProvider, ApplicationUser user, string userPwd, string roleName)
{
    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    Task<ApplicationUser> checkAppUser = userManager.FindByEmailAsync(user.Email);
    checkAppUser.Wait();

    ApplicationUser appUser = checkAppUser.Result;

    if (checkAppUser.Result == null)
    {
        Task<IdentityResult> taskCreateAppUser = userManager.CreateAsync(user, userPwd);
        taskCreateAppUser.Wait();

        if (taskCreateAppUser.Result.Succeeded)
        {
            appUser = user;
        }
    }

    Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(appUser, roleName);
    newUserRole.Wait();
}
#endregion


#region Add Required Data Before Run Project (Single time Run)
void AddRequiredData(IServiceProvider serviceProvider)
{
    using var context = serviceProvider.GetService<AgricultureDbContext>();

    //#region State
    //var states = JsonSerializer.Deserialize<List<State>>(RequiredInitialData.StateJson);
    //using (var transaction = context.Database.BeginTransaction())
    //{
    //    try
    //    {
    //        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[State] On");
    //        foreach (var item in states)
    //        {
    //            if (context.State.Any(x => x.StateId == item.StateId)) continue;
    //            context.State.Add(item);
    //            context.SaveChanges();
    //        }
    //        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[State] Off");
    //        transaction.Commit();
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.Write(ex);
    //        transaction.Rollback();
    //    }
    //}
    //#endregion

    //#region District
    //var Districts = JsonSerializer.Deserialize<List<District>>(RequiredInitialData.DistrictJson);
    //using (var transaction = context.Database.BeginTransaction())
    //{
    //    try
    //    {
    //        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[District] On");
    //        foreach (var item in Districts)
    //        {
    //            if (context.District.Any(x => x.DistrictId == item.DistrictId)) continue;
    //            context.District.Add(item);
    //            context.SaveChanges();
    //        }
    //        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[District] Off");
    //        transaction.Commit();
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.Write(ex);
    //        transaction.Rollback();
    //    }
    //}
    //#endregion

    //#region Palika
    //var Palikas = JsonSerializer.Deserialize<List<Palika>>(RequiredInitialData.PalikaJson);
    //int rows = 100;
    //int length = (Palikas.Count / rows) + 1;
    //for (int i = 0; i < length; i++)
    //{
    //    var data = Palikas.Skip(i * rows).Take(rows).ToList();
    //    using (var transaction = context.Database.BeginTransaction())
    //    {
    //        try
    //        {
    //            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Palika] On");
    //            foreach (var item in data)
    //            {
    //                if (context.Palika.Any(x => x.PalikaId == item.PalikaId)) continue;
    //                context.Palika.Add(item);
    //                context.SaveChanges();
    //            }
    //            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Palika] Off");
    //            transaction.Commit();
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.Write(ex);
    //            transaction.Rollback();
    //        }
    //    }
    //}
    //#endregion
    #region Gender
    var listOfShredi = new List<Gender>
        {
            new Gender() { Id = 1, Name = "पुरुष", NameEng = "Male" },
            new Gender() { Id = 2, Name = "महिला", NameEng = "Female" },
            new Gender() { Id = 3, Name = "अन्य", NameEng = "Other" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Gender] On");
            foreach (var item in listOfShredi)
            {
                if (context.Gender.Any(x => x.Id == item.Id)) continue;
                context.Gender.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Gender] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"Gender Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region Education
    var listOfEducation = new List<Education>
        {
            new Education() { Id = 1, Name = "साक्षर", NameEng = "Literate" },
            new Education() { Id = 2, Name = "निरक्षर", NameEng = "Illiterate" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Education] On");
            foreach (var item in listOfEducation)
            {
                if (context.Education.Any(x => x.Id == item.Id)) continue;
                context.Education.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Education] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"Education Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region EducationLevel
    var listOfEducationLevel = new List<EducationLevel>
        {
            new EducationLevel() { Id = 1, Name = "समन्य लेखपढ", NameEng = "General" },
            new EducationLevel() { Id = 2, Name = "प्राथमिक तह", NameEng = "Primary" },
            new EducationLevel() { Id = 3, Name = "माध्यमिक तह", NameEng = "Secondary" },
            new EducationLevel() { Id = 4, Name = "स्नातक", NameEng = "Graduated"}
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[EducationLevel] On");
            foreach (var item in listOfEducationLevel)
            {
                if (context.EducationLevel.Any(x => x.Id == item.Id)) continue;
                context.EducationLevel.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[EducationLevel] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"EducationLevel Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region FarmerGroup
    var listOfFarmerGroup = new List<FarmerGroup>
        {
            new FarmerGroup() { Id = 1, Name = "माछा पालन संरक्षण फर्म", NameEng = "Fish Farming Conservation Farm" },
            new FarmerGroup() { Id = 2, Name = "पशुपालन कल्याणकारी समाज", NameEng = "Animal Farming Welfare Society" },
            new FarmerGroup() { Id = 3, Name = "समुदायिक कल्याण समिति", NameEng = "Community Welfare Society" },
            new FarmerGroup() { Id = 4, Name = "मेरो सजिलो किसानी ग्रुप", NameEng = "Mero Sajilo Kishani Group"},
            new FarmerGroup() { Id = 5, Name = "हार्वेस्ट हेभन सोसाइटी", NameEng = "Harvest Haven Society"},
            new FarmerGroup() { Id = 6, Name = "स्वाभिमान किसान समूह", NameEng = "Swabhiman Farmers Group"}
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[FarmerGroup] On");
            foreach (var item in listOfFarmerGroup)
            {
                if (context.FarmerGroup.Any(x => x.Id == item.Id)) continue;
                context.FarmerGroup.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[FarmerGroup] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"FarmerGroup Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region FarmerCategory
    var listOfFarmerCategory = new List<FarmerCategory>
        {
            new FarmerCategory() { Id = 1, Name = "साना किसान", NameEng = "Small Farmer" },
            new FarmerCategory() { Id = 2, Name = "मध्यम किसान", NameEng = "Medium Farmer" },
            new FarmerCategory() { Id = 3, Name = "ठुलो किसान", NameEng = "Large Farmer" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[FarmerCategory] On");
            foreach (var item in listOfFarmerCategory)
            {
                if (context.FarmerCategory.Any(x => x.Id == item.Id)) continue;
                context.FarmerCategory.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[FarmerCategory] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"FarmerCategory Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region AvgMonth
    var listOfAvgMonth = new List<AvgMonth>
        {
            new AvgMonth() { Id = 1, Name = "३ महिनाभन्दा कम", NameEng = "Less than 3 months" },
            new AvgMonth() { Id = 2, Name = "३ देखि ६ महिना", NameEng = "3 to 6 months" },
            new AvgMonth() { Id = 3, Name = "६ देखि ९ महिना", NameEng = "6 to 9 months" },
            new AvgMonth() { Id = 4, Name = "९ देखि १२ महिना", NameEng = "9 to 12 months" },
            new AvgMonth() { Id = 5, Name = "वर्षैभरि", NameEng = "Whole Year" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[AvgMonth] On");
            foreach (var item in listOfAvgMonth)
            {
                if (context.AvgMonth.Any(x => x.Id == item.Id)) continue;
                context.AvgMonth.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[AvgMonth] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"AvgMonth Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region AgriSector
    var listOfAgriSector = new List<AgriSector>
        {
            new AgriSector() { Id = 1, Name = "मिश्रित", NameEng = "Mixed" },
            new AgriSector() { Id = 2, Name = "पशुपालन", NameEng = "Livestock" },
            new AgriSector() { Id = 3, Name = "बालि", NameEng = "Crops" },
            new AgriSector() { Id = 4, Name = "कौसि खेति / फुलबारि", NameEng = "Terrace Farming / Gardening" },
            new AgriSector() { Id = 5, Name = "माटो ज्ञान", NameEng = "Soil Knowledge" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[AgriSector] On");
            foreach (var item in listOfAgriSector)
            {
                if (context.AgriSector.Any(x => x.Id == item.Id)) continue;
                context.AgriSector.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[AgriSector] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"AgriSector Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region AgriService
    var listOfAgriService = new List<AgriService>
        {
            new AgriService() { Id = 1, AgriSectorId = 2, Name = "पशु चिकित्सा सेवा", NameEng = "" },
            new AgriService() { Id = 2, AgriSectorId = 2, Name = "खोप", NameEng = "" },
            new AgriService() { Id = 3, AgriSectorId = 2, Name = "टर्की खेती", NameEng = "" },
            new AgriService() { Id = 4, AgriSectorId = 2, Name = "कुखुरा पालन", NameEng = "" },
            new AgriService() { Id = 5, AgriSectorId = 3, Name = "जजम", NameEng = "" },
            new AgriService() { Id = 6, AgriSectorId = 3, Name = "फलफूल खेती", NameEng = "" },
            new AgriService() { Id = 7, AgriSectorId = 4, Name = "सजिलो बागवानी पुस्तक", NameEng = "" },
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[AgriService] On");
            foreach (var item in listOfAgriService)
            {
                if (context.AgriService.Any(x => x.Id == item.Id)) continue;
                context.AgriService.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[AgriService] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"AgriService Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region Relation
    var listOfRelation = new List<Relation>
        {
            new Relation() { Id = 1, Name = "बाउ", NameEng = "Father" },
            new Relation() { Id = 2, Name = "आमा", NameEng = "Mother" },
            new Relation() { Id = 3, Name = "छोरा", NameEng = "Son" },
            new Relation() { Id = 4, Name = "छोरी", NameEng = "Daughter" },
            new Relation() { Id = 5, Name = "नातिनी", NameEng = "GrandDaughter" },
            new Relation() { Id = 6, Name = "नाती", NameEng = "Grandson" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Relation] On");
            foreach (var item in listOfRelation)
            {
                if (context.Relation.Any(x => x.Id == item.Id)) continue;
                context.Relation.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Relation] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"Relation Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region WorkingArea
    var listOfWorkingArea = new List<WorkingArea>
        {
            new WorkingArea() { Id = 1, Name = "उत्पादन क्षेत्र", NameEng = "Production" },
            new WorkingArea() { Id = 2, Name = "प्रशोधन क्षेत्र", NameEng = "Processing" },
            new WorkingArea() { Id = 3, Name = "बजारिकरण", NameEng = "Marketing" },
            new WorkingArea() { Id = 4, Name = "कृषि उधम", NameEng = "Industry" },
            new WorkingArea() { Id = 5, Name = "श्रमिक", NameEng = "Laborer" },
            new WorkingArea() { Id = 6, Name = "अन्य", NameEng = "Others" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[WorkingArea] On");
            foreach (var item in listOfWorkingArea)
            {
                if (context.WorkingArea.Any(x => x.Id == item.Id)) continue;
                context.WorkingArea.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[WorkingArea] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"WorkingArea Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region KrishiFarmType
    var listOfKrishiFarmType = new List<KrishiFarmType>
        {
            new KrishiFarmType() { Id = 1, Name = "कृषि"},
            new KrishiFarmType() { Id = 2, Name = "पशुपालन"},
            new KrishiFarmType() { Id = 3, Name = "मिश्रित"}
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[KrishiFarmType] On");
            foreach (var item in listOfKrishiFarmType)
            {
                if (context.KrishiFarmType.Any(x => x.Id == item.Id)) continue;
                context.KrishiFarmType.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[KrishiFarmType] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"KrishiFarmType Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region ProcustionMeasurement
    var listOfProcustionMeasurement = new List<ProcustionMeasurement>
        {
            new ProcustionMeasurement() { Id = 1, Name = "के.जि"},
            new ProcustionMeasurement() { Id = 2, Name = "क्विन्टल"},
            new ProcustionMeasurement() { Id = 3, Name = "संख्या"}
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProcustionMeasurement] On");
            foreach (var item in listOfProcustionMeasurement)
            {
                if (context.ProcustionMeasurement.Any(x => x.Id == item.Id)) continue;
                context.ProcustionMeasurement.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProcustionMeasurement] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"ProcustionMeasurement Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region ProcustionUse
    var listOfProcustionUse = new List<ProcustionUse>
        {
            new ProcustionUse() { Id = 1, Name = "मासु"},
            new ProcustionUse() { Id = 2, Name = "जिउंदो"},
            new ProcustionUse() { Id = 3, Name = "बिक्री"},
            new ProcustionUse() { Id = 4, Name = "भुरा"},
            new ProcustionUse() { Id = 5, Name = "उत्पादन"}
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProcustionUse] On");
            foreach (var item in listOfProcustionUse)
            {
                if (context.ProcustionUse.Any(x => x.Id == item.Id)) continue;
                context.ProcustionUse.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProcustionUse] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"ProcustionUse Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region OwnershipType
    var listOfOwnershipType = new List<OwnershipType>
        {
            new OwnershipType() { Id = 1, Name = "आफ्नो", NameEng = "Own" },
            new OwnershipType() { Id = 2, Name = "परिवारको नाममा", NameEng = "Family" },
            new OwnershipType() { Id = 3, Name = "ऐलानी/पर्ती", NameEng = "Ailani Parthi" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[OwnershipType] On");
            foreach (var item in listOfOwnershipType)
            {
                if (context.OwnershipType.Any(x => x.Id == item.Id)) continue;
                context.OwnershipType.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[OwnershipType] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"OwnershipType Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region LandType
    var listOfLandType = new List<LandType>
        {
            new LandType() { Id = 1, Name = "खेत", NameEng = "Farm" },
            new LandType() { Id = 2, Name = "पाखो बारी", NameEng = "Pakho Bari" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[LandType] On");
            foreach (var item in listOfLandType)
            {
                if (context.LandType.Any(x => x.Id == item.Id)) continue;
                context.LandType.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[LandType] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"LandType Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region IrrigationSource
    var listOfIrrigationSource = new List<IrrigationSource>
        {
            new IrrigationSource() { Id = 1, Name = "पोखरी/रिजरभायर", NameEng = "Pond/Reservoir" },
            new IrrigationSource() { Id = 2, Name = "सिंचाई कुलो", NameEng = "Irrigation Canal" },
            new IrrigationSource() { Id = 3, Name = "भुमिगत सिंचाई (प्यालो टुयबेल तथा डिपर टुयबेल)", NameEng = "Subsurface Irrigation (Pallow Tubewell and Deep Tubewell)" },
            new IrrigationSource() { Id = 4, Name = "आकासे पानी संकलन", NameEng = "Harvesting Water from the Sky" },
            new IrrigationSource() { Id = 5, Name = "अन्य", NameEng = "Others" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[IrrigationSource] On");
            foreach (var item in listOfIrrigationSource)
            {
                if (context.IrrigationSource.Any(x => x.Id == item.Id)) continue;
                context.IrrigationSource.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[IrrigationSource] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"IrrigationSource Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region CropsType
    var listOfCropsType = new List<CropsType>
        {
            new CropsType() { Id = 1, Name = "खाधन्न बाली", NameEng = "" },
            new CropsType() { Id = 2, Name = "तरकारि बाली", NameEng = "" },
            new CropsType() { Id = 3, Name = "दलहनबाली", NameEng = "" },
            new CropsType() { Id = 4, Name = "औधोगीक बाली", NameEng = "" },
            new CropsType() { Id = 5, Name = "मसलाबाली", NameEng = "" },
            new CropsType() { Id = 6, Name = "पुष्पखेती", NameEng = "" },
            new CropsType() { Id = 7, Name = "अन्य", NameEng = "" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[CropsType] On");
            foreach (var item in listOfCropsType)
            {
                if (context.CropsType.Any(x => x.Id == item.Id)) continue;
                context.CropsType.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[CropsType] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"CropsType Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region FruitsType
    var listOfFruitsType = new List<FruitsType>
        {
            new FruitsType() { Id = 1, Name = "आँप", NameEng = "" },
            new FruitsType() { Id = 2, Name = "केरा", NameEng = "" },
            new FruitsType() { Id = 3, Name = "अंगुर", NameEng = "" },
            new FruitsType() { Id = 4, Name = "अनार", NameEng = "" },
            new FruitsType() { Id = 5, Name = "आँवला", NameEng = "" },
            new FruitsType() { Id = 6, Name = "सुन्तला", NameEng = "" },
            new FruitsType() { Id = 7, Name = "बेल", NameEng = "" },
            new FruitsType() { Id = 8, Name = "अनार", NameEng = "" },
            new FruitsType() { Id = 9, Name = "अम्बा", NameEng = "" },
            new FruitsType() { Id = 10, Name = "लीची", NameEng = "" },
            new FruitsType() { Id = 11, Name = "जामुन", NameEng = "" },
            new FruitsType() { Id = 12, Name = "अन्य", NameEng = "" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[FruitsType] On");
            foreach (var item in listOfFruitsType)
            {
                if (context.FruitsType.Any(x => x.Id == item.Id)) continue;
                context.FruitsType.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[FruitsType] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"FruitsType Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region SeedsType
    var listOfSeedsType = new List<SeedsType>
        {
            new SeedsType() { Id = 1, Name = "धान", NameEng = "" },
            new SeedsType() { Id = 2, Name = "जौ", NameEng = "" },
            new SeedsType() { Id = 3, Name = "मकै", NameEng = "" },
            new SeedsType() { Id = 4, Name = "गहु", NameEng = "" },
            new SeedsType() { Id = 5, Name = "कोदो", NameEng = "" },
            new SeedsType() { Id = 6, Name = "अन्य", NameEng = "" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[SeedsType] On");
            foreach (var item in listOfSeedsType)
            {
                if (context.SeedsType.Any(x => x.Id == item.Id)) continue;
                context.SeedsType.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[SeedsType] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"SeedsType Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region MushroomType
    var listOfMushroomType = new List<MushroomType>
        {
            new MushroomType() { Id = 1, Name = "उन्नत", NameEng = "" },
            new MushroomType() { Id = 2, Name = "काठे", NameEng = "" },
            new MushroomType() { Id = 3, Name = "अन्य", NameEng = "" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[MushroomType] On");
            foreach (var item in listOfMushroomType)
            {
                if (context.MushroomType.Any(x => x.Id == item.Id)) continue;
                context.MushroomType.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[MushroomType] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"MushroomType Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region BeeType
    var listOfBeeType = new List<BeeType>
        {
            new BeeType() { Id = 1, Name = "उन्नत", NameEng = "" },
            new BeeType() { Id = 2, Name = "काठे", NameEng = "" },
            new BeeType() { Id = 3, Name = "अन्य", NameEng = "" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[BeeType] On");
            foreach (var item in listOfBeeType)
            {
                if (context.BeeType.Any(x => x.Id == item.Id)) continue;
                context.BeeType.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[BeeType] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"BeeType Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region SilkType
    var listOfSilkType = new List<SilkType>
        {
            new SilkType() { Id = 1, Name = "मलबेरी रेशम", NameEng = "" },
            new SilkType() { Id = 2, Name = "एरी रेशम", NameEng = "" },
            new SilkType() { Id = 3, Name = "टसर रेशम", NameEng = "" },
            new SilkType() { Id = 4, Name = "मुगा रेशम", NameEng = "" },
            new SilkType() { Id = 5, Name = "अन्य", NameEng = "" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[SilkType] On");
            foreach (var item in listOfSilkType)
            {
                if (context.SilkType.Any(x => x.Id == item.Id)) continue;
                context.SilkType.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[SilkType] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"SilkType Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region AnimalSetup
    var listOfAnimalSetup = new List<AnimalSetup>
        {
            new AnimalSetup() { Id = 1, Name = "गाईपालनन", NameEng = "Cow Farming" },
            new AnimalSetup() { Id = 2, Name = "भैसीपालन", NameEng = "Buffalo Farming" },
            new AnimalSetup() { Id = 3, Name = "चौरी/याक पालन", NameEng = "Yak Farming" },
            new AnimalSetup() { Id = 4, Name = "गोरु / रांगा पालन", NameEng = "Ox / Bull Farming" },
            new AnimalSetup() { Id = 5, Name = "भेडा / बाख्रा / च्या्ङ्ग्रा पालन", NameEng = "Sheep / Goat / Himalayan Goat Farming" },
            new AnimalSetup() { Id = 6, Name = "बङ्गुर/सुङ्गुर/बंदेल पालन", NameEng = "Boar/Pig/Wild Boar Farming" },
            new AnimalSetup() { Id = 7, Name = "कुखुरापालन", NameEng = "Poultry Farming" },
            new AnimalSetup() { Id = 8, Name = "अन्य पन्छीहरु", NameEng = "Other Birds" },
            new AnimalSetup() { Id = 9, Name = "मत्स्यपालन", NameEng = "Fish Farming" },
            new AnimalSetup() { Id = 10, Name = "अन्य पशुपालन", NameEng = "Other Animal Farming" },
            new AnimalSetup() { Id = 11, Name = "हुउंदे बर्षे बहुवर्षे घांसेबालीको विवरण", NameEng = "Description of perennial grass crops" },
            new AnimalSetup() { Id = 12, Name = "कृषि व्यावसाय / फर्म / उधम विवरण", NameEng = "Agriculture / Firm / Business Details" },
            new AnimalSetup() { Id = 13, Name = "कृषि / पशूपन्छी / मत्स्यपालन संग सम्बन्धित मेशिनरी प्रयोग विवरण", NameEng = "Machinery Detail" },
            new AnimalSetup() { Id = 14, Name = "कृषि / पशुपालन / मत्स्यपालनसंग सम्बन्धित संरचनाको विवरण", NameEng = "infrastructure Detail" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[AnimalSetup] On");
            foreach (var item in listOfAnimalSetup)
            {
                if (context.AnimalSetup.Any(x => x.Id == item.Id)) continue;
                context.AnimalSetup.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[AnimalSetup] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"AnimalSetup Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region AgriGroupType
    var listOfAgriGroupType = new List<AgriGroupType>
        {
            new AgriGroupType() { Id = 1, Name = "समूह", NameEng = "Group" },
            new AgriGroupType() { Id = 2, Name = "सहकारी", NameEng = "Cooperative" },
            new AgriGroupType() { Id = 3, Name = "फर्म", NameEng = "Firm" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[AgriGroupType] On");
            foreach (var item in listOfAgriGroupType)
            {
                if (context.AgriGroupType.Any(x => x.Id == item.Id)) continue;
                context.AgriGroupType.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[AgriGroupType] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"AgriGroupType Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region Post
    var listOfPost = new List<Post>
        {
            new Post() { Id = 1, Name = "अध्यक्ष", NameEng = "CHAIRMAN" },
            new Post() { Id = 2, Name = "उपाध्यक्ष", NameEng = "VICE-CHAIRMAN" },
            new Post() { Id = 3, Name = "सचिव", NameEng = "SECRETARY" },
            new Post() { Id = 4, Name = "कोषाध्यक्ष", NameEng = "TREASURER" },
            new Post() { Id = 5, Name = "सदस्य", NameEng = "MEMBER" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Post] On");
            foreach (var item in listOfPost)
            {
                if (context.Post.Any(x => x.Id == item.Id)) continue;
                context.Post.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Post] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"Post Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region MeasuringUnit
    var listOfMeasuringUnit = new List<MeasuringUnit>
        {
            new MeasuringUnit() { Id = 1, Name = "के.जी.", NameEng = "KG" },
            new MeasuringUnit() { Id = 2, Name = "लिटर", NameEng = "Liter" },
            new MeasuringUnit() { Id = 3, Name = "पिस", NameEng = "Piece" },
            new MeasuringUnit() { Id = 4, Name = "संख्या", NameEng = "Number" },
            new MeasuringUnit() { Id = 5, Name = "झोला", NameEng = "Bag" },
            new MeasuringUnit() { Id = 6, Name = "बक्स", NameEng = "Box" },
            new MeasuringUnit() { Id = 7, Name = "बोतल", NameEng = "Bottle" },
            new MeasuringUnit() { Id = 8, Name = "प्याकेट", NameEng = "Packet" },
            new MeasuringUnit() { Id = 9, Name = "बन्डल", NameEng = "Bundle" },
            new MeasuringUnit() { Id = 10, Name = "बोरा", NameEng = "Sack" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[MeasuringUnit] On");
            foreach (var item in listOfMeasuringUnit)
            {
                if (context.MeasuringUnit.Any(x => x.Id == item.Id)) continue;
                context.MeasuringUnit.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[MeasuringUnit] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"MeasuringUnit Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region EcologicalArea
    var listOfEcologicalArea = new List<EcologicalArea>
        {
            new EcologicalArea() { Id = 1, Name = "तराई", NameEng = "Terai" },
            new EcologicalArea() { Id = 2, Name = "पहाड", NameEng = "Hilly" },
            new EcologicalArea() { Id = 3, Name = "हिमाल", NameEng = "Mountain" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[EcologicalArea] On");
            foreach (var item in listOfEcologicalArea)
            {
                if (context.EcologicalArea.Any(x => x.Id == item.Id)) continue;
                context.EcologicalArea.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[EcologicalArea] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"EcologicalArea Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion

    #region Month
    var listOfMonth = new List<Month>
        {
            new Month() { Id = 1, Name = "बैशाख", NameEng = "Baishakh" },
            new Month() { Id = 2, Name = "जेठ", NameEng = "Jestha" },
            new Month() { Id = 3, Name = "असार", NameEng = "Ashad" },
            new Month() { Id = 4, Name = "साउन", NameEng = "Shrawan" },
            new Month() { Id = 5, Name = "भदौ", NameEng = "Bhadra" },
            new Month() { Id = 6, Name = "असोज", NameEng = "Ashwin" },
            new Month() { Id = 7, Name = "कार्तिक", NameEng = "Kartik" },
            new Month() { Id = 8, Name = "मंसिर", NameEng = "Mangsir" },
            new Month() { Id = 9, Name = "पुष", NameEng = "Poush" },
            new Month() { Id = 10, Name = "माघ", NameEng = "Magh" },
            new Month() { Id = 11, Name = "फाल्गुन", NameEng = "Falgun" },
            new Month() { Id = 12, Name = "चैत्र", NameEng = "Chaitra" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Month] On");
            foreach (var item in listOfMonth)
            {
                if (context.Month.Any(x => x.Id == item.Id)) continue;
                context.Month.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Month] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"Month Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
    #region Week
    var listOfWeek = new List<Week>
        {
            new Week() { Id = 1, Name = "पहिलो हप्ता", NameEng = "FIRST_WEEK" },
            new Week() { Id = 2, Name = "दोस्रो हप्ता", NameEng = "SECOND_WEEK" },
            new Week() { Id = 3, Name = "तेस्रो हप्ता", NameEng = "THIRD_WEEK" },
            new Week() { Id = 4, Name = "चौथो हप्ता", NameEng = "FOURTH_WEEK" }
        };

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Week] On");
            foreach (var item in listOfWeek)
            {
                if (context.Week.Any(x => x.Id == item.Id)) continue;
                context.Week.Add(item);
                context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Week] Off");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            app.Logger.LogInformation($"Week Not Created, Error : {ex}");
            transaction.Rollback();
        }
    }
    #endregion
}
#endregion