using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public float score = 0; 
    Slider slider;
    GameObject levelText;
    GameObject infoText;
    [SerializeField] GameObject spikedBall;
    [SerializeField] GameObject bullet;
    GameObject player;
    Shooter shooterS;
    float level = 1;
    int childCount;

    // Start is called before the first frame update
    void Start()
    {
        infoText = GameObject.Find("Info Text");
        player = GameObject.Find("Player");
        shooterS = player.GetComponent<Shooter>();
        levelText = GameObject.Find("TMP");
        childCount = spikedBall.transform.childCount;

        spikedBall.GetComponent<Collider>().enabled = false;
        for (int i = 0; i < childCount; i++)
        {
            spikedBall.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;    
        } 

        infoText.GetComponent<TextMeshProUGUI>().SetText(" ");      
    }

    // Update is called once per frame
    void Update()
    {
        slider = GetComponent<Slider>();
        slider.value = score / 100;
        bool upgrade = false;

        if (slider.value == slider.maxValue)
        {
            score = 0;
            level+=1;
            slider.maxValue+=1;
            levelText.GetComponent<TextMeshProUGUI>().SetText("Level "+level);
        }  

        if (level == 2 && upgrade == false) 
        {
            upgrade = true;
            spikedBall.GetComponent<Collider>().enabled = true;
            for (int i = 0; i < childCount; i++)
            {
                spikedBall.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = true;    
            } 
            infoText.GetComponent<TextMeshProUGUI>().SetText("Upgrade  Spiked Ball"); 
            upgrade = false; 
        } 

        if (level == 3 && upgrade == false) 
        {
            upgrade = true;
            shooterS.fireRate=0.4f;
            infoText.GetComponent<TextMeshProUGUI>().SetText("Upgrade  Fire Rate");
            upgrade = false;    
        }

        if (level == 4 && upgrade == false)
        {
            upgrade = true;
            player.GetComponent<SphereCollider>().radius=16;
            infoText.GetComponent<TextMeshProUGUI>().SetText("Upgrade  Range");
            upgrade = false;
        } 

        if (level == 5 && upgrade == false)
        {
            upgrade = true;
            shooterS.fireRate=0.3f;
            infoText.GetComponent<TextMeshProUGUI>().SetText("Upgrade  Fire Rate");
            upgrade = false;    
        }

        if (level == 6 && upgrade == false)
        {
            upgrade = true;
            bullet.GetComponent<SphereCollider>().radius = 1;
            infoText.GetComponent<TextMeshProUGUI>().SetText("Upgrade  Bigger  Bullet Impact"); 
            upgrade = false;   
        }

        if (level == 7 && upgrade == false)
        {
            upgrade = true;
            player.GetComponent<SphereCollider>().radius = 20;
            infoText.GetComponent<TextMeshProUGUI>().SetText("Upgrade  Range");
            upgrade = false;    
        }

        if (level == 8 && upgrade == false)
        {
            upgrade = true;
            shooterS.fireRate=0.2f;
            infoText.GetComponent<TextMeshProUGUI>().SetText("Upgrade  Fire Rate");
            upgrade = false;    
        }

        if (level == 9 && upgrade == false)
        {
            upgrade = true;
            bullet.GetComponent<SphereCollider>().radius=1.5f;
            infoText.GetComponent<TextMeshProUGUI>().SetText("Upgrade  Bigger  Bullet Impact");
            upgrade = false;    
        }

        if (level == 10 && upgrade == false)
        {
            upgrade = true;
            infoText.GetComponent<TextMeshProUGUI>().SetText("You Won");
            Invoke("LoadScene",2f);
            upgrade = false;    
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadScene();    
        }
    } 

    void LoadScene(){
       SceneManager.LoadScene("SampleScene"); 
    } 
}
