using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeWaitShooting;

    [SerializeField] private GameObject _bullet;

    private Transform _objectToShoot;

    private void Start()
    {
        StartCoroutine(_shootingWorker());
    }

    private IEnumerator _shootingWorker()
    {
        bool isWork = enabled;

        while (isWork)
        {
            var vector3direction = (_objectToShoot.position - transform.position).normalized;
            var newBullet = Instantiate(_bullet, transform.position + vector3direction, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.up = vector3direction;
            newBullet.GetComponent<Rigidbody>().velocity = vector3direction * _speed;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}