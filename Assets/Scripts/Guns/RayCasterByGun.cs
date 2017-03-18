using System;
using UnityEngine;

namespace Guns
{
    public class RayCasterByGun : MonoBehaviour
    {
        public void RayCast(Action<Vector3, Transform> hitParticle)
        {
            var ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                hitParticle(hit.point, hit.transform);
            }
        }
    }
}