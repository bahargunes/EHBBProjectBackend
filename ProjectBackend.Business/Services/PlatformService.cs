using AutoMapper;
using ProjectBackend.Contracts.RepositoryInterfaces;
using ProjectBackend.Contracts.ServiceInterfaces;
using ProjectBackend.Business.DTOs;
using ProjectBackend.Data.Entities;
using FluentValidation;


namespace ProjectBackend.Business.Services
{ 
    public class PlatformService : IPlatformService<PlatformDTO>
    {
        private readonly IPlatformRepository<Platform> _platformRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<PlatformDTO> _validator;
        public PlatformService(IPlatformRepository<Platform> platformRepository, IMapper mapper, IValidator<PlatformDTO> validator)
        {
            _validator = validator;
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlatformDTO>> GetAllAsync()
        {
            var platforms = await _platformRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PlatformDTO>>(platforms);
        }

        public async Task<PlatformDTO> GetByIdAsync(int id) 
        {
            var platform = await _platformRepository.GetByIdAsync(id);
            return _mapper.Map<PlatformDTO>(platform);
        }

        public async Task<PlatformDTO> AddAsync(PlatformDTO platformDto)
        {
            await _validator.ValidateAndThrowAsync(platformDto);
            var platform = _mapper.Map<Platform>(platformDto);
            await _platformRepository.AddAsync(platform);
            return _mapper.Map<PlatformDTO>(platform);
        }

        public async Task<PlatformDTO?> UpdateAsync(int id, PlatformDTO dto)
        {
            var oldEntity = await _platformRepository.GetByIdAsync(id);
            if (oldEntity == null)
                return null;

            await _validator.ValidateAndThrowAsync(dto);
            var platform = _mapper.Map(dto, oldEntity);
            await _platformRepository.UpdateAsync(platform);
            return _mapper.Map<PlatformDTO>(platform);
        }


        public async Task<bool> DeleteAsync(int id)
        {
            return await _platformRepository.DeleteAsync(id);
        }

    }
}
