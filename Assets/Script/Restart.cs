using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restart()
    {
        SceneManager.LoadScene("PLAY");
    }
    public void shop()
    {
        SceneManager.LoadScene("SHOP");
    }
    public void set()
    {
        SceneManager.LoadScene("SETTING");
    }
}
