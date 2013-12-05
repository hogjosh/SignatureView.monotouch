using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SignatureView;
using MonoTouch.OpenGLES;

namespace Sample
{
	public class SignatureViewController : UIViewController
	{
		NICSignatureView m_signatureView;

		bool m_didUpdateConstraints;
	
		public SignatureViewController () : base()
		{
			View.TranslatesAutoresizingMaskIntoConstraints = false;

			m_signatureView = new NICSignatureView(RectangleF.Empty, new EAGLContext(EAGLRenderingAPI.OpenGLES2));
			m_signatureView.TranslatesAutoresizingMaskIntoConstraints = false;
			m_signatureView.BackgroundColor = UIColor.White;

			View.AddSubview(m_signatureView);
		}

		public override void UpdateViewConstraints ()
		{
			base.UpdateViewConstraints ();

			if (m_didUpdateConstraints)
				return;

			m_didUpdateConstraints = true;

			// Signature Constraints
			{
				View.AddConstraint(NSLayoutConstraint.Create(
					m_signatureView,
					NSLayoutAttribute.Top,
					NSLayoutRelation.Equal,
					View,
					NSLayoutAttribute.Top,
					1.0f,
					0));

				View.AddConstraint(NSLayoutConstraint.Create(
					m_signatureView,
					NSLayoutAttribute.Leading,
					NSLayoutRelation.Equal,
					View,
					NSLayoutAttribute.Leading,
					1.0f,
					0));

				View.AddConstraint(NSLayoutConstraint.Create(
					m_signatureView,
					NSLayoutAttribute.Trailing,
					NSLayoutRelation.Equal,
					View,
					NSLayoutAttribute.Trailing,
					1.0f,
					0));

				View.AddConstraint(NSLayoutConstraint.Create(
					m_signatureView,
					NSLayoutAttribute.Bottom,
					NSLayoutRelation.Equal,
					View,
					NSLayoutAttribute.Bottom,
					1.0f,
					0));
			}
		}
	}
}

