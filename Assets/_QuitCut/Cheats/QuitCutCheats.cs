using System.ComponentModel;
using QuitCut.Data;
using VContainer;

namespace QuitCut.Cheats
{
    public class QuitCutCheats : CheatBase
    {
        [Inject] PlayerDataService _playerDataService;
        
        [Category("Join")]
        public int DaysAgo { get; set; }
        [Category("Join")]
        public void UpdateJoinDate()
        {
            _playerDataService.UpdateJoinDate(System.DateTime.UtcNow.AddDays(-DaysAgo)); 
        }
    
    }
}