using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;

namespace FootballTracker.Application.UseCases.Clubs.ActivateClub;
public sealed class ActivateClubHandler
    {
        private readonly IClubRepository _clubRepository;
        public ActivateClubHandler(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }
        public async Task<Result> HandleAsync(ActivateClubCommand command)
        {
            var club = await _clubRepository.GetByIdAsync(command.Id);

            if (club is null)
                throw new KeyNotFoundException("Club not found.");

            if (club.IsActive)
                return Result.Failure("Club is already active.");

            club.Activate();
            await _clubRepository.UpdateAsync(club);
            return Result.Success();
    }
}

