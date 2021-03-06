using System;
using System.Maui.Xaml.Internals;
using System.Maui.Internals;
#if __MOBILE__
using UIKit;

[assembly: System.Maui.Dependency(typeof(System.Maui.Platform.iOS.NativeValueConverterService))]
namespace System.Maui.Platform.iOS
#else
using UIView = AppKit.NSView;

[assembly: System.Maui.Dependency(typeof(System.Maui.Platform.MacOS.NativeValueConverterService))]

namespace System.Maui.Platform.MacOS
#endif
{
	[Preserve(AllMembers = true)]
	class NativeValueConverterService : INativeValueConverterService
	{
		public bool ConvertTo(object value, Type toType, out object nativeValue)
		{
			nativeValue = null;
			if (typeof(UIView).IsInstanceOfType(value) && toType.IsAssignableFrom(typeof(View)))
			{
				nativeValue = ((UIView)value).ToView();
				return true;
			}
			return false;
		}
	}
}