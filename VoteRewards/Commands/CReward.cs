using System;
using Cysharp.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using OpenMod.Unturned.Commands;
using OpenMod.Unturned.Users;
using VoteRewards.API;
using VoteRewards.API.Collections;
using VoteRewards.API.Extensions;
using VoteRewards.API.Requests;

namespace VoteRewards.Commands
{
    public class CReward : UnturnedCommand
    {

        private readonly IUnturnedVotingClient _voting;
        private readonly IConfiguration _config;
        private readonly IStringLocalizer _localizer;
        
        public CReward(IServiceProvider serviceProvider, IUnturnedVotingClient voting, IConfiguration config, IStringLocalizer localizer) : base(serviceProvider)
        {
            _voting = voting;
            _config = config;
            _localizer = localizer;
        }

        protected override async UniTask OnExecuteAsync()
        {
            PlayerVotes requests = await _voting.GetPlayerVotes((UnturnedUser) Context.Actor);
            foreach (PlayerGetVoteRequest request in requests)
            {
                ClientType type = requests[request];
                if (request.HasVoted && !request.HasClaimed)
                {
                    await Context.Actor.PrintMessageAsync(_localizer[$"voting:rewards:hasVoted:{type.String()}"]);
                    //Add stuff here
                }
            }
        }
    }
}