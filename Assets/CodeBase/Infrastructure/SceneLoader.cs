using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CodeBase.Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        public void Load(string scene, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(scene, onLoaded));

        private IEnumerator LoadScene(string scene, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == scene)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation progress = SceneManager.LoadSceneAsync(scene);

            while (!progress.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}