using Caramba.Match3.Core.UI.Screens;
using Caramba.PersistentData;
using Caramba.PersistentData.Libraries.Caramba.PersistentData;
using Libraries.GameFlow.CommandQueue.Queue;
using Libraries.GameFlow.FSM;
using Libraries.Utils;
using QuitCut.Data;
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

            builder.RegisterBuildCallback(ContainerBuilt);
        }
        private void RegisterConfigs(IContainerBuilder builder)
        {
            foreach (var soConfig in _configs)
            {
                builder.RegisterInstance(soConfig).AsSelf();
            }
        }
        private static void RegisterDB(IContainerBuilder builder)
        {
            SQLiteDB db = new SQLiteDB();
            db.Open("quitcut.db");
            builder.RegisterInstance(db).AsSelf();
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
        }

        private void RegisterFsm(IContainerBuilder builder)
        {
            builder.Register<GameFSM>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<IGameStateFactory, GameStateFactory>(Lifetime.Singleton);

            builder.Register<FSMStateBase, LoadAppState>(Lifetime.Singleton).AsSelf();
        }
        private void RegisterServices(IContainerBuilder builder)
        {
        }

        private void ContainerBuilt(IObjectResolver resolver)
        {
            var fsm = resolver.Resolve<IGameFSM>();
            fsm.Push<LoadAppState>();
        }
    }
}