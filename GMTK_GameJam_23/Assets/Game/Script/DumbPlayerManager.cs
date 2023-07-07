using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;

namespace BridgePlatformer {

    // TODO: Do I nee to make this a constant?
    public class DumbPlayerManager : MonoBehaviour
    {
        private static DumbPlayerManager instance;
        public static DumbPlayerManager Instance
		{
            get
			{
                if (instance == null)
				{
                    instance = FindAnyObjectByType<DumbPlayerManager>();
				}
                return instance;
			}
		}


    }
}
