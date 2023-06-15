using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SkillController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform button;
    RectTransform rectTransform;
    Image skillBarImag;
    Color skillBarColor;
    Vector2 buttonPos;

    public float buttonRange =150;

    Image skillBar;
    public float maxSkillCount = 10;
    public float skillCount = 0;

    private void Awake()
    {
        skillBarImag = GetComponent<Image>();
        skillBarColor = skillBarImag.color;
        rectTransform = GetComponent<RectTransform>();
        buttonPos = button.anchoredPosition;
        skillBar = button.GetComponent<Image>();
        //buttonImg = button.GetComponent<Image>();
        skillBarColor.a = 0;
        skillBarImag.color = skillBarColor;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (skillCount == maxSkillCount)
        {
            var inputDir = eventData.position - rectTransform.anchoredPosition;

            var clampedDir = inputDir.magnitude < buttonRange ?
                inputDir : inputDir.normalized * buttonRange;

            button.anchoredPosition = clampedDir;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (skillCount == maxSkillCount)
        {
            var inputDir = eventData.position - rectTransform.anchoredPosition;

            var clampedDir = inputDir.magnitude < buttonRange ? inputDir : inputDir.normalized * buttonRange;
            button.anchoredPosition = clampedDir;

            if (button.anchoredPosition.y >= buttonRange - 2f)
            {
                button.anchoredPosition = buttonPos;
                skillCount = 0;
                skillBar.fillAmount = skillCount / maxSkillCount;

                skillBarColor.a = 0;
                skillBarImag.color = skillBarColor;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        button.anchoredPosition = buttonPos;
    }

    public void SetSkillCount()
    {
        skillCount++;
        skillBar.fillAmount = skillCount / maxSkillCount;
        if(skillCount == maxSkillCount)
        {
            skillBarColor.a = 0.58f;
            skillBarImag.color = skillBarColor;
        }
    }
}
