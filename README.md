# Objective-C for Unity
High level C# to Objective-C interface, similar to Unity's [AndroidJavaClass](https://docs.unity3d.com/ScriptReference/AndroidJavaClass.html) and [AndroidJavaObject](https://docs.unity3d.com/ScriptReference/AndroidJavaObject.html).

**WARNING**: this is highly experimental and unsafe, misusage may easily crash the Unity editor or built games!
Use at your own risk.

**Note**: You have to manage memory on your own, since Automatic Reference Couting (ARC) in Objective-C is a compiler feature and we are not calling the compiler here.
This plugin offers some `IDisposable` structures to facilitate this, like `StrongReference` (calls `Release` when disposed) and `DisposablePinnedObject` (pins objects with `GCHandle`, calls `Free` on the handle when disposed).
You are responsible for releasing objects you own, as well as knowing which objects are `autorelease`d and should not be `release`d again.


## Samples
This UPM package has 2 samples:
- [macOS NSAlert](Samples~/macOS-NSAlert): Sample code that presents a native macOS alert
- [iOS UIFeedbackGenerator](Samples~/iOS-UIFeedbackGenerator): Sample code that plays haptics using UIImpactFeedbackGenerator on iOS


## Usage example
```cs
using System;
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
using Gilzoide.ObjectiveC;
using Gilzoide.ObjectiveC.Foundation;
#endif
using UnityEngine;

public static class NSAlertMessage
{
  private static Action<Id> _onAlertDismissedAction;

  public static void Alert(string message)
  {
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX  // || UNITY_IOS (NSAlert is not support in iOS)
    // Get existing Objective-C classes using `new Class("...")`
    Class NSApplication = new Class("NSApplication");
    // Use `Call` to send messages to an Id or Class using selectors
    // Selectors must match exactly with the definition, including the `:` characters
    // When returning values, you MUST pass a type with the right size or the application may crash
    // `Id` is like Objective-C's `id` type, a dynamic object that can receive messages
    Id sharedApplication = NSApplication.Call<Id>("sharedApplication");
    // `Get` is just a wrapper over `Call` for the getter selector
    Id keyWindow = sharedApplication.Get<Id>("keyWindow");

    Class NSAlert = new Class("NSAlert");
    // Instantiate objects with `Alloc(initSelector)` (in Objective-C idiom: `[[Class alloc] init]`)
    // The return is a StrongReference, a disposable version of `Id` that calls `Release` on Dispose
    using (StrongReference alert = NSAlert.Alloc("init"))
    {
      // Constructors for basic Foundation classes (currently NSString and NSNumber) are available
      // `+ [NSString stringWith*]` methods return an autoreleased NSString, no need to `Release`
      AutoreleasedReference<NSString> objcMessage = NSString.StringWith(message);

      // `Set` is just a wrapper over `Call` for the setter selector
      alert.Set("messageText", objcMessage);

      // Create Objective-C blocks from C# Delegates using `Block.FromDelegate`
      // Delegates MUST receive the block as first parameter (e.g. with `Id` type), as per block ABI
      // You are responsible for maintaining the Delegate alive when the block is called
      // The simplest way is to maintain the Delegate in a static or instance field
      _onAlertDismissedAction = _block => Debug.Log($"Alerted with message: '{message}'");
      Block block = Block.FromDelegate(_onAlertDismissedAction);
      // Blocks are passed by reference in Objective-C, so we need to get its address first
      // `DisposablePinnedObject` is a disposable wrapper over `GCHandle`
      using (DisposablePinnedObject pinnedBlock = new DisposablePinnedObject(block))
      {
        IntPtr blockByReference = pinnedBlock.Address;

        // You can pass any number of struct values as parameters
        alert.Call("beginSheetModalForWindow:completionHandler:", keyWindow, blockByReference);
      }
    }
#else
    Debug.Log("Unsupported platform");
#endif
  }
}
```