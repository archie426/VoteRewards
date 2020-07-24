using System.Collections.Generic;
using System.Threading.Tasks;
using OpenMod.API.Ioc;
using OpenMod.Unturned.Users;
using VoteRewards.API.Requests;

namespace VoteRewards.API
{
    [Service]
    public interface IUnturnedVotingClient
    {
        Task AddUnturnedServersNet(string apiKey);
        Task AddUnturnedSl(string apiKey);

        Task<List<PlayerGetVoteRequest>> GetPlayerVotes(UnturnedUser user);
        Task<List<PlayerGetVoteRequest>> GetPlayerVotes(string steamId);

        Task<PlayerSetVoteRequest> SetPlayerVote(ClientType type, string steamId);
        Task<PlayerSetVoteRequest> SetPlayerVote(ClientType type, UnturnedUser user);
    }
}