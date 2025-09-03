using AutoMapper;
using ProjectBackend.Contracts.RepositoryInterfaces;
using ProjectBackend.Contracts.ServiceInterfaces;

using ProjectBackend.Business.DTOs;
using ProjectBackend.Data.Entities;
using FluentValidation;

namespace ProjectBackend.Business.Services
{
    public class LaserService : ILaserService<LaserDTO>
    {
        private readonly ILaserRepository<Laser> _laserRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<LaserDTO> _validator;
        public LaserService(ILaserRepository<Laser> laserRepository, IMapper mapper, IValidator<LaserDTO> validator)
        {
            _validator = validator;
            _laserRepository = laserRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LaserDTO>> GetAllAsync()
        {
            var lasers = await _laserRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<LaserDTO>>(lasers);
        }

        public async Task<LaserDTO> GetByIdAsync(int id)
        {
            var laser = await _laserRepository.GetByIdAsync(id);
            return _mapper.Map<LaserDTO>(laser);
        }

        public async Task<LaserDTO> AddAsync(LaserDTO laserDTO)
        {
            await _validator.ValidateAndThrowAsync(laserDTO);
            var laser = _mapper.Map<Laser>(laserDTO);
            await _laserRepository.AddAsync(laser);
            return _mapper.Map<LaserDTO>(laser);
        }

        public async Task<LaserDTO?> UpdateAsync(int id, LaserDTO dto)
        {
            var oldEntity = await _laserRepository.GetByIdAsync(id);
            if (oldEntity == null)
                return null;

            await _validator.ValidateAndThrowAsync(dto);
            var laser = _mapper.Map(dto, oldEntity);
            await _laserRepository.UpdateAsync(laser);
            return _mapper.Map<LaserDTO>(laser);
        }


        public async Task<bool> DeleteAsync(int id)
        {
            return await _laserRepository.DeleteAsync(id);
        }

    }
}
