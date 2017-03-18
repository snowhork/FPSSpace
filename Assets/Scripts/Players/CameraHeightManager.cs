using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Players
{
    [RequireComponent(typeof(RigidbodyFirstPersonController))]
    public class CameraHeightManager : MonoBehaviour
    {
        [SerializeField] private Transform _cameraOffset;
        [SerializeField] private float _heightWithStanding;
        [SerializeField] private float _heightWithSquatting;
        private RigidbodyFirstPersonController _firstPersonController;

        private void Start()
        {
            _firstPersonController = GetComponent<RigidbodyFirstPersonController>();
        }

        private void Update()
        {
            var positionY = _firstPersonController.Squatting ? _heightWithSquatting : _heightWithStanding;
            var pos = _cameraOffset.localPosition;
            _cameraOffset.transform.localPosition = new Vector3(pos.x, positionY, pos.z);
        }
    }
}
