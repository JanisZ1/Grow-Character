using Assets.CodeBase.Logic.Spawners.Coin;
using System.Collections.Generic;

namespace Assets.CodeBase.Infrastructure.Services.CoinSpawnerHandler
{
    public interface ICoinSpawnerHandler : IService
    {
        List<CoinSpawner> CoinSpawners { get; set; }
    }
}
