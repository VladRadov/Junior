using UnityEngine;

public class CameraModel : MonoBehaviour
{
    private Vector3 _destinationPosition;

    private Vector3 _currentOffsetOfPlayer;

    private Vector3 _offsetOfPlayer;

    private DataCamera _dataCamera;

    private void Start()
    {
        _dataCamera = transform.GetComponent<DataCamera>();
    }

    private void FixedUpdate()
    {
        var a = transform.position - _offsetOfPlayer;
        if (_offsetOfPlayer != new  Vector3(0, 0, 0) && _currentOffsetOfPlayer != _offsetOfPlayer)
            Move();
        else
            _offsetOfPlayer = _currentOffsetOfPlayer;
    }

    public void ChangePosition(Vector3 positionPlayer)
    {
        _currentOffsetOfPlayer = positionPlayer - transform.position;

        if (_offsetOfPlayer == new Vector3(0, 0, 0))
            _offsetOfPlayer = _currentOffsetOfPlayer;

        _destinationPosition = new Vector3(positionPlayer.x + Mathf.Abs(_offsetOfPlayer.x), positionPlayer.y + Mathf.Abs(_offsetOfPlayer.y), positionPlayer.z - Mathf.Abs(_offsetOfPlayer.z));
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _destinationPosition, _dataCamera.MaxDistanceDelta);
    }
}
