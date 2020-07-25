using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using OpenMod.API.Ioc;
using OpenMod.Unturned.Users;
using VoteRewards.API.Authentication;
using VoteRewards.API.Collections;
using VoteRewards.API.Requests;

namespace VoteRewards.API
{
    [ServiceImplementation]
    public class UnturnedVotingClient : IUnturnedVotingClient
    {
        private ClientType _type;
        private readonly ApiKey[] _apiKeys;
        

        private string SlGetUrl(string steamId)
        {
            return $"http://unturnedsl.com/api/dedicated/{steamId}/{_apiKeys[1].Key}";  
        }
        

        private string ServersNetGetUrl(string steamId)
        {
            return $"http://unturned-servers.net/api/?object=votes&element=claim&key={_apiKeys[0].Key}&steamid={steamId}";  
        }
        
        private string ServersNetPostUrl(string steamId)
        {
            return $"http://unturned-servers.net/api/?action=post&object=votes&element=claim&key={_apiKeys[0].Key}&steamid={steamId}";  
        }
        
        private string SlPostUrl(string steamId)
        {
            return $"http://unturnedsl.com/api/dedicated/post/{steamId}/{_apiKeys[1].Key}";  
        }


        public UnturnedVotingClient()
        {
            _apiKeys = new ApiKey[2];
        }
        
        
        public async Task AddUnturnedServersNet(string apiKey)
        {
            if (_type == ClientType.UnturnedSl) 
                _type = ClientType.Both;
            
            _apiKeys[0] = new ApiKey(apiKey, ClientType.UnturnedServers);
        }

        public async Task AddUnturnedSl(string apiKey)
        {
            if (_type == ClientType.UnturnedServers)
                _type = ClientType.Both;
            _apiKeys[1] = new ApiKey(apiKey, ClientType.UnturnedSl);
        }

        public async Task<PlayerVotes> GetPlayerVotes(UnturnedUser user)
        {
            return await GetPlayerVotes(user.SteamId.ToString());
        }

        public async Task<PlayerVotes> GetPlayerVotes(string steamId)
        {
            
            PlayerVotes requests = new PlayerVotes();
            
            if (_type == ClientType.UnturnedServers || _type == ClientType.Both)
            {
                string result = new WebClient().DownloadString(ServersNetGetUrl(steamId));
                bool worked = int.TryParse(result, out int endCode);
                if (!worked)
                    endCode = 0;
                PlayerGetVoteRequest request = new PlayerGetVoteRequest(steamId, endCode, ClientType.UnturnedServers);
                requests.Add(request);
            }
            
            if (_type == ClientType.UnturnedSl || _type == ClientType.Both)
            {
                string result = new WebClient().DownloadString(SlGetUrl(steamId));
                bool worked = int.TryParse(result, out int endCode);
                if (!worked)
                    endCode = 0;
                PlayerGetVoteRequest request = new PlayerGetVoteRequest(steamId, endCode, ClientType.UnturnedSl);
                requests.Add(request);
            }

            return requests;
        }

        public async Task<PlayerSetVoteRequest> SetPlayerVote(ClientType type, string steamId)
        {
            string url = "";
            if (type == ClientType.UnturnedServers)
                url = ServersNetPostUrl(steamId);
            else if (type == ClientType.UnturnedSl)
                url = SlPostUrl(steamId);
            bool worked = int.TryParse(new WebClient().DownloadString(url), out int endCode);
            if (!worked)
                endCode = 0;
            return new PlayerSetVoteRequest(steamId, endCode);
        }

        public async Task<PlayerSetVoteRequest> SetPlayerVote(ClientType type, UnturnedUser user)
        {
            return await SetPlayerVote(type, user.SteamId.ToString());
        }
    }
}