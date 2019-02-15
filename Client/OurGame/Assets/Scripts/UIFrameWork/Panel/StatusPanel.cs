using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPanel : BasePanel {

    private CanvasGroup canvasGroup;

    private void Start()
    {
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
    }

    public override void OnEnter()
    {
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    public override void OnExit()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }

    public override void OnPause()
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;
    }

    public override void OnResume()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
    }

    public void OnInventoryButtonClick()
    {
        UIManager.Instance.PushPanel(UIPanelType.Inventory);
    }
}
