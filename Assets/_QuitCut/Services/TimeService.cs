using System;
using Microsoft.Extensions.Time.Testing;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace QuitCut.Services
{
    public class TimeService : IInitializable, ITickable
    {
        [Inject] internal TimeProvider timeProvider;
        
        FakeTimeProvider fakeTimeProvider = null;
        
        public float FakeTimeScale { get; set; } = 1f;
        
        public void SetCurrentTime(DateTimeOffset dateTime)
        {
            if (fakeTimeProvider != null)
            {
                fakeTimeProvider.AdjustTime(dateTime);
            }
        }

        public void Advance(int seconds)
        {
            if (fakeTimeProvider != null)
            {
                fakeTimeProvider.Advance(TimeSpan.FromSeconds(seconds));
            }
        }

        public void Tick()
        {
            if (fakeTimeProvider != null)
            {
                fakeTimeProvider.Advance(TimeSpan.FromSeconds(Time.deltaTime * FakeTimeScale));
            }
        }

        public void Initialize()
        {
            fakeTimeProvider = timeProvider as FakeTimeProvider;
        }
    }
}