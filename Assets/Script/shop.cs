using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class shop : MonoBehaviour
{
    AudioSource audio1;
    
    // Start is called before the first frame update
    void Start()
    { 
        audio1 = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
      
    }
    public void play()
    {
        SceneManager.LoadScene("play");
    }
    public void buyCar(int carIndex)
    {
        PlayerPrefs.SetInt("carIndex",carIndex);
    }
    public void set(int num)
    {
        PlayerPrefs.SetInt("num", num);
    }
    public void volume(float voControl)
    {   
        PlayerPrefs.SetFloat("volume",voControl);
    }

}
