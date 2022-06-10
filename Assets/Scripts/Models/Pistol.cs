using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{
    [SerializeField] GameObject _prefabBullet;

    private GameObject _bullet;

    private Vector3 _startPosition;

    private Vector3 _directionPosition;

    private DataWeapon _dataWeapon;

    private List<GameObject> _poolBullets = new List<GameObject>();

    private void Start()
    {
        _dataWeapon = transform.GetComponent<DataWeapon>();
    }

    private void Update()
    {
        Fire();
    }

    public void CreateBullet(Vector3 startPosition, Vector3 directionPosition)
    {
        float offsetY = 0.15f;
        float offsetZ = 0.05f;
        _startPosition = new Vector3(startPosition.x, startPosition.y + offsetY, startPosition.z + offsetZ);
        _directionPosition = new Vector3(directionPosition.x, 0, directionPosition.z);

        _bullet = GetBulletFromPool();
    }

    private GameObject GetBulletFromPool()
    {
        for (int i = 0; i < _poolBullets.Count; i++)
        {
            if (_poolBullets[i].gameObject.activeInHierarchy == false)
            {
                _poolBullets[i].SetActive(true);
                _poolBullets[i].transform.position = _startPosition;
                return _poolBullets[i];
            }
        }
        AddPoolBullet();

        return _poolBullets[_poolBullets.Count - 1];
    }

    private void AddPoolBullet()
    {
        var newBullet = Instantiate(_prefabBullet, _startPosition, Quaternion.identity);
        newBullet.SetActive(true);
        _poolBullets.Add(newBullet);
    }

    public void Fire()
    {
        if (_bullet != null)
            _bullet.GetComponent<Rigidbody>().velocity = _directionPosition * _dataWeapon.SpeedBullet;
    }
}
