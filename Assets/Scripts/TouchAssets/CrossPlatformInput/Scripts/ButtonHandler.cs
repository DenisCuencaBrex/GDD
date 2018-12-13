using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class ButtonHandler : MonoBehaviour
    {

        public string Name;
        //[SerializeField] bool pointing = false;
        public ColorMix colormix;

        void OnEnable()
        {

        }

        public void SetDownState()
        {
            //print(Name);
            if (Name == "Fire1")
            {
                colormix.pressed = 1;
            }
            if (Name == "Fire2")
            {
                colormix.pressed = 2;
            }
            if (Name == "Fire3")
            {
                colormix.pressed = 3;
            }
            //CrossPlatformInputManager.SetButtonDown(Name);
        }


        public void SetUpState()
        {
            //print(Name);
            

            
            if (Name == "Fire1" && colormix.pointing == 1) {
                print("lanzado rojo");
                CrossPlatformInputManager.SetButtonUp("Fire1");
            }
            else if (Name == "Fire2" && colormix.pointing == 2)
            {
                print("lanzado azul");
                CrossPlatformInputManager.SetButtonUp("Fire2");
            }
            else if (Name == "Fire3" && colormix.pointing == 3)
            {
                print("lanzado verde");
                CrossPlatformInputManager.SetButtonUp("Fire3");
            }
            else if (Name == "Fire1" && colormix.pointing == 2)     //crea violeta
            {
                print("lanzado violeta");
                CrossPlatformInputManager.SetButtonUp("Fire4");
            }

            else if (Name == "Fire1" && colormix.pointing == 3)     //crea naranja
            {
                print("lanzado naranja");
                CrossPlatformInputManager.SetButtonUp("Fire5");
            }

            else if (Name == "Fire2" && colormix.pointing == 1)     //crea violeta
            {
                print("lanzado violeta");
                CrossPlatformInputManager.SetButtonUp("Fire4");
            }

            else if (Name == "Fire2" && colormix.pointing == 3)     //crea amarillo
            {
                print("lanzado amarillo");
                CrossPlatformInputManager.SetButtonUp("Fire6");
            }

            else if (Name == "Fire3" && colormix.pointing == 1)     //crea naranja
            {
                print("lanzado naranja");
                CrossPlatformInputManager.SetButtonUp("Fire5");
            }

            else if (Name == "Fire3" && colormix.pointing == 2)     //crea amarillo
            {
                print("lanzado amarillo");
                CrossPlatformInputManager.SetButtonUp("Fire6");
            }
            colormix.pressed = 0;
            //CrossPlatformInputManager.SetButtonUp(Name);

        }


        public void OnEnterState()
        {
            if (Name == "Fire1") {
                colormix.pointing = 1;
            }
            else if (Name == "Fire2")
            {
                colormix.pointing = 2;
            }
            else if (Name == "Fire3")
            {
                colormix.pointing = 3;
            }
        }

        public void OnExitState() {
            colormix.pointing = 0;
        }

        public void SetAxisPositiveState()
        {
            CrossPlatformInputManager.SetAxisPositive(Name);
        }


        public void SetAxisNeutralState()
        {
            CrossPlatformInputManager.SetAxisZero(Name);
        }


        public void SetAxisNegativeState()
        {
            CrossPlatformInputManager.SetAxisNegative(Name);
        }

        public void Update()
        {

        }
    }
}
