using UnityEngine;
using Gilzoide.ObjectiveC;
using System;

public class NSAlertMessage : MonoBehaviour
{
    public string Message;

    public void SetMessage(string message)
    {
        Message = message;
    }

    public void Alert()
    {
        Alert(Message);
    }

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
            Action<Id> callback = _block => Debug.Log("Called after alert completes");
            Block block = Block.FromDelegate(callback);
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
