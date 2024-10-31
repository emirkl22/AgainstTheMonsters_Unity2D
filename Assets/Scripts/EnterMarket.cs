using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class EnterMarket : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;
    [SerializeField]
    GameObject market;
    PlayerMovement2 playerMovement;
    [SerializeField]
    GameObject startPos;
    [SerializeField]
    GameObject endPos;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();  
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerMovement = FindObjectOfType<PlayerMovement2>();
        if (playerMovement != null)
        {
            market.SetActive(true);
            audioManager.PlaySFX(audioManager.marketSwipe);
            OpeningAnim(market.transform);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        audioManager.PlaySFX(audioManager.marketSwipe);
        ClosingAnim(market.transform);
    }
    private void OpeningAnim(Transform marketTransform)
    {
        marketTransform.DOMove(endPos.transform.position, 1f).SetEase(Ease.InOutBack);
    }
    private void ClosingAnim(Transform marketTransform)
    {
        marketTransform.DOMove(startPos.transform.position, 0.7f).OnComplete(() =>
        {
            market.SetActive(false);
        });
    }
}
