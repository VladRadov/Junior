using UnityEngine;

public class DataEnemy : MonoBehaviour
{
    [SerializeField] private float _health;

    public float Health { get { return _health; } set { _health = value; } }
}
