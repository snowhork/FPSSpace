using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

namespace Guns
{
    [RequireComponent(typeof(AudioSource))]
    public class GunController : MonoBehaviour
    {
        [SerializeField] private GunParameter _parameter;
        [SerializeField] private Transform _gunTop;
        [SerializeField] private AudioClip _shotClip;
        [SerializeField] private GameObject _fireParticle;
        private float _coolTime;
        private AudioSource _audioSource;

        private bool IsAbleToShot
        {
            get { return _coolTime < 0 && _parameter.BalletsNum >= 0; }
        }

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            _coolTime -= Time.deltaTime;
        }

        public void Shot()
        {
            if(!IsAbleToShot) return;
            _coolTime = _parameter.CoolTime;
            _parameter.BalletsNum--;
            _audioSource.PlayOneShot(_shotClip);
            var particle = InstantiateFire(_gunTop.position);
            particle.transform.parent = transform;
            RayCast();
        }

        private void RayCast()
        {
            var ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                InstantiateFire(hit.point);
            }
        }

        private GameObject InstantiateFire(Vector3 position)
        {
            var partilce = Instantiate(_fireParticle);
            partilce.transform.position = position;
            partilce.transform.LookAt(transform);
            Destroy(partilce, 0.1f);
            return partilce;
        }
    }
}