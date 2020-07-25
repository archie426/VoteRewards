using System;
using OpenMod.API.Users;

namespace VoteRewards.API.Requests
{
    public readonly struct PlayerGetVoteRequest
    {
        public bool Successful => EndCode != 0;
        
        public bool HasVoted => EndCode == 1 || EndCode == 2;

        public bool HasClaimed => EndCode == 2;
        
        public ClientType Type { get; }
        
        public string Guid { get; }
        
        public string SteamId { get; }
        public int EndCode { get; }

        public PlayerGetVoteRequest(string steamId, int endCode, ClientType type)
        {
            SteamId = steamId;
            EndCode = endCode;
            Type = type;
            Guid = new Guid().ToString();
        }

        public override bool Equals(object? obj)
        {
           return ((PlayerGetVoteRequest) obj).Guid == Guid;
        }
    }
}