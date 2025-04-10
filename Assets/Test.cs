using Pool;
using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
   [SerializeField] private TestPool _gameObject;
   [SerializeField] private TestPool2 _gameObject1;
   private IPool _pool;
   
   [Inject]
   private void Construct(IPool pool)
   {
      _pool = pool;
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Alpha1))
      {
         var testPool = _pool.Get<TestPool>(_gameObject);
         
         testPool.gameObject.SetActive(true);
         testPool.transform.position = transform.position;
      }
      
      if (Input.GetKeyDown(KeyCode.Alpha2))
      {
         var testPool = _pool.Get<TestPool2>(_gameObject1);
         
         testPool.gameObject.SetActive(true);
         testPool.transform.position = transform.position;
      }
   }
}