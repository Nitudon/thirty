/// <summary>
/// ゲーム内で使用するデータの構造定義
/// </summary>
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