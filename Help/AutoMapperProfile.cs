using AutoMapper;
using System.Security.Cryptography;
using WebApplication1.Data;
using WebApplication1.ViewModels;

namespace WebApplication1.Help
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterVM, Customer>();
                //.ForMember(kh => kh.FirstName, option => option.MapForm(RegisterVM => Register.FirstName))
                //.ReverseMap();
        }
    }
}
