using Pool;
using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
   [SerializeField] private TestPool _gameObject;
   [SerializeField] private TestPool2 _gameObject1;

   private IPool _pool;
   private PoolData _data1;
   private PoolData _data2;

   [Inject]
   private void Construct(IPool pool)
   {
      _pool = pool;


      _data1 = new PoolData(_gameObject, "TestPool1");
      _data2 = new PoolData(_gameObject1, "TestPool2");
      
      _pool.PreparePool<TestPool>(_data1, 3);
      _pool.PreparePool<TestPool2>(_data2, 2);
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Alpha1))
      {
         var testPool = _pool.Get<TestPool>(_data1);
         
         testPool.gameObject.SetActive(true);
         testPool.transform.position = transform.position;
      }
      
      if (Input.GetKeyDown(KeyCode.Alpha2))
      {
         var testPool = _pool.Get<TestPool2>(_data2);
         
         testPool.gameObject.SetActive(true);
         testPool.transform.position = transform.position;
      }
      
      if (Input.GetKeyDown(KeyCode.Alpha3))
      {
         _pool.FreeAllPool();
         Debug.Log("Все объекты освобождены.");
      }
      
      if (Input.GetKeyDown(KeyCode.Alpha4))
      {
         _pool.FreePool(_data1);
         
         Debug.Log("Пул TestPool1 очищен.");
      }
      
      if (Input.GetKeyDown(KeyCode.Alpha5))
      {
         var all = _pool.GetPool();
         Debug.Log($"Объектов в пуле: {all.Count}");
      }
   }
}