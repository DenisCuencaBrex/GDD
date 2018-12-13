using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMix : MonoBehaviour {



    public GameObject redButton;
    public GameObject blueButton;
    public GameObject greenButton;

    public GameObject line; 

    public int pointing = 0;     // 0 = no hay botón presionado ;   1 = rojo ;   2 = azul ;     3 = verde
    public int pressed = 0;     // 0 = no esta sobre ningún boton ; 1 = rojo ;   2 = azul ;     3 = verde



    void Start () {
		
	}
	 
	
	void Update () {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began) {
                if (pointing == 1)
                {
                    line.transform.position = redButton.transform.position;
                }
                else if (pointing == 2)
                {
                    line.transform.position = blueButton.transform.position;
                }
                else if (pointing == 3)
                {
                    line.transform.position = greenButton.transform.position;
                }
            }

            if (touch.phase == TouchPhase.Moved )
            {
                if (pressed != 0)
                {
                    if (line.active == false) {
                    line.active = true;
                    }
                
                    Vector3 relativePos = new Vector3(touch.position.x, touch.position.y, 0) - line.transform.position;

                    relativePos.Normalize();

                    float rot_z = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
                    line.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

                    //float dist = Vector3.Distance(line.transform.position, touch.position);

                    //float dist = Vector3.Distance(line.transform.position, new Vector3 (Mathf.Clamp(touch.position, 0f, 5f)));

                    float dist = Mathf.Clamp(Vector3.Distance(line.transform.position, touch.position),0,300);

                    line.transform.localScale = new Vector3(transform.localScale.x, dist * 0.015f, transform.localScale.z);
                    print(dist);
                }
                
                
            }
            
            if (touch.phase == TouchPhase.Ended)
            {
                line.active = false;
            }
        }
    }


    public string GetButtonColorOver()
    {
        string color = "NoColor";
        if (pressed == 0)
        {
            color = "NoColor";
        }
        else if (pointing == 1 && pressed == 1)
        {
            color = "Red";
        }

        else if ((pointing == 1 && pressed == 2) || (pointing == 2 && pressed == 1))
        {
            color = "Violet";
        }

        else if ((pointing == 1 && pressed == 3) || (pointing == 3 && pressed == 1))
        {
            color = "Orange";
        }

        else if (pointing == 2 && pressed == 2)
        {
            color = "Blue";
        }
        else if ((pointing == 2 && pressed == 3) || (pointing == 3 && pressed == 2))
        {
            color = "Yellow";
        }

        else if (pointing == 3 && pressed == 3)
        {
            color = "Green";
        }


        return color;
    }


}
