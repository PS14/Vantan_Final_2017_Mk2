using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ResultMgr : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var menuSelector = GetComponent<MSMM.MenuSelector>();

        if (Input.GetAxis("BottomGreen") == 1)
        {


            SceneManager.LoadScene("InvaderTitle");
            menuSelector.Reset();


        }
        if (Input.GetAxis("BottomRed") == 1)
        {

            SceneManager.LoadScene("MainTitle");
            SoundMgr.StopBgm();
            menuSelector.Reset();

        }
    }
}
