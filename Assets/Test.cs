using UI;
using UI.Window.StartWindow;
using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
   private IUIController _uiController;
   
   [Inject]
   private void Construct(IUIController uiController)
   {
       _uiController = uiController;
   }

   private void Update()
   {
       if (Input.GetKeyDown(KeyCode.V))
       {
           _uiController.ShowWindow<StartWindowController>();
       }
   }
}
