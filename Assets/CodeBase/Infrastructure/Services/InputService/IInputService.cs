using System;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.InputService
{
    public interface IInputService : IService
    {
        void StartUpdate();
        event Action EKeyDown;
        event Action MouseButtonDown;
        Vector3 Axis { get; }
    }
}