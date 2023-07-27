using Assets.CodeBase.Logic.Spawners.Coin;
using System.Collections.Generic;

namespace Assets.CodeBase.Infrastructure.Services.CoinSpawnerHandler
{
    public class CoinSpawnerHandler : ICoinSpawnerHandler
    {
        public List<CoinSpawner> CoinSpawners { get; set; } = new List<CoinSpawner>();
    }
}
