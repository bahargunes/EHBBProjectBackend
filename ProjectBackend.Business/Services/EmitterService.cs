using AutoMapper;
using ProjectBackend.Contracts.RepositoryInterfaces;
using ProjectBackend.Business.DTOs; 
using ProjectBackend.Data.Entities; 
using FluentValidation;
using ProjectBackend.Contracts.ServiceInterfaces;

namespace ProjectBackend.Business.Services
{
    public class EmitterService : IEmitterService<EmitterDTO>
    {
        private readonly IEmitterRepository<Emitter> _emitterRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<EmitterDTO> _validator;
        public EmitterService(IEmitterRepository<Emitter> emitterRepository, IMapper mapper, IValidator<EmitterDTO> validator)
        {
            _validator = validator;
            _emitterRepository = emitterRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmitterDTO>> GetAllAsync()
        {
            var emitters = await _emitterRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmitterDTO>>(emitters);
        }

        public async Task<EmitterDTO> GetByIdAsync(int id)
        {
            var emitter = await _emitterRepository.GetByIdAsync(id);
            return _mapper.Map<EmitterDTO>(emitter);
        }

        public async Task<EmitterDTO> AddAsync(EmitterDTO emitterDTO)
        {
            var validationResult = await _validator.ValidateAsync(emitterDTO);
            var failures = validationResult.Errors.ToList();
            if (!await IsNameUniqueAsync(emitterDTO.EmitterName, emitterDTO.EmitterId))
                failures.Add(new FluentValidation.Results.ValidationFailure("EmitterName", "Emitter name must be unique."));
            if (!await IsSpotNoUniqueAsync(emitterDTO.SpotNo, emitterDTO.EmitterId))
                failures.Add(new FluentValidation.Results.ValidationFailure("SpotNo", "Spot No must be unique."));
            if (failures.Any())
                throw new FluentValidation.ValidationException(failures);

            var emitter = _mapper.Map<Emitter>(emitterDTO);
            await _emitterRepository.AddAsync(emitter);
            return _mapper.Map<EmitterDTO>(emitter);
        }

        public async Task<EmitterDTO?> UpdateAsync(int id, EmitterDTO emitterDTO)
        {
            var oldEntity = await _emitterRepository.GetByIdAsync(id);
            if (oldEntity == null)
                return null;

            var validationResult = await _validator.ValidateAsync(emitterDTO);
            var failures = validationResult.Errors.ToList();
            if (!await IsNameUniqueAsync(emitterDTO.EmitterName, emitterDTO.EmitterId))
                failures.Add(new FluentValidation.Results.ValidationFailure("EmitterName", "Emitter name must be unique."));
            if (!await IsSpotNoUniqueAsync(emitterDTO.SpotNo, emitterDTO.EmitterId))
                failures.Add(new FluentValidation.Results.ValidationFailure("SpotNo", "Spot No must be unique."));
            if (failures.Any())
                throw new FluentValidation.ValidationException(failures);


            var emitter = _mapper.Map(emitterDTO, oldEntity);
            await _emitterRepository.UpdateAsync(emitter);
            return _mapper.Map<EmitterDTO>(emitter);
        }


        public async Task<bool> DeleteAsync(int id)
        {
            return await _emitterRepository.DeleteAsync(id);
        }

        public async Task<EmitterDTO> GetByNameAsync(string emitterName)
        {
            var emitter = await _emitterRepository.GetByNameAsync(emitterName);
            return _mapper.Map<EmitterDTO>(emitter);
        }

        public async Task<EmitterDTO> GetBySpotNoAsync(string SpotNo)
        {
            var emitter = await _emitterRepository.GetBySpotNoAsync(SpotNo);
            return _mapper.Map<EmitterDTO>(emitter);
        }


        public async Task<bool> IsNameUniqueAsync(string name, int? excludeId = null)
        {
            // Use the existing Find method
            var existing = await GetByNameAsync(name);
            if (existing == null)
            {
                return true; // If no existing emitter found, the name is unique
            }
            if (excludeId.HasValue && existing.EmitterId == excludeId.Value)
                return true;

            return false;
        }
        public async Task<bool> IsSpotNoUniqueAsync(string SpotNo, int? excludeId = null)
        {
            // Use the existing Find method
            var existing = await GetBySpotNoAsync(SpotNo);
            if (existing == null)
            {
                return true; // If no existing emitter found, the name is unique
            }
            if (excludeId.HasValue && existing.EmitterId == excludeId.Value)
                return true;

            return false;
        }
    }
}
