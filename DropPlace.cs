using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DropPlace : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Letters letters = eventData.pointerDrag.GetComponent<Letters>();
        if (letters)
            letters.DefaultParent = transform;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Letters letters = eventData.pointerDrag.GetComponent<Letters>();

        if (letters)
            letters.DefaultTempCardParent = transform;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Letters letters = eventData.pointerDrag.GetComponent<Letters>();

        if (letters && letters.DefaultTempCardParent == transform)
            letters.DefaultTempCardParent = letters.DefaultParent;

    }
}
