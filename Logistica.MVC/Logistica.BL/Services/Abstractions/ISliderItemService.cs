using Logistica.DAL.Models;

namespace Logistica.BL.Services.Abstractions;

public interface ISliderItemService
{
    Task<List<SliderItem>> GetAllSliderItemsAsync();
    Task<SliderItem> GetSliderItemByIdAsync (int id);   
    Task CreateSliderItemAsync (SliderItem sliderItem); 
    Task SoftDeleteSliderItemAsync(int id);
    Task HardDeleteSliderItemAsync(int id);
    Task UpdateSliderItemAsync (int id, SliderItem sliderItem); 
}
