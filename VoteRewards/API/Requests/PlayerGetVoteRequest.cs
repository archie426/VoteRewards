using OpenMod.API.Users;

namespace VoteRewards.API.Requests
{
    public readonly struct PlayerGetVoteRequest
    {
        public bool Successful => EndCode != 0;
        
        public bool HasVoted => EndCode == 1 || EndCode == 2;

        public bool HasClaimed => EndCode == 2;
        
        public string SteamId { get; }
        public int EndCode { get; }

        public PlayerGetVoteRequest(string steamId, int endCode)
        {
            SteamId = steamId;
            EndCode = endCode;
        }

    }
}