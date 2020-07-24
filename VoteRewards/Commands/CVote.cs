using System;
using Cysharp.Threading.Tasks;
using OpenMod.Unturned.Commands;
using VoteRewards.API;

namespace VoteRewards.Commands
{
    public class CVote : UnturnedCommand
    {
        public CVote(IServiceProvider serviceProvider, IUnturnedVotingClient voting) : base(serviceProvider)
        {
            
        }

        protected override async UniTask OnExecuteAsync()
        {
            
        }
    }
}