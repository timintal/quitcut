// using UnityEngine;
// using VContainer;
//
// [RequireComponent(typeof(Camera))]
// public class GameCamera : MonoBehaviour
// {
//     [Inject] private CamerasController _camerasController;
//     private Camera _camera;
//     
//     private void Awake()
//     {
//         _camera = GetComponent<Camera>();
//     }
//
//     private void Start()
//     {
//         _camerasController.ActivateGameCamera(_camera);
//     }
//     
//     private void OnDestroy()
//     {
//         _camerasController.DeactivateGameCamera(_camera);
//     }
// }
