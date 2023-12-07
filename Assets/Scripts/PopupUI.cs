using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class PopupUI<T> : MonoBehaviour where T : PopupUI<T>
{
    public Action OnClose;
    /// <summary>
    /// The public static reference to the instance
    /// Call if you sure the reference is available
    /// </summary>
    private static T _instance;
    private static bool instantiated; //checking bool is faster than checking null
    /// <summary>
    /// This is safe reference
    /// Call to get reference in Awake Function
    /// </summary>
    public static T instance
    {
        get
        {
            if (instantiated)
            {
                return _instance;
            }
            else
                return null;
        }
    }

    protected virtual void Awake()
    {
        if (window) window.SetActive(false);
        // Make instance in Awake to make reference performance uniformly.
        if (!_instance)
        {
            _instance = (T)this;
            instantiated = true;
        }
        // If there is an instance already in the same scene, destroy this script.
        else if (_instance != this)
        {
            Destroy(this);
        }
    }
    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
            instantiated = false;
        }
    }

    [Header("PopupUI:")]
    protected Coroutine closeCoroutine;
    public PopUpAnimate animate = PopUpAnimate.SLIDEDOWN;
    [HideInInspector] public float autoCloseTime = 5;
    [SerializeField] private Image backGround = default;
    [SerializeField] private Image fadeGround = default;
    [SerializeField] private GameObject window = default;
    [SerializeField] private bool destroyOnClose = true;
    [SerializeField] private float animateTime = 0.3f;
    private float _moveY = 2500f;
    private float _moveX = 1500f;

    protected virtual void OnEnable()
    {
        if (window) window.SetActive(true);
        StartCoroutine(IEShowPopup());
        if (animate == PopUpAnimate.AUTO_CLOSE)
        {
            closeCoroutine = StartCoroutine(IEAutoClose());
        }
    }
    public virtual void Close()
    {
        if (gameObject.activeSelf)
        {
            // AnalyticHelper.Screen.SetCurrentLocation(LOCATION_NAME.POPUP_CLOSE , true);
            StartCoroutine(IEHidePopup());
        }
    }
    protected IEnumerator IEAutoClose()
    {
        yield return new WaitForSeconds(autoCloseTime);
        Close();
    }

    protected virtual void WillShowContent()
    {

    }
    protected virtual void DidShowContent()
    {

    }

    private IEnumerator IEShowPopup()
    {

        if (window)
        {
            WillShowContent();
            var pos = window.transform.localPosition;
            switch (animate)
            {
                case PopUpAnimate.SLIDEDOWN:
                    pos.y = _moveY;
                    window.transform.localPosition = pos;
                    window.transform.DOLocalMoveY(0.0f, animateTime).OnComplete(() =>
                    {
                        DidShowContent();
                    }).SetUpdate(true);

                    break;
                case PopUpAnimate.SLIDERIGHT:
                    pos.x = -_moveX;
                    window.transform.localPosition = pos;
                    Debug.LogError(window.transform.localPosition);
                    window.transform.DOLocalMoveX(0.0f, animateTime).OnComplete(() =>
                    {
                        DidShowContent();
                    }).SetUpdate(true); ;

                    break;
                case PopUpAnimate.SLIDELEFT:
                    pos.x = _moveX;
                    window.transform.localPosition = pos;
                    window.transform.DOLocalMoveX(0.0f, animateTime).OnComplete(() =>
                    {
                        DidShowContent();
                    }).SetUpdate(true); ;

                    break;
                case PopUpAnimate.SCALEUP:
                    window.transform.localScale = Vector3.zero;
                    window.transform.DOScale(1f, animateTime).OnComplete(() =>
                    {
                        DidShowContent();
                    }).SetUpdate(true); ;

                    break;
                case PopUpAnimate.SCALEDOWN:
                    window.transform.localScale = new Vector3(10, 10, 1);
                    window.transform.DOScale(1f, animateTime).OnComplete(() =>
                    {
                        DidShowContent();
                    }).SetUpdate(true); ;
                    break;
                case PopUpAnimate.FADEIN:
                    if (fadeGround)
                    {
                        Color col = Color.black;
                        col.a = 1f;
                        fadeGround.color = col;
                        fadeGround.DOFade(0f, animateTime).SetUpdate(true); ;
                    }
                    break;
            }
        }
        yield return null;
    }
    protected IEnumerator IEHidePopup()
    {
        if (window)
        {
            var pos = window.transform.localPosition;
            switch (animate)
            {
                case PopUpAnimate.SLIDEDOWN:
                    window.transform.DOLocalMoveY(_moveY, animateTime).OnComplete(() =>
                    {
                        OnAnimationCloseFinish();
                    }).SetUpdate(true); ;

                    break;
                case PopUpAnimate.SLIDERIGHT:
                    window.transform.DOLocalMoveX(-_moveX, animateTime).OnComplete(() =>
                    {
                        OnAnimationCloseFinish();
                    }).SetUpdate(true); ;

                    break;
                case PopUpAnimate.SLIDELEFT:
                    window.transform.DOLocalMoveX(_moveX, animateTime).OnComplete(() =>
                    {
                        OnAnimationCloseFinish();
                    }).SetUpdate(true); ;

                    break;
                case PopUpAnimate.SCALEUP:
                    window.transform.DOScale(0f, animateTime).OnComplete(() =>
                    {
                        OnAnimationCloseFinish();
                    }).SetUpdate(true); ;
                    break;
                case PopUpAnimate.SCALEDOWN:
                    window.transform.DOScale(10f, animateTime).OnComplete(() =>
                    {
                        OnAnimationCloseFinish();
                    }).SetUpdate(true); ;

                    break;
                case PopUpAnimate.FADEIN:
                    if (fadeGround)
                    {
                        fadeGround.DOFade(1f, animateTime).OnComplete(() =>
                        {
                            OnAnimationCloseFinish();
                        }).SetUpdate(true); ;
                    }
                    break;
            }
        }
        else
        {
            OnAnimationCloseFinish();
        }
        yield return null;
    }
    protected virtual void OnAnimationCloseFinish()
    {
        OnClose?.Invoke();
        if (destroyOnClose)
        {
            //need Cache and re-use before change state
            _instance = null;
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}

public enum PopUpAnimate
{
    NONE,
    SLIDEDOWN,
    SLIDERIGHT,
    SLIDELEFT,
    SCALEUP,
    SCALEDOWN,
    SCALEROTATE,
    FADEIN,
    AUTO_CLOSE,
    FADE_SLIDE
}
public struct POPUP_NAME
{
    public const string DemoPopup = "DemoPopup";
    public const string SettingPopup = "SettingPopup";
    public const string CurrencyPopup = "CurrencyPopup";
}
