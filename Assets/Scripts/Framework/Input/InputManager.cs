using GameCore.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Framework.Input
{
    public class InputManager : BaseModule
    {
        public MouseContext MouseContext;

        public InputManager() { 

        }
        
        internal override void Tick(float elapseSeconds, float realElapseSeconds)
        {
            GlobalInput();
		}

        internal override void ShutDown()
        {
            
        }

        internal void GlobalInput()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                PopUpDialog dialog = new PopUpDialog(new PopUpDialogView());
                dialog.Show();
            }
        }
    }
}
