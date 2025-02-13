using UnityEngine;

namespace MyAssets
{
    /*
     * 移動処理クラスのインターフェース
     */
    public interface IMovement
    {
        void Stop();
        void Move(float maxSpeed);

        void RollingMove(float maxSpeed);
        void ForwardMove(float maxSpeed);

        void ForwardLerpMove(Vector3 basePos,float dis);

        void TargetLerpMove(Vector3 basePos,Vector3 targetPos,float power);

        void StartClimbStep(Vector3 hitPoint);

        void MoveTo(Vector3 targetPoint, float targetMoveSpeed, float moveSpeedChangeRate, float rotationSpeed, float time);

        void SideMove(float dir, float speed, Vector3 targetPoint, float rotationSpeed, float time);

        void DecreaseMove(float ratio);
    }
}
