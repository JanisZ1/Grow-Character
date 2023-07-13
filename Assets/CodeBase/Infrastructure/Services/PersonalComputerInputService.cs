using UnityEngine;

namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class PersonalComputerInputService : InputService
    {
        public override Vector3 Axis => GetAxis();

        private Vector3 GetAxis() =>
            new Vector3(Input.GetAxis(VerticalAxis), 0, Input.GetAxis(HorizontalAxis));
    }
}