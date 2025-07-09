using strange.extensions.mediation.impl;
using Unity.VisualScripting;
using UnityEngine;

public class PaddleView : View
{
    public Transform BallStartPoint;

    [Inject] public InputManager _inputManager { get; private set; }
    [Inject] public Camera _mainCamera { get; private set; }
    [Inject] public Config Config { get; private set; }

    void Start()
    {
        _inputManager.OnDrag += OnDragHandler;
    }

    void OnDestroy()
    {
        _inputManager.OnDrag -= OnDragHandler;
    }

    
    private void OnDragHandler(Vector2 currentPos, Vector2 frameDelta, Vector2 swipeDelta)
    {
        Vector3 worldTouchPos = Camera.main.ScreenToWorldPoint(currentPos);
        Vector3 localTouchPos = transform.parent.InverseTransformPoint(worldTouchPos);
        float clampedLocalX = Mathf.Clamp(localTouchPos.x, Config.PaddleBorders[0], Config.PaddleBorders[1]);

        transform.localPosition = new Vector3(clampedLocalX, transform.localPosition.y, transform.localPosition.z);
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 localPos = transform.localPosition;
        localPos.x += h * Config.PaddleSpeed * Time.deltaTime;
        localPos.x = Mathf.Clamp(localPos.x, Config.PaddleBorders[0], Config.PaddleBorders[1]);
        transform.localPosition = localPos;
    }
}