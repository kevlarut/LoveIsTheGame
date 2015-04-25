namespace Assets.Scripts.Player
{
    public class PlayerStateChangedMessage
    {
        public PlayerState PlayerState { get; set; }

        public PlayerStateChangedMessage(PlayerState newPlayerState)
        {
            PlayerState = newPlayerState;
        }
    }
}