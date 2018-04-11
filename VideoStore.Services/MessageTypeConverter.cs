using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Services.MessageTypes;

namespace VideoStore.Services
{
    /// <summary>
    /// Based on AutoMapper: https://github.com/AutoMapper/AutoMapper/wiki/Getting-started
    /// See above link if help is needed
    /// </summary>
    public class MessageTypeConverter
    {
        private static MessageTypeConverter sMessageTypeConverter = new MessageTypeConverter();

        public static MessageTypeConverter Instance
        {
            get
            {
                return sMessageTypeConverter;
            }
        }



        public MessageTypeConverter()
        {
            InitializeExternalToInternalMappings();
            InitializeInternalToExternalMappings();
        }

        private void InitializeInternalToExternalMappings()
        {
            AutoMapper.Mapper.CreateMap<VideoStore.Business.Entities.Media,
                VideoStore.Services.MessageTypes.Media>()
                .ForMember(dest => dest.StockCount, opts => opts.MapFrom( src => src.Stocks.Quantity))
                .ForMember(dest => dest.AverageRating, opts => opts.MapFrom(src => src.AverageRating))
                .ForMember(dest => dest.RatingsCount, opts => opts.MapFrom(src => src.RatingsCount)); // Map Average Rating

            AutoMapper.Mapper.CreateMap<VideoStore.Business.Entities.Order,
                VideoStore.Services.MessageTypes.Order>();

            AutoMapper.Mapper.CreateMap<VideoStore.Business.Entities.OrderItem,
                VideoStore.Services.MessageTypes.OrderItem>();

            AutoMapper.Mapper.CreateMap<VideoStore.Business.Entities.User,
                 VideoStore.Services.MessageTypes.User>();

            AutoMapper.Mapper.CreateMap<VideoStore.Business.Entities.LoginCredential,
                VideoStore.Services.MessageTypes.LoginCredential>();

            AutoMapper.Mapper.CreateMap<VideoStore.Business.Entities.Review,    // Map Review
                VideoStore.Services.MessageTypes.Review>();

            AutoMapper.Mapper.CreateMap<VideoStore.Business.Entities.User, // Map ReviewAuthor
                    VideoStore.Services.MessageTypes.ReviewAuthor>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.City))
                .ForMember(dest => dest.Country, opts => opts.MapFrom(src => src.Country));
        }

        public void InitializeExternalToInternalMappings()
        {
            AutoMapper.Mapper.CreateMap<VideoStore.Services.MessageTypes.Media,
                VideoStore.Business.Entities.Media>();

            AutoMapper.Mapper.CreateMap<VideoStore.Services.MessageTypes.Order,
               VideoStore.Business.Entities.Order>();

            AutoMapper.Mapper.CreateMap<VideoStore.Services.MessageTypes.OrderItem,
                VideoStore.Business.Entities.OrderItem>();

            AutoMapper.Mapper.CreateMap<VideoStore.Services.MessageTypes.User,
                 VideoStore.Business.Entities.User>();

            AutoMapper.Mapper.CreateMap<VideoStore.Services.MessageTypes.LoginCredential,
                VideoStore.Business.Entities.LoginCredential>();

            AutoMapper.Mapper.CreateMap<VideoStore.Services.MessageTypes.Review,
                VideoStore.Business.Entities.Review>();
        }

        public Destination Convert<Source, Destination>(Source s)
        {
            var result = AutoMapper.Mapper.Map<Source, Destination>(s);
            return result;
        }
    }
}
