using strange.extensions.mediation.impl;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallView : View
{
    public event Action OnBallLost;

    [SerializeField] private Rigidbody2D _rigidbody;

    [Inject] public InputManager InputManager { get; private set; }
    [Inject] public GameSpaceObjectsHolder ObjectsHolder { get; private set; }
    [Inject] public Config Config { get; private set; }

    private bool _isBallOnPaddle;

    void Start()
    {
        _isBallOnPaddle = true;
        InputManager.OnInputDown += OnInputDownHandler;
    }

    void OnDestroy()
    {
        InputManager.OnInputDown -= OnInputDownHandler;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DeathZone"))
        {
            OnBallLost?.Invoke();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnInputDownHandler(Vector2.zero);
        }
    }

    private void OnInputDownHandler(Vector2 position)
    {
        if (!_isBallOnPaddle) return;

        _rigidbody.velocity = DirectionFromAngle(Random.Range(30f, 150f)) * Config.BallSpeed;
        transform.SetParent(ObjectsHolder.transform);
        _isBallOnPaddle = false;
    }

    private Vector2 DirectionFromAngle(float angleDegrees)
    {
        float angleRadians = angleDegrees * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(angleRadians), Mathf.Sin(angleRadians)).normalized;
    }

    public void ReturnToPaddle(PaddleView paddleView)
    {
        transform.position = paddleView.BallStartPoint.position;
        transform.SetParent(paddleView.BallStartPoint);
        _rigidbody.velocity = Vector2.zero;
        _isBallOnPaddle = true;
    }
}