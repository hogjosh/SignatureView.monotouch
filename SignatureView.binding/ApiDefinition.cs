using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.GLKit;
using MonoTouch.OpenGLES;

namespace SignatureView
{
	[BaseType (typeof (GLKView))]
	public partial interface NICSignatureView 
	{ 
		[Export("initWithFrame:context:")]
		IntPtr Constructor (RectangleF frame, EAGLContext context);

		[Export ("hasSignature")]
		bool HasSignature { get; set; }

		[Export ("signatureImage", ArgumentSemantic.Retain)]
		UIImage SignatureImage { get; set; }

		[Export ("erase")]
		void Erase ();
	}

	[BaseType (typeof (UIView))]
	public partial interface NICSignatureViewQuartzQuadratic
	{
		[Export("initWithFrame:")]
		IntPtr Constructor (RectangleF frame);

		[Export ("erase")]
		void Erase (); 
	}

	[BaseType (typeof (UIView))]
	public partial interface NICSignatureViewQuartz 
	{
		[Export("initWithFrame:")]
		IntPtr Constructor (RectangleF frame);

		[Export ("erase")]
		void Erase ();
	}
}

