using System;
using Type;
using UI;
using UI.Window;
using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
   private UIController _uiController;
   
   [Inject]
   private void Counstruct(UIController uiController)
   {
       _uiController = uiController;
   }

   private void Update()
   {
       if (Input.GetKeyDown(KeyCode.V))
       {
           _uiController.ShowWindow<MainWindow>();
       }
   }
}
