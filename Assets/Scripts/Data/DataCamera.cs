using UnityEngine;
public class DataCamera : MonoBehaviour
{
    [SerializeField] private float _maxDistanceDelta;

    public float MaxDistanceDelta { get { return _maxDistanceDelta; } }
}
