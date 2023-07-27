using Assets.CodeBase.Logic.Spawners.Coin;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;
using Assets.CodeBase.Infrastructure.Services.CoinSpawnerHandler;

namespace Assets.CodeBase.Infrastructure.Services.CoinSpawnService
{
    public class CoinSpawnService : ICoinSpawnService
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly ICoinSpawnerHandler _coinSpawnerHandler;
        private Coroutine _coroutine;

        public CoinSpawnService(ICoroutineRunner coroutineRunner, ICoinSpawnerHandler coinSpawnerHandler)
        {
            _coroutineRunner = coroutineRunner;
            _coinSpawnerHandler = coinSpawnerHandler;
        }

        public void StartSpawn() =>
            _coroutine = _coroutineRunner.StartCoroutine(SpawnProcess());

        private IEnumerator SpawnProcess()
        {
            yield return new WaitForSeconds(1);

            List<CoinSpawner> coinSpawners = _coinSpawnerHandler.CoinSpawners;
            int randomIndex = Random.Range(0, coinSpawners.Count);
            //TODO: Fix multiple coins spawn in one place
            CoinSpawner coinSpawner = coinSpawners.ElementAt(randomIndex);
            coinSpawner.Spawn();

            yield return SpawnProcess();
        }
    }
}
