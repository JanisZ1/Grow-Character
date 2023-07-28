using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.SaveLoad
{
    public class ProgressSaver
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly ISaveLoadService _saveLoadService;

        private Coroutine _coroutine;

        public ProgressSaver(ICoroutineRunner coroutineRunner, ISaveLoadService saveLoadService)
        {
            _coroutineRunner = coroutineRunner;
            _saveLoadService = saveLoadService;
        }

        public void StartProcess() =>
            _coroutine = _coroutineRunner.StartCoroutine(SaveProcess());

        private IEnumerator SaveProcess()
        {
            yield return new WaitForSeconds(1);
            _saveLoadService.SaveProgress();

            yield return SaveProcess();
        }
    }
}
