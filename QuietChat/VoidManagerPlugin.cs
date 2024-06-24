using VoidManager.MPModChecks;

namespace QuietChat
{
    public class VoidManagerPlugin : VoidManager.VoidPlugin
    {
        public override MultiplayerType MPType => MultiplayerType.Client;

        public override string Author => "18107";

        public override string Description => "Removes chat messages produced by the game.\nPlayer messages are still displayed.";
    }
}
