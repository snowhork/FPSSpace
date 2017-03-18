using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Players
{
    [RequireComponent(typeof(RigidbodyFirstPersonController))]
    public class CameraHeightManager : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _heightWithStaning;
        [SerializeField] private float _heightWithSquatting;
        private RigidbodyFirstPersonController _firstPersonController;

        private void Start()
        {
            _firstPersonController = GetComponent<RigidbodyFirstPersonController>();
        }

        private void Update()
        {
            var positionY = _firstPersonController.Squatting ? _heightWithSquatting : _heightWithStaning;
            var pos = _camera.transform.position;
            _camera.transform.position = new Vector3(pos.x, positionY, pos.z);
        }
    }
}
