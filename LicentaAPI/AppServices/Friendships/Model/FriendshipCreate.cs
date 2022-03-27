namespace LicentaAPI.AppServices.Friendships.Model
{
    /// <summary>
    /// Information needed to create a <see cref="Friendship"/>.
    /// </summary>
    public class FriendshipCreate
    {
        public string IdSender { get; set; }

        public string IdReceiver { get; set; }
    }
}