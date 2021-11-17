using AutoMapper;
using Data.Collection.From.Rest.Api.Template.Context;

namespace Data.Collection.From.Rest.Api.Template.Services
{
    public class TemplateService 
    {
        private TemplateDbContext _dbContext;
        private IMapper _mapper;

        public TemplateService(TemplateDbContext dbContext ,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    }    
}