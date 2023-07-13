using Assets.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public abstract class InputService : IInputService
    {
        protected const string VerticalAxis = "Vertical";
        protected const string HorizontalAxis = "Horizontal";

        public abstract Vector3 Axis { get; }
    }

    public interface IInputService : IService
    {
        Vector3 Axis { get; }
    }
}