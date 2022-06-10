using UnityEngine;

public class DataWeapon : MonoBehaviour
{
    [SerializeField] private string _name;

    public string Name { get { return _name; } }

    [SerializeField] private float _damage;

    public float Damage { get { return _damage; } }

    [SerializeField] private float _speedBullet;

    public float SpeedBullet { get { return _speedBullet; } }
}
