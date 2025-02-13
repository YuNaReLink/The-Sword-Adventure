
namespace MyAssets
{
    /*
     * NPCの状態遷移のフラグクラス一覧
     */

    //NPCが止まる時
    public class IsNPCMoveTransition : CharacterStateTransitionBase
    {
        private readonly INPCCommandPanel commandPanel;

        public IsNPCMoveTransition(INPCSetup npc, IStateChanger<string> stateChanger, string changeKey)
            : base(stateChanger, changeKey)
        {
            commandPanel = npc.CommandPanel;
        }
        public override bool IsTransition() => !commandPanel.IsStopflag;
    }
    //NPCが動いた時
    public class IsNPCNotMoveTransition : CharacterStateTransitionBase
    {
        private readonly INPCCommandPanel commandPanel;

        public IsNPCNotMoveTransition(INPCSetup npc, IStateChanger<string> stateChanger, string changeKey)
            : base(stateChanger, changeKey)
        {
            commandPanel = npc.CommandPanel;
        }
        public override bool IsTransition() => commandPanel.IsStopflag;
    }
}
