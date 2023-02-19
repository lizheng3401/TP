using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Framework.UI;
using Framework.Config;

namespace GameCore.UI
{
	public class PopUpDialog : UIController
	{
		private PopUpDialogView _view;
		public PopUpDialog(UIView view, UILayer layer = UILayer.Dialog) : base(view, layer)
		{
			this._view = view as PopUpDialogView;
		}

		public override void SetupView()
		{
			base.SetupView();
			this._view.ConfirmBtn.onClick.AddListener(QuitGame);
			this._view.CancelButton.onClick.AddListener(Cancel);
			this._view.ContentTxt.text = "ÍË³öÓÎÏ·";
		}

		public override void Dispose()
		{
			base.Dispose();
			this._view.ConfirmBtn.onClick.RemoveAllListeners();
			this._view.CancelButton.onClick.RemoveAllListeners();
		}

		public override void Exit()
		{
			base.Exit();
		}

		private void QuitGame()
		{
			this.Exit();
			Application.Quit();
		}

		private void Cancel()
		{
			this.Exit();
		}
	}
}


