using UnityEngine;

namespace EasyTweens
{
    public class ActivateGameObject : TweenBase, ITargetSetter<GameObject>
    {
        [ExposeInEditor] public GameObject GameObject;

        public override void UpdateTween(float time, float deltaTime)
        {
            if (deltaTime > 0 && (time - deltaTime) <= TotalDelay && time >= TotalDelay)
            {
                GameObject.SetActive(true);
            }

            if (deltaTime < 0 && (time - deltaTime) >= TotalDelay && time <= TotalDelay)
            {
                GameObject.SetActive(false);
            }
        }

        public void SetTarget(GameObject target)
        {
            GameObject = target;
        }
    }
}