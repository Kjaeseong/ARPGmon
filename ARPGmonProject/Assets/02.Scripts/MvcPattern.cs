using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MVC
{
    public class MVC
    {
        public UnityEvent Stat { get; set; }

        public void Set()
        {
            Stat.Invoke();
        }
    }


}
