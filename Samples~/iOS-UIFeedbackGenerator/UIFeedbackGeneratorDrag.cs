#if UNITY_IOS && !UNITY_EDITOR
using Gilzoide.ObjectiveC;
#endif
using UnityEngine;
using UnityEngine.EventSystems;

public class UIFeedbackGeneratorDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public UIImpactFeedbackStyle ImpactStyle;
    public float MovementForImpact = 100;

    private float _moved;
#if UNITY_IOS && !UNITY_EDITOR
    private StrongReference _feedbackGenerator;
#endif

    public void OnBeginDrag(PointerEventData data)
    {
        _moved = 0;
#if UNITY_IOS && !UNITY_EDITOR
        _feedbackGenerator = new Class("UIImpactFeedbackGenerator").Alloc("initWithStyle:", (long) ImpactStyle);
        _feedbackGenerator.Call("prepare");
#endif
    }

    public void OnDrag(PointerEventData data)
    {
        _moved += data.delta.magnitude;
        if (_moved >= MovementForImpact)
        {
#if UNITY_IOS && !UNITY_EDITOR
            _feedbackGenerator.Call("impactOccurred");
            _feedbackGenerator.Call("prepare");
#else
            Debug.Log("Impact!");
#endif
            _moved = 0;
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
#if UNITY_IOS && !UNITY_EDITOR
        _feedbackGenerator.Dispose();
#endif
    }

    public void SetImpactStyle(int style)
    {
        ImpactStyle = (UIImpactFeedbackStyle) style;
    }

    public enum UIImpactFeedbackStyle
    {
        Light,
        Medium,
        Heavy,
        Soft,
        Rigid,
    }
}