using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject PanelCredits;
    public GameObject PanelPrincipal;


    // Start is called before the first frame update
    void Start()
    {
        PanelCredits.SetActive(false);
        PanelPrincipal.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void GoTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void PainelCreditos()
    {
        PanelCredits.SetActive(true);
        PanelPrincipal.SetActive(false);
    }

    public void PainelCreditosExit()
    {
        PanelCredits.SetActive(false);
        PanelPrincipal.SetActive(true);
    }


    //public void MenuPrincipal()
    //{
    //    SceneManager.LoadScene("MenuPrincipal");
    //    Destroy(GameObject.Find("Logic"));
    //}

}
