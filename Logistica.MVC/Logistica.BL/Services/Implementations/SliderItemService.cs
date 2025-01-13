using Logistica.BL.Services.Abstractions;
using Logistica.DAL.Contexts;
using Logistica.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Logistica.BL.Services.Implementations;

public class SliderItemService : ISliderItemService
{
    private readonly AppDbContext _context;

    public SliderItemService(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<SliderItem> table => _context.Set<SliderItem>(); 

    public async Task<SliderItem> GetSliderItemByIdAsync(int id)
    {
        SliderItem? sliderItem = await table.FindAsync(id);
        if(sliderItem is null)
        {
            throw new Exception($"Slider item not found with this id({id})");
        }
        return sliderItem;
    }

    public async Task<List<SliderItem>> GetAllSliderItemsAsync()
    {
        List<SliderItem> sliderItems = await table.ToListAsync();   
        return sliderItems; 
    }

    public async Task CreateSliderItemAsync(SliderItem sliderItem)
    {
        await table.AddAsync(sliderItem);   
        int rows = await _context.SaveChangesAsync();   
        if (rows != 1)
        {
            throw new Exception("Slider item cannot be added");
        }  
    }

    public async Task SoftDeleteSliderItemAsync(int id)
    {
        SliderItem? sliderItem = await table.SingleOrDefaultAsync(s => s.Id == id && !s.IsDeleted );
        if(sliderItem is null)
        {
            throw new Exception($"Slider item not found with this id({id})");
        }
        sliderItem.IsDeleted = true;
        sliderItem.UpdatedAt = DateTime.Now;
        sliderItem.DeletedAt = DateTime.Now;    

        await _context.SaveChangesAsync();      
    }


    public async Task HardDeleteSliderItemAsync(int id)
    {
        SliderItem? sliderItem = await table.FindAsync(id);
        if(sliderItem is null)
        {
            throw new Exception($"Slider item not found with this id({id})");
        }
        table.Remove(sliderItem);       
    }


    public async Task UpdateSliderItemAsync(int id, SliderItem sliderItem)
    {
        if(id != sliderItem.Id)
        {
            throw new Exception("Ids are noy same");
        }
        SliderItem? baseSliderItem = await table.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id && !s.IsDeleted);  
        if(baseSliderItem is null)
        {
            throw new Exception($"Slider Item not found with this id({id})");
        }
        sliderItem.CreatedAt = baseSliderItem.CreatedAt;
        sliderItem.UpdatedAt = DateTime.Now;

        table.Update(sliderItem);   
        await _context.SaveChangesAsync();      
    }
}
