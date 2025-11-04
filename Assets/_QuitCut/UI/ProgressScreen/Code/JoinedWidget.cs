using System;
using QuitCut.Data;
using R3;
using UnityEngine;
using VContainer;

namespace QuitCut
{
    public class JoinedWidget : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI _joinedText;

        [Inject] PlayerDataService _playerDataService;

        void Start()
        {
            _playerDataService.JoinDate.Subscribe(SetJoinDate).AddTo(this);

        }
        public void SetJoinDate(DateTime joinDate)
        {
            _joinedText.text = $"{joinDate:MMMM yyyy}\n{(DateTime.UtcNow - joinDate).Days} days";
        }
    }
}
