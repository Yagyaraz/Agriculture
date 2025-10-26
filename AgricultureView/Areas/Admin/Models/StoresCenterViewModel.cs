using System.ComponentModel.DataAnnotations;

namespace AgricultureView.Areas.Admin.Models
{
   #region FertilizerStore
    public class FertilizerStoreViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        //public IFormFile Photo { get; set; }

        //public string DisplayPhotoPath { get; set; }

        public List<FertilizerStoreProductionViewModel> FertilizerStoreProductionViewModelList { get; set; } = new List<FertilizerStoreProductionViewModel>();
        public List<FertilizerStoreContactPersonViewModel> FertilizerStoreContactPersonViewModelList { get; set; } = new List<FertilizerStoreContactPersonViewModel>();
    }
    public class FertilizerStoreProductionViewModel
    {
        public int Id { get; set; }
        public int FertilizerStoreId { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
    }
    public class FertilizerStoreContactPersonViewModel
    {
        public int Id { get; set; }
        public int FertilizerStoreId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
    } 
    #endregion
   #region SeedStore
    public class SeedStoreViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        //public IFormFile Photo { get; set; }

        //public string DisplayPhotoPath { get; set; }

        public List<SeedStoreProductionViewModel> SeedStoreProductionViewModelList { get; set; } = new List<SeedStoreProductionViewModel>();
        public List<SeedStoreContactPersonViewModel> SeedStoreContactPersonViewModelList { get; set; } = new List<SeedStoreContactPersonViewModel>();
    }
    public class SeedStoreProductionViewModel
    {
        public int Id { get; set; }
        public int SeedStoreId { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
    }
    public class SeedStoreContactPersonViewModel
    {
        public int Id { get; set; }
        public int SeedStoreId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
    }
    #endregion


    public class InsuranceCenterViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
    }
    public class AgricultureEquipmentViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
    }
}
