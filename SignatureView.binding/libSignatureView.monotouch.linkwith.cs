using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libSignatureView.monotouch.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true, Frameworks = "QuartzCore GLKit OpenGLES CoreGraphics")]
