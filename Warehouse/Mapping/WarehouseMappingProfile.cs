using AutoMapper;
using WpfApp1.Dtoes;
using WpfApp1.Warehouse.Data.Models;

namespace WpfApp1.Warehouse.Data.Mapping;

public class WarehouseMappingProfile : Profile
{
   public WarehouseMappingProfile()
   {
      CreateMap<Pallet, PalletDto>();
      CreateMap<Box, BoxDto>();
      CreateMap<Product, ProductDto>();
   } 
}