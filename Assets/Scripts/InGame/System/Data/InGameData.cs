namespace Thirty.Data
{
    public class PlayerData
    {

    }

    public class BlockData
    {
        public int Count;
    }

    public class FriendData
    {
        public int Count;

        public void DecrementFriend(int count)
        {
            Count -= count;
        }
    }
}