using Microsoft.EntityFrameworkCore;
using OrderFootballPitch.DTOs;
using OrderFootballPitch.Models;
using OrderFootballPitch.Repository;

namespace OrderFootballPitch.Services
{
    public class FootballPitchService : IFootballPitchService
    {
        private readonly IFootballPitchRepository _repository;

        public FootballPitchService(IFootballPitchRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FootballPitch>> GetAllPitchesAsync()
        {
            return await _repository.GetAllPitchesAsync();
        }

        public async Task<FootballPitch> GetPitchByIdAsync(int id)
        {
            return await _repository.GetPitchByIdAsync(id);
        }

        public async Task<FootballPitch> CreatePitchAsync(FootballPitchDTO pitchDto)
        {
            var pitch = new FootballPitch
            {
                Name = pitchDto.Name,
                TimeStart = pitchDto.TimeStart,
                TimeEnd = pitchDto.TimeEnd,
                Description = pitchDto.Description,
                PricePerHour = pitchDto.PricePerHour,
                IsMaintenance = pitchDto.IsMaintenance,
                PitchTypeId = pitchDto.PitchTypeId,
                CreatedAt = pitchDto.CreatedAt,
                UpdatedAt = pitchDto.UpdatedAt
            };

            return await _repository.CreatePitchAsync(pitch);
        }

        public async Task<FootballPitch> UpdatePitchAsync(int id, FootballPitchDTO pitchDto)
        {
            var existingPitch = await _repository.GetPitchByIdAsync(id);
            if (existingPitch == null)
                return null;

            existingPitch.Name = pitchDto.Name;
            existingPitch.TimeStart = pitchDto.TimeStart;
            existingPitch.TimeEnd = pitchDto.TimeEnd;
            existingPitch.Description = pitchDto.Description;
            existingPitch.PricePerHour = pitchDto.PricePerHour;
            existingPitch.IsMaintenance = pitchDto.IsMaintenance;
            existingPitch.PitchTypeId = pitchDto.PitchTypeId;
            existingPitch.CreatedAt = pitchDto.CreatedAt;
            existingPitch.UpdatedAt = pitchDto.UpdatedAt;

            return await _repository.UpdatePitchAsync(existingPitch);
        }

        public async Task<bool> DeletePitchAsync(int id)
        {
            return await _repository.DeletePitchAsync(id);
        }
        public async Task<IEnumerable<FootballPitch>> SearchPitchesByNameAsync(string name)
        {
            return await _repository.SearchPitchesByNameAsync(name);
        }

    }
}
