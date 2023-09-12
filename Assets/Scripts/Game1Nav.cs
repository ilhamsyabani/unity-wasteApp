using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game1Nav : MonoBehaviour
{
    public GameObject misi1, misi2, misi3, materi1, materi2, materi3, materi4, materi5, materi6, truck;
    private PlayerMovement playerMovement;
    private int nilai;


    void Start()
    {
        GameObject player = GameObject.Find("Player");

        if (player != null)
        {
            playerMovement = player.GetComponent<PlayerMovement>();
            playerMovement.MoveSpeed = 0f;
        }
        else
        {
            Debug.LogError("Player GameObject not found!");
        }
    }

    void Update()
    {
        GameObject point = GameObject.Find("pointhide");

        if (nilai > 0)
        {

            if (point != null)
            {
                point.transform.GetChild(nilai - 1).gameObject.GetComponent<Image>().color = new Color32(255, 255, 225, 225);
            }
            else
            {
                Debug.LogError("Player GameObject not found!");
            }
        } 

        if(nilai == 6){
            playerMovement.MoveSpeed = 0f;
            misi2.SetActive(true);
            truck.SetActive(true);
        }
    }

    private void jalan()
    {
        if (playerMovement != null)
        {
            playerMovement.MoveSpeed = 5f;
            Debug.Log(nilai);
        }
        else
        {
            Debug.LogError("PlayerMovement component not found!");
        }
    }

    public void tutupMisi1()
    {
        misi1.SetActive(false);
        jalan();
    }
    public void tutupMisi2()
    {
        Destroy(misi2);
        nilai = 0 ;
        jalan();
    }
    public void tutupMisi3()
    {
        SceneManager.LoadScene("game2");
        jalan();
    }

    public void tutupMateri1()
    {
        Destroy(materi1);
        nilai += 1;
        jalan();
    }
    public void tutupMateri2()
    {
        Destroy(materi2);
        nilai += 1;
        jalan();
    }
    public void tutupMateri3()
    {
        Destroy(materi3);
        nilai += 1;
        jalan();
    }
    public void tutupMateri4()
    {
        Destroy(materi4);
        nilai += 1;
        jalan();
    }
    public void tutupMateri5()
    {
        Destroy(materi6);
        nilai += 1;
        jalan();
    }
    public void tutupMateri6()
    {
        Destroy(materi6);
        nilai += 1;
        jalan();
    }
}
