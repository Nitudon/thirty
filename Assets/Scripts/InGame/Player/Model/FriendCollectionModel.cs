using UniRx;

public class FriendCollectionModel 
{
    private readonly ReactiveCollection<FriendModel> _friendList;
    public IReadOnlyReactiveCollection<FriendModel> FriendList => _friendList;

    public FriendCollectionModel()
    {
        _friendList = new ReactiveCollection<FriendModel>();
    }

    public void AddFriend()
    {

    }

    public int GetFriendCount()
    {
        return _friendList.Count;
    }
}
