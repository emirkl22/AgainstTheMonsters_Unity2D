using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private AudioManager audioManager;
    [SerializeField]    
    private GameObject title;
    [SerializeField]
    private Image soldierImage;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        ButtonTweenFunc(gameObject.transform);
        ShakeTitle(title.transform);
        FadeImage(soldierImage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadEntrance()
    {
        audioManager.PlaySFX(audioManager.Button);
        audioManager.ChangeSceneMusic(1);
        SceneManager.LoadScene(1);
    }
    private void ButtonTweenFunc(Transform button)
    {
        button.DOScale(new Vector3(2.5f, 6.5f), 1f).SetLoops(-1, LoopType.Yoyo);
    }
    private void ShakeTitle(Transform transform)
    {
        transform.DOShakePosition(5f, 10f, 5, 90f, false, true);
    }
    private void FadeImage(Image image)
    {
        image.DOFade(0.5f, 15f).SetEase(Ease.InOutBack).SetLoops(-1, LoopType.Yoyo);
    }
}
