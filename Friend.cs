using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsLib
{
    public class Friend
    {
        private readonly List<Friend> friends = new List<Friend>();

        public Friend(int id)
        {
            Id = id;
        }

        public void AddFriends(params Friend[] friends)
        {
            foreach (var f in friends)
            {
                if(!f.Friends.Contains(this))
                    f.AddFriend(this);

                if(!Friends.Contains(f))
                AddFriend(f);
            }
        }

        private void AddFriend(Friend friend)
        {
            friends.Add(friend);
        }

        public Friend[] GetFriends(int level)
        {
            if (level < 0)
                throw new ArgumentOutOfRangeException(nameof(level));

            if (level == 0)
                return new[] { this };

            if (level == 1)
                return Friends.ToArray();

            var result = new Dictionary<int, Friend[]>() {
                { 0, new[] { this } },
                { 1, Friends.ToArray()}
            };

            Func<Friend, bool> IsNotInResultYet = (f => result.Values.All(list => !list.Contains(f)));

            for (int i = 2; i <= level; i++)
            {
                var levelFriends = new List<Friend>();
                foreach (var friend in result[i - 1])
                {
                    var friendFriends = friend.GetFriends(1).Where(IsNotInResultYet);
                    levelFriends.AddRange(friendFriends);
                }
                result[i] = levelFriends.Distinct().ToArray();
            }

            return result[level];
        }

        public int Id { get; set; }

        public override string ToString()
        {
            return $"F{Id}";
        }


        public IEnumerable<Friend> Friends => friends;
    }
}
