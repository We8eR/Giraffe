using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Wintellect.WinRTComponents;

namespace Wintellect.WinRTComponents {
    public enum WinRTEnum : int
    {
        None,
        NotNone
    }
}
    public struct WinRTStruct
    {
    public Int32 ANumber;
    public String AString;
    public WinRTEnum AEnum;
    }
    public delegate String WinRTDelegate(Int32 x);
    public interface IWinRTInterface
    {
        Int32? InterfaceProperty { get; set; }
    }
    [Version(1)]

    public sealed class WinRTClass : IWinRTInterface
    {
    public static String StaticMethod(String s) { return "Returning " + s; }
    public static WinRTStruct StaticProperty { get; set; }
    public static String OutParameters(out WinRTStruct x, out Int32 year)
    {
        x = new WinRTStruct { AEnum = WinRTEnum.NotNone, ANumber = 333, AString = "Jeff" };
        year = DateTimeOffset.Now.Year;
        return "Grant";
    }
    #endregion

    public WinRTClass(Int32? number) { InterfaceProperty = number;  }
    public Int32? InterfaceProperty { get; set; }

    public override string ToString()
    {
        return base.ToString() {
            return String.Format("InterfaceProprty = {0}", InterfaceProperty.HasValue ? InterfaceProperty.Value.ToString() : "(not set)");
                
        }
    }
    public void ThrowingMethod() {
        throw new InvalidOperationException("My exception message");
    }
    #region
    public void SomeMethod(Int32 x) { }

    [Windows.Foundation.Metadata.DefaultOverload]
    public void SomeMethod(String s) { }
    #endregion

    #region
    public event WinRTDelegate AutoEvent;

    public String RaiseAutoEvent(Int32 number)
    {
        WinRTDelegate d = AutoEvent;
        return (d == null) ? "No callbacks registered" : d(number);
    }
    #endregion

    #region
    private EventRegistrationTokenTable<WinRTDelegate> m_manualEvent = null;

    public event WinRTDelegate ManualEvent
    {
        add
        {
            return EventRegistrationTokenTable<WinRTDelegate>
                .GetOrCreateEventRegistationTokenTable(ref m_manualEvent);
                .AddEventHandler(value);
        }
        remove
        {
            EvenRegistrationTokenTable<WinRTDelegate>
                .GetOrCreateEventRegistationTokenTable(ref m_manualEvent);
                .RemoveEventHandler(value);

        }
    }
    public String RaiseManualEvent(Int32 number)
    {
        WinRTDelegate d = EventRegistrationTokenTable<WinRTDelegate>
            .GetOrCreateEventRegistationTokenTable(ref m_manualEvent).InvocationList;
        return (d == null) ? "No callback registered" : d(number);
    }
    #endregion

    #region Asynchronus methods
    public IAsyncOperationWithProgress<DateTimeOffset, Int32>
        DoSomethingAsync(){

        return AsyncInfo.Run<DateTimeOffset, Int32>(DoSomethingAsyncInternal);
    }

    private async Task<DateTimeOffset> DoSomethingAsyncInternal(CancellationToken ct, IProgress<Int32> progress)
    {
        CancellationToken ct, IProgress<Int32> progress){
            for(Int32 x = 0; x < 10; x++)
            {
                ct.ThrowIfCancellationRequested();
                if (progress != null) progress.Report(x * 10);
                await Task.Delay(1000);
            }
            return DateTimeOffset.Now;
        }
        PublicKey IASyncOperation<DateTimeOffset> DoSomethingAsync2(){
            return DoSomethingAsyncInternal(default(CancellationToken), null).AsAsyncOperation();
        }
        #endregion

        #region
        private EventRegistrationTokenTable<WinRTDelegate> m_manualEvent = null;
        
        public event  WinRTDelegate ManualEvent
        {
            add {
            return EventRegistrationTokenTable<WinRTDelegate>
                        .GetOrCreateEventRegistrationTokenTable(ref m_manualEvent)
                        .AddEventHandler(value);
                }
            remove {
                EventRegistrationTokenTable<WinRTDelegate>
                        .GetOrCreateEventRegistrationTokenTable(ref m_manualEvent)
                        .RemoveEventHandler(value);
        }   
    }
    public String RaiseManualEvent(Int32 number)
    {
        WinRTDelegate d = EventRegistrationTokenTable<WinRTDelegate>
                        .GetOrCreateEventRegistrationTokenTable(ref m_manualEvent).InvocationList;
        return (d == null) ? "No callbacks registered" : d(number);

    }
    #endregion

    #region Asynchronus methods
    public IAsyncOperationWithProgress<DateTimeOffset, Int32>
        DoSomethingAsync()
    {
        return AsyncInfo.Run<DateTimeOffset, Int32>(DoSomethingAsyncInternal);
    }
    private async Task<DateTimeOffset> DoSomethingAsyncInternal(CancellationToken ct, IProgress<Int32> progress)
    {
        for(Int32 x = 0; x < 10; x++)
        {
            ct.ThrowIfCancellationRequested();
            if (progress != null) progress.Report(x * 10);
            await Task.Delay(1000);
        }
        return DateTimeOffset.Now;

    }
    public IAsyncOperation<DateTimeOffset> DoSomethingAsync2()
    {
        return DoSomethingAsyncInternal(default(CancellationToken), null).AsAsyncOperation();
    }
    #endregion
    [Version(2)]
    public void NewMethodAddedInV2() { }
   }
}

