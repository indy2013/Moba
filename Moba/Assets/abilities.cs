using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abilities : MonoBehaviour
{
    [Header("Abilty 1")]
    public Image abiltyImage1;
    public float cooldown1 = 5;
    bool isCooldown = false;
    public KeyCode abilty1;

    //Abilty 1 Input Variables
    Vector3 position;
    public Canvas abilty1canvas;
    public Image skillshot;
    public Transform player;


    [Header("Abilty 2")]
    public Image abiltyImage2;
    public float cooldown2 = 5;
    bool isCooldown2 = false;
    public KeyCode abilty2;

    //abilty 2 Input variables
    public Image targetCircle;
    public Image indicatorrangecircle;
    public Canvas abilty2canvas;
    private Vector3 posUp;
    public float maxAbilty2Distance;


    [Header("Abilty 3")]
    public Image abiltyImage3;
    public float cooldown3 = 5;
    bool isCooldown3 = false;
    public KeyCode abilty3;

    [Header("Abilty 4")]
    public Image abiltyImage4;
    public float cooldown4 = 5;
    bool isCooldown4 = false;
    public KeyCode abilty4;



    void Start()
    {
        abiltyImage1.fillAmount = 0;
        abiltyImage2.fillAmount = 0;
        abiltyImage3.fillAmount = 0;
        abiltyImage4.fillAmount = 0;

        skillshot.GetComponent<Image>().enabled = false;
        targetCircle.GetComponent<Image>().enabled = false;
        indicatorrangecircle.GetComponent<Image>().enabled = false;
    }

   
    void Update()
    {
        Abilty1();
        Abilty2();
        Abilty3();
        Abilty4();

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //abilty 1 inputs
        if(Physics.Raycast(ray,out hit, Mathf.Infinity))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }

        //abilty 2 inputs
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject != this.gameObject)
            {
                posUp = new Vector3(hit.point.x, 10f, hit.point.z);
                position = hit.point;
            }

        }

        //Abilty 1 canvas Inputs
        Quaternion transRot = Quaternion.LookRotation(position - player.transform.position);
        transRot.eulerAngles = new Vector3(90, transRot.eulerAngles.y, transRot.eulerAngles.z);

        abilty1canvas.transform.rotation = Quaternion.Lerp(transRot, abilty1canvas.transform.rotation,0f);

        //abilty 2 canvas Inputs
        var hitPosDir = (hit.point - transform.position).normalized;
        float distance = Vector3.Distance(hit.point, transform.position);
        distance = Mathf.Min(distance, maxAbilty2Distance);

        var newHitPos = transform.position  + hitPosDir * distance;
        abilty2canvas.transform.position = (newHitPos);


    }

    void Abilty1()
    {
        if(Input.GetKey(abilty1) && isCooldown == false)
        {
            skillshot.GetComponent<Image>().enabled = true;

            //disabla other ui
            indicatorrangecircle.GetComponent<Image>().enabled = false;
            targetCircle.GetComponent<Image>().enabled = false;

        }
        
        if(skillshot.GetComponent<Image>().enabled == true && Input.GetMouseButton(0))
        {
            isCooldown = true;
            abiltyImage1.fillAmount = 1;
        }

        if (isCooldown)
        {
            abiltyImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            skillshot.GetComponent<Image>().enabled = false;

            if (abiltyImage1.fillAmount <= 0)
            {
                abiltyImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

    void Abilty2()
    {
        if (Input.GetKey(abilty2) && isCooldown2 == false)
        {
            indicatorrangecircle.GetComponent<Image>().enabled = true;
            targetCircle.GetComponent<Image>().enabled = true;

            //disable skillshot
            skillshot.GetComponent<Image>().enabled = false;

        }

        if(targetCircle.GetComponent<Image>().enabled == true && Input.GetMouseButton(0))
        {
            isCooldown2 = true;
            abiltyImage2.fillAmount = 1;
        }

        if (isCooldown2)
        {
            abiltyImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;

            indicatorrangecircle.GetComponent<Image>().enabled = false;
            targetCircle.GetComponent<Image>().enabled = false;

            if (abiltyImage2.fillAmount <= 0)
            {
                abiltyImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }

    void Abilty3()
    {
        if (Input.GetKey(abilty3) && isCooldown3 == false)
        {
            isCooldown3 = true;
            abiltyImage3.fillAmount = 1;
        }

        if (isCooldown3)
        {
            abiltyImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;

            if (abiltyImage3.fillAmount <= 0)
            {
                abiltyImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }

    void Abilty4()
    {
        if (Input.GetKey(abilty4) && isCooldown4 == false)
        {
            isCooldown4 = true;
            abiltyImage4.fillAmount = 1;
        }

        if (isCooldown4)
        {
            abiltyImage4.fillAmount -= 1 / cooldown4 * Time.deltaTime;

            if (abiltyImage4.fillAmount <= 0)
            {
                abiltyImage4.fillAmount = 0;
                isCooldown4 = false;
            }
        }
    }
}
