using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VoteRewards.API.Requests;

namespace VoteRewards.API.Collections
{
    public class PlayerVotes : IEnumerable<PlayerGetVoteRequest>
    {
        private readonly List<PlayerGetVoteRequest> _requests = new List<PlayerGetVoteRequest>();
        
        IEnumerator<PlayerGetVoteRequest> IEnumerable<PlayerGetVoteRequest>.GetEnumerator()
        {
            return _requests.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return _requests.GetEnumerator();
        }

        public void Add(PlayerGetVoteRequest request)
        {
            _requests.Add(request);
        }

        public PlayerGetVoteRequest this[ClientType type]
        {
            get
            {
                return _requests.FirstOrDefault(r => r.Type == type);
            }
        }

        public ClientType this[PlayerGetVoteRequest type]
        {
            get
            {
                return _requests.FirstOrDefault(t => t.Equals(type)).Type;
            }
        }


    }
}