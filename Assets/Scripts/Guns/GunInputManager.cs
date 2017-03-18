using UnityEngine;

namespace Guns
{
    [RequireComponent(typeof(GunController))]
    public class GunInputManager : MonoBehaviour
    {
        private GunController _gunController;
        [SerializeField] private KeyCode _reloadKeyCode = KeyCode.R;

        private void Start()
        {
            _gunController = GetComponent<GunController>();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _gunController.Shot();
            }

            if (Input.GetKeyDown(_reloadKeyCode))
            {
                _gunController.Reload();
            }
        }
    }
}