using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

namespace MoreMountains.CorgiEngine
{
    public class AIDecisionStopButtonHeld : AIDecision
    {
        /// The input that returns true if currently down
		[Tooltip("The name of the tested input")]
        public string InputName = "Stop_Movement";

		public override bool Decide()
		{
			return Input.GetAxis(InputName) != 0;
		}
	}
}
