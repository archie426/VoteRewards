using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using OpenMod.Unturned.Commands;
using OpenMod.Unturned.Users;
using VoteRewards.API;
using VoteRewards.API.Requests;

namespace VoteRewards.Commands
{
    public class CReward : UnturnedCommand
    {

        private readonly IUnturnedVotingClient _voting;
        
        public CReward(IServiceProvider serviceProvider, IUnturnedVotingClient voting) : base(serviceProvider)
        {
            _voting = voting;
        }

        protected override async UniTask OnExecuteAsync()
        {
            List<PlayerGetVoteRequest> requests = await _voting.GetPlayerVotes((UnturnedUser) Context.Actor);
            foreach (PlayerGetVoteRequest request in requests)
            {
                if (request.HasVoted && !request.HasClaimed)
                    //Addd rewards
                    continue;
            }
        }
    }
}