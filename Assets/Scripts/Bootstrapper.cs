using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bootstrapper
{
   [RuntimeInitializeOnLoadMethod]
   public static void Execute()
   {
      CreateObject<Main>();
      
   }

   public static void CreateObject<T>() where T:MonoBehaviour
   {
      if (Object.FindObjectOfType<T>() != null)
      {
         return;
      }

      var obj = new GameObject(typeof(T).Name);
      obj.AddComponent<T>();
   }
   
}
