using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FriendsLib.Tests
{
    [TestClass()]
    public class FriendTests
    {
        static Friend[] Data = MakeFriends();

        static Friend[] MakeFriends()
        {
            var f = Enumerable.Range(0, 15).Select(id => new Friend(id)).ToArray();
            f[1].AddFriends(f[2]);
            f[2].AddFriends(f[3], f[6]);
            f[3].AddFriends(f[4], f[7]);
            f[4].AddFriends(f[5], f[8]);
            f[6].AddFriends(f[10]);
            f[7].AddFriends(f[8], f[11]);
            f[8].AddFriends(f[11]);
            f[9].AddFriends(f[11], f[13], f[14]);
            f[11].AddFriends(f[12]);
            return f;
        }        

        [TestMethod()]
        public void GetFriends0Test()
        {
            var f8 = Data[8];
            var friends0 = f8.GetFriends(0);
            CollectionAssert.AreEquivalent(new[] { Data[8] }, friends0);
        }

        [TestMethod()]
        public void GetFriends1Test()
        {
            var f8 = Data[8];
            var friends1 = f8.GetFriends(1);
            CollectionAssert.AreEquivalent(new[] { Data[4], Data[7], Data[11] }, friends1);            
        }

        [TestMethod()]
        public void GetFriends2Test()
        {
            var f8 = Data[8];
            var friends2 = f8.GetFriends(2);
            CollectionAssert.AreEquivalent(new[] { Data[3], Data[5], Data[9], Data[12] }, friends2);            
        }

        [TestMethod()]
        public void GetFriends3Test()
        {
            var f8 = Data[8];            
            var friends3 = f8.GetFriends(3);
            CollectionAssert.AreEquivalent(new[] { Data[2], Data[13], Data[14] }, friends3);            
        }

        [TestMethod()]
        public void GetFriends4Test()
        {
            var f8 = Data[8];            
            var friends4 = f8.GetFriends(4);
            CollectionAssert.AreEquivalent(new[] { Data[1], Data[6] }, friends4);            
        }

        [TestMethod()]
        public void GetFriends5Test()
        {
            var f8 = Data[8];            
            var friends5 = f8.GetFriends(5);
            CollectionAssert.AreEquivalent(new[] { Data[10] }, friends5);
        }

        [TestMethod()]
        public void GetFriends6Test()
        {
            var f8 = Data[8];
            var friends6 = f8.GetFriends(6);
            CollectionAssert.AreEquivalent(new Friend[0], friends6);
        }
    }
}