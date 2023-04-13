using System;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Panels")]
    [SerializeField] Panels pnl;
    [Header("Buttons")]
    [SerializeField] Buttons btn;

    [SerializeField] private GameObject takeOrCont;
    
    private CanvasGroup activePanel = null;
    
    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        btn.play.gameObject.SetActive(true);
        FadeInAndOutPanels(pnl.mainMenu);
    }

    public void StartGame()
    {
        GameManager.OnStartGame();
        FadeInAndOutPanels(pnl.gameIn);
    }

    public void OnFail()
    {
        FadeInAndOutPanels(pnl.fail);
    }

    public void ToggleTakeOrContinue()
    {
        takeOrCont.gameObject.SetActive(!takeOrCont.activeSelf);
    }

    public void ReloadScene()
    {
        GameManager.ReloadScene();
    }

    void FadeInAndOutPanels(CanvasGroup _in)
    {
        CanvasGroup _out = activePanel;
        activePanel = _in;

        if(_out != null)
        {
            _out.interactable = false;
            _out.blocksRaycasts = false;

            _out.DOFade(0f, 0.25f).OnComplete(() =>
            {
                _in.DOFade(1f, 0.25f).OnComplete(() =>
                {
                    _in.interactable = true;
                    _in.blocksRaycasts = true;
                });
            });
        }
        else
        {
            _in.DOFade(1f, 0.25f).OnComplete(() =>
            {
                _in.interactable = true;
                _in.blocksRaycasts = true;
            });
        }
    }

   

    [Serializable]
    public class Panels
    {
        public CanvasGroup mainMenu, gameIn, fail;
    }
    

    [Serializable]
    public class Buttons
    {
        public Button play;
    }

    
    
}
