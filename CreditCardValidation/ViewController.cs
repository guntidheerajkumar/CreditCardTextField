using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace CreditCardValidation
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			TxtCard.ShouldChangeCharacters += TxtCard_ShouldChangeCharacters;
			TxtCard.LeftView = new UIView(new CGRect(0, 0, 5, TxtCard.Frame.Height));
			TxtCard.LeftViewMode = UITextFieldViewMode.Always;
		}

		private bool TxtCard_ShouldChangeCharacters(UITextField textField, NSRange range, string replacementString)
		{
			if (range.Location == 19)
				return false;

			if (replacementString.Length == 0)
				return true;

			Int32 n;
			if (range.Length == 0 && !Int32.TryParse(replacementString, out n)) {
				return false;
			}

			if (range.Location == 4 || range.Location == 9 || range.Location == 14) {
				var str = textField.Text + "-";
				textField.Text = str;
			}

			return true;
		}
	}
}
