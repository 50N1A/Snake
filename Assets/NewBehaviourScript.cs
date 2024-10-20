using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using Unity.Collections;
using Unity.VisualScripting;
using TMPro;


public class NewBehaviourScript : MonoBehaviour
{
    
    public GameObject Head;
    public GameObject Tail;
    public GameObject Apple;
    public TMP_Text Score;
    bool keyw = true;
    bool keya = false;
    bool keys = false;
    bool keyd = false;
    double DELAY = 0.3;
    double DeltaTimeSum = 0.0;

    int speed=2;

    int counter=0;
    
    List<GameObject> Tails = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Score.text = "Score: "+0;
        Apple.transform.position=new Vector3(Random.Range(-12,12)*2,Random.Range(-12,12)*2,-1);
        Tail.transform.position = new Vector3(0, -2, -1);
        transform.position = new Vector3(0, 0, -1);
        Tails.Add(Head);
        Tails.Add(Tail);
        Screen.SetResolution(800, 600, false);
        Debug.Log("Количество объектов в списке: " + Tails.Count);
    }
    void SwitchScene()
    {
        SceneManager.LoadScene("Menu");
    }
    // Update is called once per frame
    void Update()
    {

            if(Input.GetKeyDown(KeyCode.Escape)){
                SwitchScene();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if(keys==false){
                    keyw = true;
                    keya = false;
                    keys = false;
                    keyd = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if(keyd==false){
                    keyw = false;
                    keya = true;
                    keys = false;
                    keyd = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if(keyw==false){
                    keyw = false;
                    keya = false;
                    keys = true;
                    keyd = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if(keya==false){
                    keyw = false;
                    keya = false;
                    keys = false;
                    keyd = true;
                }
            }
            if(transform.position.x == Apple.transform.position.x && transform.position.y == Apple.transform.position.y)
            {
                counter++;
                Score.text = "Score: " + counter;
                Apple.transform.position=new Vector3((int)Random.Range(-12,12)*2,(int)Random.Range(-12,12)*2,-1);
                Tails.Add(Instantiate(Tail));
                Debug.Log("Количество объектов в списке: " + Tails.Count);
            }
            for(int i=Tails.Count-1;i>0;i--){
                    if(transform.position.x == Tails[i].transform.position.x && transform.position.y == Tails[i].transform.position.y)
                    {
                        Debug.Log("GameOver");
                        SwitchScene();
                    }

                }
           
            if(DeltaTimeSum >= DELAY)
            {
                
                for(int i=Tails.Count;i>2;i--){
                    Tails[i-1].transform.position=new Vector3(Tails[i-2].transform.position.x, Tails[i-2].transform.position.y, transform.position.z);
                    Tails[i-1].transform.rotation=Tails[i-2].transform.rotation;
                }
                Tail.transform.position= new Vector3(transform.position.x, transform.position.y, transform.position.z);
                Tail.transform.rotation=transform.rotation;
                DeltaTimeSum=0;
                if (keyw)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
                    transform.rotation = new Quaternion(0f, 0f, 180f, 1f);
                }
                if (keya)
                {
                    transform.position = new Vector3(transform.position.x - speed , transform.position.y, transform.position.z);
                    
                    transform.rotation = new Quaternion(0f, 0f, -1f, 1f);
                }
                if (keyd)
                {
                    transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
                    transform.rotation = new Quaternion(0f, 0f, 1f, 1f);
                }
                if (keys)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
                    transform.rotation = new Quaternion(0f, 0f, 0f, 1f);
                }
                
                if (transform.position.y >= 25) transform.position = new Vector3(transform.position.x, transform.position.y - 50, transform.position.z);
                if (transform.position.y <= -25) transform.position = new Vector3(transform.position.x, transform.position.y + 50, transform.position.z);
                if (transform.position.x >= 25) transform.position = new Vector3(transform.position.x - 50, transform.position.y, transform.position.z);
                if (transform.position.x <= -25) transform.position = new Vector3(transform.position.x + 50, transform.position.y, transform.position.z);

            }
            
        DeltaTimeSum += Time.deltaTime;
    }
}