using System.Threading.Tasks;
using OpenMod.API.Users;

namespace VoteRewards.Rewarding
{
    public interface IVoteReward
    {
        Task Give(IUser user);
    }
}