using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool pointerDown;
    private float pointerDownTimer;

    [SerializeField] private float requiredHoldTime;

    public UnityEvent onLongClick;

    [SerializeField] private Image fillImage;


    private void Start()
    {
        Debug.Log("Fix is open");
        Debug.Log(pointerDown);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Debug.Log("onPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        Debug.Log("onPointerUp");
    }
    private void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer > requiredHoldTime)
            {
                if (onLongClick != null)
                {
                    onLongClick.Invoke();

                    Reset();
                }
                fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
            }
        }
    }
    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
    }

    public void Test()
    {
        Debug.Log("Fixed");
    }
}
