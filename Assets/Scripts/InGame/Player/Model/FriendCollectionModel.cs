using System.Linq;
using UniRx;

public class FriendCollectionModel 
{
    private readonly ReactiveCollection<FriendModel> _friendList;
    public IReadOnlyReactiveCollection<FriendModel> FriendList => _friendList;

    public FriendCollectionModel()
    {
        _friendList = new ReactiveCollection<FriendModel>();
    }

    public void AddFriend(FriendModel friend)
    {
        _friendList.Add(friend);
    }

    public int GetFriendCount()
    {
        return _friendList.Count;
    }

    public int GetFrientTotalCount()
    {
        return _friendList.Select(x => x.FriendCount.Value).Sum();
    }
}
