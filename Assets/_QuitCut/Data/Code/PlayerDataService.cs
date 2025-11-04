using System;
using R3;
using VContainer;
using VContainer.Unity;

namespace QuitCut.Data
{
    public class PlayerDataService: IInitializable
    {
        [Inject] PlayerData _playerData;
        
        ReactiveProperty<DateTime> _joinDate = new ReactiveProperty<DateTime>();
        public ReadOnlyReactiveProperty<DateTime> JoinDate => _joinDate;
        
        public void Initialize()
        {
            _joinDate.Value = _playerData.JoinDate;
        }

        public void UpdateJoinDate(DateTime date)
        {
            _playerData.JoinDate = date;
            _playerData.IsDirty = true;
            _joinDate.Value = date;
        }
    }
}