using System.Collections.Generic;
using UnityEngine;

namespace MyAssets
{
    /*
     * スライムの攻撃動作準備状態
     */
    [System.Serializable]
    public class ReadySlimeAttackState : SlimeStateBase
    {
        private IMovement               movement;
        private IVelocityComponent      velocity;
        private ISlimeAnimator          animator;

        private Timer                   readyTimer = new Timer();

        [SerializeField]
        private float                   readyCount;

        [SerializeField]
        private float                   idleSpeed;

        [SerializeField]
        private float                   gravityMultiply;

        public static readonly string   StateKey = "ReadyAttack";
        public override string          Key => StateKey;

        public override List<ICharacterStateTransition<string>> CreateTransitionList(ISlimeSetup enemy)
        {
            List<ICharacterStateTransition<string>> re = new List<ICharacterStateTransition<string>>();
            
            if (StateChanger.IsContain(SlimeDamageState.StateKey)) { re.Add(new IsEnemyDamageTransition(enemy, StateChanger, SlimeDamageState.StateKey)); }
            if (StateChanger.IsContain(SlimeAttackState.StateKey)) { re.Add(new IsAttackTransition(enemy,readyTimer, StateChanger, SlimeAttackState.StateKey)); }
            if (StateChanger.IsContain(SlimeDeathState.StateKey)) { re.Add(new IsDeathTransition(enemy, StateChanger, SlimeDeathState.StateKey)); }
            return re;
        }

        public override void DoSetup(ISlimeSetup actor)
        {
            base.DoSetup(actor);
            animator = actor.SlimeAnimator;
            movement = actor.Movement;
            velocity = actor.Velocity;
        }

        public override void DoStart()
        {
            base.DoStart();
            readyTimer.Start(readyCount);

            movement.Stop();
            animator.Animator.SetTrigger(animator.AttackTriggerAnimationID);
        }

        public override void DoUpdate(float time)
        {
            base.DoUpdate(time);
            readyTimer.Update(time);
        }
        public override void DoFixedUpdate(float time)
        {
            base.DoFixedUpdate(time);
            movement.Move(idleSpeed);
            velocity.Rigidbody.velocity += Physics.gravity * gravityMultiply * time;
        }
    }
}
