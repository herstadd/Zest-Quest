using System;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

/// <summary>
/// Text Extension to enable causing click events on Image Buttons
/// </summary>
public static class ImageButtonExtensions
{
    /// <summary>
    /// Perform the Click Action
    /// </summary>
    /// <param name="sourceButton"></param>
    public static void PerformClick(this ImageButton sourceButton)
    {
        // Check parameters
        if (sourceButton == null)
        {
            return;
        }

        // 1.) Raise the Click-event
        sourceButton.RaiseEventViaReflection(nameof(sourceButton.Clicked), EventArgs.Empty);

        //// 2.) Execute the command, if bound and can be executed
        //ICommand boundCommand = sourceButton.Command;
        //if (boundCommand != null)
        //{
        //    object parameter = sourceButton.CommandParameter;
        //    if (boundCommand.CanExecute(parameter) == true)
        //    {
        //        boundCommand.Execute(parameter);
        //    }
        //}
    }

    /// <summary>
    /// Use Refelction to get the Event so it can be invoked
    /// </summary>
    /// <typeparam name="TEventArgs"></typeparam>
    /// <param name="source"></param>
    /// <param name="eventName"></param>
    /// <param name="eventArgs"></param>
    private static void RaiseEventViaReflection<TEventArgs>(this object source, string eventName, TEventArgs eventArgs) where TEventArgs : EventArgs
    {
        var eventDelegate = (MulticastDelegate)source.GetType().GetField(eventName, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(source);
        if (eventDelegate == null)
        {
            return;
        }

        foreach (var handler in eventDelegate.GetInvocationList())
        {
            handler.GetMethodInfo().Invoke(handler.Target, new object[] { source, eventArgs });
            // handler.GetMethodInfo()?.Invoke(handler.Target, new object[] { source, eventArgs });
        }
    }
}