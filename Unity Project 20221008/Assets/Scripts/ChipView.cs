using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChipView : MonoBehaviour
{

    // Start is called before the first frame update
    //void Start()
    //{
    //    //RGBをランダムに設定
    //    _image.color = new Color(Random.Range(0, 1.0f), Random.Range(0,1.0f), Random.Range(0, 1.0f));
    //}

    [SerializeField]
    private Image _image = null;


    /// <summary>
    /// マップスプライトを設置する
    /// </summary>
    /// <param name="sprit"></param>

    public void SetImage(Sprite sprit) 
    {
        _image.sprite = sprit;
    }
    void Update()
    {
        
    }
}
