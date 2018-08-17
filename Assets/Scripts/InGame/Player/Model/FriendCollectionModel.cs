using System.Linq;
using UniRx;
using Thirty.Data;

public class FriendCollectionModel 
{
    private readonly ReactiveCollection<FriendData> _friendList;
    public IReadOnlyReactiveCollection<FriendData> FriendList => _friendList;

    public FriendCollectionModel()
    {
        _friendList = new ReactiveCollection<FriendData>();
    }

    public void AddFriend(FriendData friend)
    {
        _friendList.Add(friend);
    }

    public void PopFriend()
    {
        _friendList.RemoveAt(_friendList.Count - 1);
    }

    public void DecreaseFriend(int count)
    {
        while(count > 0)
        {
            var popFriend = _friendList.LastOrDefault();
            if(popFriend == null || popFriend.Count < count)
            {
                // ゲーム終了通知
            }

            count -= popFriend.Count;
            PopFriend();
        }
    }
}
