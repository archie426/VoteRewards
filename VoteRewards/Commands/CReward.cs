using System;
using Cysharp.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using OpenMod.API.Users;
using OpenMod.Unturned.Commands;
using OpenMod.Unturned.Users;
using VoteRewards.API;
using VoteRewards.API.Collections;
using VoteRewards.API.Extensions;
using VoteRewards.API.Requests;
using VoteRewards.Rewarding;

namespace VoteRewards.Commands
{
    public class CReward : UnturnedCommand
    {

        private readonly IUnturnedVotingClient _voting;
        private readonly IStringLocalizer _localizer;
        private readonly IRewardService _rewardService;
        
        
        public CReward(IServiceProvider serviceProvider, IUnturnedVotingClient voting, IConfiguration config, IStringLocalizer localizer, IRewardService rewards) : base(serviceProvider)
        {
            _voting = voting;
            _rewardService = rewards;
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
                    await _rewardService.GiveReward(Context.Actor as IUser);
                }
            }
        }
    }
}