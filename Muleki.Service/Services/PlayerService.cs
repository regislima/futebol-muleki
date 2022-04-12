using Muleki.Service.DTO;
using Muleki.Service.Interfaces;

namespace Muleki.Service.Services
{
    public class PlayerService : IPlayerService
    {
        public Task<PlayerDto> Create(PlayerDto objDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlayerDto>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<PlayerDto> FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<PlayerDto> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlayerDto>> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlayerDto>> FindByNick(string nick)
        {
            throw new NotImplementedException();
        }

        public Task<List<FootballDto>> FindFootballs(long playerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ScoreDto>> FindScores(long playerId)
        {
            throw new NotImplementedException();
        }

        public Task Remove(long id)
        {
            throw new NotImplementedException();
        }

        public Task<PlayerDto> Update(PlayerDto objDTO)
        {
            throw new NotImplementedException();
        }
    }
}