using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager: MonoBehaviour, IDisposable
{
    public event Action<Vector2> OnInputDown;
    public event Action<Vector2, Vector2, Vector2> OnDrag;
    public event Action<Vector2, Vector2, Vector2> OnInputUp;

    public bool IsSwiping { get; private set; }

    public  GraphicRaycaster _uiRaycaster;
    private Vector2 _startTouchPosition;
    private Vector2 _currentTouchPosition;
    private Vector2 _prevFrameTouchPosition;

    public void Init(GraphicRaycaster uiRaycaster)
    {
        IsSwiping = false;
        _uiRaycaster = uiRaycaster;
        _startTouchPosition = Vector2.zero;
        _currentTouchPosition = Vector2.zero;
        _prevFrameTouchPosition = Vector2.zero;
    }

    public void Dispose()
    {
        OnInputDown = null;
        OnDrag = null;
        OnInputUp = null;

        IsSwiping = false;
        _uiRaycaster = null;
    }

    void Update()
    {
        if (Application.isEditor)
        {
            UpdateEditor();
        }
        else
        {
            UpdateDevice();
        }
    }

    public bool TryGetComponentOnUi<T>(Vector2 screenPosition, out T resultComponent) where T: Component
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = screenPosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        _uiRaycaster.Raycast(pointerData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.TryGetComponent<T>(out resultComponent))
            {
                return true;
            }
        }

        resultComponent = null;
        return false;
    }
    
    public bool IsPointerOverUIObject()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        _uiRaycaster.Raycast(eventData, results);
        return results.Count == 0;
    }

    private void UpdateEditor()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startTouchPosition = Input.mousePosition;
            _prevFrameTouchPosition = _startTouchPosition;
            OnInputDown?.Invoke(_startTouchPosition);
        }

        if (Input.GetMouseButton(0))
        {
            IsSwiping = true;
            _currentTouchPosition = Input.mousePosition;
            OnDrag?.Invoke(_currentTouchPosition, _currentTouchPosition - _prevFrameTouchPosition, _currentTouchPosition - _startTouchPosition);
            _prevFrameTouchPosition = _currentTouchPosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            IsSwiping = false;
            _currentTouchPosition = Input.mousePosition;
            OnInputUp?.Invoke(_currentTouchPosition, _currentTouchPosition - _prevFrameTouchPosition, _currentTouchPosition - _startTouchPosition);
            _prevFrameTouchPosition = Vector2.zero;
            _startTouchPosition = Vector2.zero;
        }
    }

    private void UpdateDevice()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startTouchPosition = touch.position;
                    OnInputDown?.Invoke(touch.position);
                    break;

                case TouchPhase.Moved:
                    IsSwiping = true;
                    _currentTouchPosition = touch.position;
                    OnDrag?.Invoke(_currentTouchPosition, touch.deltaPosition, _currentTouchPosition - _startTouchPosition);
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    IsSwiping = false;
                    _currentTouchPosition = touch.position;
                    OnInputUp?.Invoke(_currentTouchPosition, touch.deltaPosition, _currentTouchPosition - _startTouchPosition);
                    _startTouchPosition = Vector2.zero;
                    break;
            }
        }
    }
}
