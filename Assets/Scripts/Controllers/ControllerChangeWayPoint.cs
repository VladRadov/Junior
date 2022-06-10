using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ControllerChangeWayPoint : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private CameraModel _camera;

    [SerializeField] private Transform[] wayPoints;

    private int _indexWayPoint;

    private UnityEvent<Vector3> _mouseClickEventHandler = new UnityEvent<Vector3>();

    private NavMeshAgent _agent;

    private void Start()
    {
        _mouseClickEventHandler.AddListener(_player.Move);
        _agent = _player.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _camera.ChangePosition(_player.transform.position);

        if (_indexWayPoint == wayPoints.Length && _agent.remainingDistance == 0)
            SceneManager.LoadScene(0);

        if (_indexWayPoint != wayPoints.Length)
        {
            var wayPoint = wayPoints[_indexWayPoint].GetComponent<WayPoint>();

            if ((Input.GetMouseButtonDown(0) || Input.touchCount != 0) && wayPoint.IsAllDeadEnemie() == false)
                _player.Fire(Camera.main.ScreenPointToRay(Input.mousePosition).direction);

            if (wayPoint.IsAllDeadEnemie() && _agent.remainingDistance == 0)
            {
                var target = wayPoints[_indexWayPoint].position;
                _mouseClickEventHandler.Invoke(target);
                NextWayPoint();
            }
        }
    }

    private void NextWayPoint()
    {
        _indexWayPoint++;
    }
}
