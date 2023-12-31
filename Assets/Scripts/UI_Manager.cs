using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Text scoreText = null;


    [SerializeField]
    public Sprite[] _lifeImage;

    [SerializeField]
    private Image livesImage;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int lives)
    {
        livesImage.sprite = _lifeImage[lives];
    }
}
