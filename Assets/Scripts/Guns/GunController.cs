using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

namespace Guns
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(RayCasterByGun))]
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

        private void Update()
        {
            _coolTime -= Time.deltaTime;
        }

        public void Shot()
        {
            if(!IsAbleToShot) return;
            _coolTime = _parameter.CoolTime;
            _parameter.BalletsNum--;
            GetComponent<AudioSource>().PlayOneShot(_shotClip);
            InstantiateFire(_gunTop.position, transform);
            GetComponent<RayCasterByGun>().RayCast(InstantiateFire);
        }

        private void InstantiateFire(Vector3 position, Transform parent)
        {
            var particle = Instantiate(_fireParticle);
            particle.transform.position = position;
            particle.transform.LookAt(transform);
            particle.transform.parent = parent;
            Destroy(particle, 0.1f);
        }
    }
}