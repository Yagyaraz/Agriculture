using Agriculture.Areas.Admin.Models;

namespace Agriculture.Areas.Admin.Interface
{
    public interface INabikaran
    {
        Task<NabikaranViewModel> GetNabikaranById(int id);
        Task<bool> CreateNabikaran(NabikaranViewModel model);
        Task<List<NabikaranViewModel>> NabikaranList();
    }
}
