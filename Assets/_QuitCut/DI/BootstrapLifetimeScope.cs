using System;
using Cysharp.Threading.Tasks;
using Libraries.GameFlow.CommandQueue.Queue;
using Libraries.GameFlow.FSM;
using Libraries.Utils;
using PersistentData;
using QuitCut.Cheats;
using QuitCut.Data;
using QuitCut.Data.Database;
using QuitCut.Data.DataServices;
using QuitCut.GameFlow;
using UIFramework;
using UIFramework.FlyingRewardsUIFeedback;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace QuitCut.DI
{
    public class BootstrapLifetimeScope : LifetimeScope
    {
        [SerializeField] private Canvas _mainCanvas;
        [SerializeField] private UISettings _uiSettings;
        [SerializeField] DefaultRewardIconProvider _defaultRewardIconProvider;
        [SerializeField] private ScriptableObject[] _configs;

        protected override void Configure(IContainerBuilder builder)
        {
            RegisterDB(builder);
            RegisterConfigs(builder);

            builder.Register<AutoInjectFactory>(Lifetime.Singleton).AsSelf();
            builder.Register<PoolService>(Lifetime.Singleton).AsSelf();
            builder.Register<CommandQueueFactory>(Lifetime.Singleton).AsSelf();

            RegisterUI(builder);
            RegisterData(builder);
            RegisterFsm(builder);

            RegisterServices(builder);
            RegisterCheats(builder);

            builder.RegisterBuildCallback(ContainerBuilt);
        }
        private void RegisterCheats(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<QuitCutCheats>().AsSelf();
        }
        private void RegisterConfigs(IContainerBuilder builder)
        {
            foreach (var soConfig in _configs)
            {
                builder.RegisterInstance(soConfig).AsSelf();
            }
        }
        private void RegisterDB(IContainerBuilder builder)
        {
            SQLiteDB db = new SQLiteDB();
            OpenDatabaseConnection(db).Forget();
            builder.RegisterInstance(db).AsSelf();

            builder.RegisterEntryPoint<DataBaseService>().AsSelf();
        }
        private async UniTaskVoid OpenDatabaseConnection(SQLiteDB db)
        {
            bool connected = false;
            try
            {
                db.Open("quitcut.db");
                connected = true;
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to open database: " + e.Message + "");
            }
            
            if (!connected)
            {
                await UniTask.Delay(3000);
                OpenDatabaseConnection(db).Forget();
            }
        }

        private void RegisterUI(IContainerBuilder builder)
        {
            var uiFrame = _uiSettings.BuildUIFrame(_mainCanvas);
            SceneManager.MoveGameObjectToScene(uiFrame.gameObject, gameObject.scene);
            builder.RegisterInstance(uiFrame).AsSelf();
            builder.RegisterEntryPoint<FlyingRewardsService>().AsSelf();
            builder.RegisterInstance(_defaultRewardIconProvider).As<IRewardIconProvider>();

            builder.RegisterBuildCallback(resolver =>
            {
                uiFrame.Initialize(resolver.Resolve<AutoInjectFactory>());
                uiFrame.OpenAsync<FlyingRewardsScreen>();
            });
        }

        private void RegisterData(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<DataManager>().AsSelf();
            builder.Register<IPersistentDataHandler, PlayerPrefsDataHandler>(Lifetime.Singleton);

            builder.Register<PersistentDataBase, PlayerData>(Lifetime.Singleton).AsSelf();

            builder.RegisterEntryPoint<PlayerDataService>().AsSelf();
            
            
            builder.RegisterEntryPoint<CigarettesData>().AsSelf();
            builder.RegisterEntryPoint<ChallengesData>().AsSelf();
        }

        private void RegisterFsm(IContainerBuilder builder)
        {
            builder.Register<GameFSM>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<IGameStateFactory, GameStateFactory>(Lifetime.Singleton);

            builder.Register<FSMStateBase, LoadAppState>(Lifetime.Singleton).AsSelf();
        }
        private void RegisterServices(IContainerBuilder builder) { }

        private void ContainerBuilt(IObjectResolver resolver)
        {
            var fsm = resolver.Resolve<IGameFSM>();
            fsm.Push<LoadAppState>();
        }
    }
}