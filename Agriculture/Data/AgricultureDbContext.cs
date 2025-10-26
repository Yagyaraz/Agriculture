using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Agriculture.Data
{
    public class AgricultureDbContext : IdentityDbContext<ApplicationUser>
    {
        public AgricultureDbContext(DbContextOptions<AgricultureDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        //dbset table here
        public DbSet<Office> Office { get; set; }
        public DbSet<FiscalYear> FiscalYear { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Palika> Palika { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<EducationLevel> EducationLevel { get; set; }
        public DbSet<FarmerGroup> FarmerGroup { get; set; }
        public DbSet<FarmerCategory> FarmerCategory { get; set; }
        public DbSet<Farmer> Farmer { get; set; }
        public DbSet<FarmerFile> FarmerFile { get; set; }
        public DbSet<KrishiDetails> KrishiDetails { get; set; }
        public DbSet<AgricultureDetail> AgricultureDetail { get; set; }
        public DbSet<AvgMonth> AvgMonth { get; set; }
        public DbSet<AgriSector> AgriSector { get; set; }
        public DbSet<AgriService> AgriService { get; set; }
        public DbSet<Relation> Relation { get; set; }
        public DbSet<WorkingArea> WorkingArea { get; set; }
        public DbSet<FamilyDetails> FamilyDetails { get; set; }
        public DbSet<FamilyDetailsInvolvedInAgri> FamilyDetailsInvolvedInAgri { get; set; }
        public DbSet<FieldDetails> FieldDetails { get; set; }
        public DbSet<LandOwnership> LandOwnership { get; set; }
        public DbSet<AgriFarmMoreThanOneLocalLevel> AgriFarmMoreThanOneLocalLevel { get; set; }
        public DbSet<LeasedLandDetail> LeasedLandDetail { get; set; }
        public DbSet<OwnershipType> OwnershipType { get; set; }
        public DbSet<LandType> LandType { get; set; }
        public DbSet<IrrigationSource> IrrigationSource { get; set; }

        public DbSet<CropsInformation> CropsInformation { get; set; }
        public DbSet<EatableCrops> EatableCrops { get; set; }
        public DbSet<FruitCrops> FruitCrops { get; set; }
        public DbSet<SeedCrops> SeedCrops { get; set; }
        public DbSet<MushroomCrpos> MushroomCrpos { get; set; }
        public DbSet<SilkCrops> SilkCrops { get; set; }
        public DbSet<BeeCrops> BeeCrops { get; set; }
        public DbSet<CropsType> CropsType { get; set; }
        public DbSet<FruitsType> FruitsType { get; set; }
        public DbSet<SeedsType> SeedsType { get; set; }
        public DbSet<MushroomType> MushroomType { get; set; }
        public DbSet<SilkType> SilkType { get; set; }
        public DbSet<BeeType> BeeType { get; set; }

        public DbSet<AnimalSetup> AnimalSetup { get; set; }
        
        public DbSet<AnimalHusbandry> AnimalHusbandry { get; set; }
        public DbSet<CowInfromation> CowInfromation { get; set; }
        public DbSet<BuffaloInfromation> BuffaloInfromation { get; set; }
        public DbSet<CharuiYakInfromation> CharuiYakInfromation { get; set; }
        public DbSet<GoruInfromation> GoruInfromation { get; set; }
        public DbSet<BhedaBakhraInfromation> BhedaBakhraInfromation { get; set; }
        public DbSet<BungurSungurInfromation> BungurSungurInfromation { get; set; }
        public DbSet<HenInfromation> HenInfromation { get; set; }
        public DbSet<OtherBirdInfromation> OtherBirdInfromation { get; set; }
        public DbSet<FishInfromation> FishInfromation { get; set; }
        public DbSet<OtherAnimalInfromation> OtherAnimalInfromation { get; set; }
        public DbSet<GhaseBaliInfromation> GhaseBaliInfromation { get; set; }
        public DbSet<KrishiFarmInfromation> KrishiFarmInfromation { get; set; }
        public DbSet<KrishiMechinaryInfromation> KrishiMechinaryInfromation { get; set; }
        public DbSet<KrishiSanrachanaInfromation> KrishiSanrachanaInfromation { get; set; }
        public DbSet<KrishiFarmType> KrishiFarmType { get; set; }
        public DbSet<ProcustionUse> ProcustionUse { get; set; }
        public DbSet<ProcustionMeasurement> ProcustionMeasurement { get; set; }


        public DbSet<AgricultureFarmerGroup> AgricultureFarmerGroup { get; set; }
        public DbSet<OfficialsDetail> OfficialsDetail { get; set; }
        public DbSet<AgriGroupType> AgriGroupType { get; set; }
        public DbSet<Post> Post { get; set; }
        
        
        
        public DbSet<AgricultureProgram> AgricultureProgram { get; set; }
        public DbSet<AgricultureProject> AgricultureProject { get; set; }
        public DbSet<AgricultureService> AgricultureService { get; set; }
        public DbSet<AgricultureServiceAdditional> AgricultureServiceAdditional { get; set; }
        public DbSet<AgricultureApplicatoionForm> AgricultureApplicatoionForm { get; set; }
        
        
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<MeasuringUnit> MeasuringUnit { get; set; }
        public DbSet<Subsidy> Subsidy { get; set; }
        public DbSet<SubsidyDetail> SubsidyDetail { get; set; }
        public DbSet<SaveRequestedSubsidy> SaveRequestedSubsidy { get; set; }
        public DbSet<OtherSubsidy> OtherSubsidy { get; set; }
        public DbSet<OtherSubsidyQns> OtherSubsidyQns { get; set; }

        public DbSet<Library> Library { get; set; }
        public DbSet<Training> Training { get; set; }




        public DbSet<AgriCalendar> AgriCalendar { get; set; }
        public DbSet<AgriCalendarDetail> AgriCalendarDetail { get; set; }
        public DbSet<AgriCalendarType> AgriCalendarType { get; set; }
        public DbSet<AgriCalendarCategory> AgriCalendarCategory { get; set; }
        public DbSet<AgriCalendarProduct> AgriCalendarProduct { get; set; }
        public DbSet<EcologicalArea> EcologicalArea { get; set; }
        public DbSet<Month> Month { get; set; }
        public DbSet<Week> Week { get; set; }


        public DbSet<FertilizerStore> FertilizerStore { get; set; }
        public DbSet<FertilizerStoreProduction> FertilizerStoreProduction { get; set; }
        public DbSet<FertilizerStoreContactPerson> FertilizerStoreContactPerson { get; set; }
        
        public DbSet<SeedStore> SeedStore { get; set; }
        public DbSet<SeedStoreProduction> SeedStoreProduction { get; set; }
        public DbSet<SeedStoreContactPerson> SeedStoreContactPerson { get; set; }


        public DbSet<InsuranceCenter> InsuranceCenter { get; set; }
        public DbSet<AgricultureEquipment> AgricultureEquipment { get; set; }





        public DbSet<Market> Market { get; set; }
        public DbSet<MarketPrice> MarketPrice { get; set; }
        public DbSet<MarketPriceDetails> MarketPriceDetails { get; set; }



        public DbSet<Album> Album { get; set; }
        public DbSet<ImageGallery> ImageGallery { get; set; }


        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<VideoGallery> VideoGallery { get; set; }



        public DbSet<FarmerServiceCard> FarmerServiceCard { get; set; }
        public DbSet<FarmerServiceCardDetail> FarmerServiceCardDetail { get; set; }


        public DbSet<Ward> Ward { get; set; }


    }
}
