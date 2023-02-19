using UnityEngine;
using UnityEngine.UI;

using Framework.UI;


namespace GameCore.UI
{
	public class PopUpDialogView : UIView
	{
		private Button _confirmBtn;
		private Button _cancelButton;
		private Text _contentTxt;

		public Button ConfirmBtn { get => _confirmBtn;}
		public Button CancelButton { get => _cancelButton;}
		public Text ContentTxt { get => _contentTxt; }

		public override void Init()
		{
			_confirmBtn = this.FindComponentInChildren<Button>(Root, "Confirm_Btn");
			_cancelButton = this.FindComponentInChildren<Button>(Root, "Cancel_Btn");
			_contentTxt = this.FindComponentInChildren<Text>(Root, "Content_Txt");
		}

		public override string GetPrefabPath()
		{
			return "UI/Common/PopUpDialog";
		}

		public override void Destroy()
		{
			base.Destroy();
		}
	}
}