using System;
using System.ComponentModel;
using QuitCut.Services;
using UnityEngine;
using VContainer;

namespace QuitCut.Cheats
{
    public class TimeCheats : CheatBase
    {
        [Inject] internal TimeService timeService;
        [Inject] internal TimeProvider timeProvider;
        
        [Category("Time"), UnityEngine.Scripting.Preserve]
        public string TimeToSet { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
        
        [Category("Time"), UnityEngine.Scripting.Preserve]
        public void SetFakeTime()
        {
            if (DateTimeOffset.TryParse(TimeToSet, out var dateTime))
            {
                SetFakeTime(dateTime);
            }
            else
            {
                Debug.LogError($"Invalid date format: {TimeToSet}");
            }
        }
        public void SetFakeTime(DateTimeOffset dateTime)
        {
            timeService.SetCurrentTime(dateTime);
        }

        [Category("Time"), UnityEngine.Scripting.Preserve]
        public void SetRealTime()
        {
            timeService.SetCurrentTime(DateTimeOffset.UtcNow);
        }

        [Category("Time"), UnityEngine.Scripting.Preserve]
        public int SecondsToAdvance { get; set; } = 60;
        
        [Category("Time"), UnityEngine.Scripting.Preserve]
        public void AdvanceTime()
        {
            timeService.Advance(SecondsToAdvance);
        }
        
        [Category("Time"), UnityEngine.Scripting.Preserve]
        public float FakeTimeScale { get; set; } = 1f;
        
        [Category("Time"), UnityEngine.Scripting.Preserve]
        public void SetTimeScale()
        {
            timeService.FakeTimeScale = FakeTimeScale;
        }
    }
}