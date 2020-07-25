using System.Collections.Generic;
using System.Threading.Tasks;
using OpenMod.API.Ioc;
using OpenMod.Unturned.Users;
using VoteRewards.API.Collections;
using VoteRewards.API.Requests;

namespace VoteRewards.API
{
    [Service]
    public interface IUnturnedVotingClient
    {
        Task AddUnturnedServersNet(string apiKey);
        Task AddUnturnedSl(string apiKey);

        Task<PlayerVotes> GetPlayerVotes(UnturnedUser user);
        Task<PlayerVotes> GetPlayerVotes(string steamId);

        Task<PlayerSetVoteRequest> SetPlayerVote(ClientType type, string steamId);
        Task<PlayerSetVoteRequest> SetPlayerVote(ClientType type, UnturnedUser user);
        
    }
}