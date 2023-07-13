using Assets.CodeBase.Infrastructure.Services;
using System;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public interface IInputService : IService
    {
        void StartUpdate();
        event Action SpaceDown;
        Vector3 Axis { get; }
    }
}