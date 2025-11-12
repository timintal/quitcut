using System;
using QuitCut.Services;
using Sirenix.OdinInspector;
using UniLabs.Time;
using UnityEngine;

namespace QuitCut.Cheats
{
    [CreateAssetMenu( fileName = "FakeTimeSettings", menuName = "QuitCut/FakeTimeSettings", order = 0)]
    public class FakeTimeSettings : ScriptableObject
    {
        public UDateTime FakeTime;
        [OnValueChanged(nameof(UpdateTimeScale))]
        public float FakeTimeScale = 1f;
        public bool SetFakeTimeOnStart = true;

        private TimeService timeService;
        private TimeProvider timeProvider;
        
        public void SetDependencies(TimeService ts, TimeProvider tp)
        {
            timeService = ts;
            timeProvider = tp;
            if (SetFakeTimeOnStart) 
                SetFakeTime();
        }
        
        [Button]
        public void GetCurrentTime()
        {
            FakeTime = new UDateTime(timeProvider.GetUtcNow().DateTime);
        }
        
        [Button]
        public void SetFakeTime()
        {
            timeService.SetCurrentTime(FakeTime.DateTime);
            timeService.FakeTimeScale = FakeTimeScale;
        }

        private void UpdateTimeScale(float value)
        {
            timeService.FakeTimeScale = value;
        }
        
        [Button]
        public void AdvanceSeconds(int seconds)
        {
            timeService.Advance(seconds);
        }
    }
}