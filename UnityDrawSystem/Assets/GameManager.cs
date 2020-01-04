using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Sprite[] props;

    [Header("捲動速度"), Range(0.000001f, 3)]
    public float speed = 0.01f;
    [Header("捲動次數"), Range(1, 5)]
    public int count = 3;
    [Header("抽牌效果音效")]
    public AudioClip soundDraw;
    [Header("取得道具音效")]
    public AudioClip soundGet;


    private Image img;
    private Button btn;
    private AudioSource aud;

    private int index;

    private void Start()
    {
        img = GameObject.Find("道具圖片").GetComponent<Image>();
        btn = GameObject.Find("抽牌按鈕").GetComponent<Button>();
        aud = GetComponent<AudioSource>();

        btn.onClick.AddListener(PushButton);

        
    }

    private void PushButton()
    {
        StartCoroutine(ScrollEffect());
    }



    private IEnumerator ScrollEffect()
    {
        btn.interactable = false;
        for(int j = 0; j < count; j++)
        {
            for (int i = 0; i < props.Length; i++)
            {
                img.sprite = props[i];
                aud.PlayOneShot(soundDraw, 0.2f);
                yield return new WaitForSeconds(speed);               
            }
        }

        index = Random.Range(0, props.Length);
        img.sprite = props[index];
        aud.PlayOneShot(soundGet, 0.8f);
        btn.interactable = true;
    }
}
