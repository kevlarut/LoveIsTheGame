using Assets.Scripts.Player;

namespace Assets.Scripts.Messages
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