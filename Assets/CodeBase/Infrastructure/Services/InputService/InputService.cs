using System;
using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.InputService
{
    public class InputService : IInputService
    {
        protected const string VerticalAxis = "Vertical";
        protected const string HorizontalAxis = "Horizontal";
        private readonly ICoroutineRunner _coroutineRunner;
        private Coroutine _coroutine;

        public event Action SpaceKeyDown;
        public event Action MouseButtonDown;

        public Vector3 Axis => GetAxis();

        public InputService(ICoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        public void StartUpdate() =>
            _coroutine = _coroutineRunner.StartCoroutine(Update());

        private Vector3 GetAxis() =>
            new Vector3(Input.GetAxis(VerticalAxis), 0, Input.GetAxis(HorizontalAxis));

        private IEnumerator Update()
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Space))
                SpaceKeyDown?.Invoke();

            if (Input.GetMouseButtonDown(0))
                MouseButtonDown?.Invoke();

            _coroutine = _coroutineRunner.StartCoroutine(Update());
        }
    }
}