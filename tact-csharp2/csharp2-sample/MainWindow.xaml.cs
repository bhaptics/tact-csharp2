using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using tact_csharp2;

namespace csharp2_sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _appId;
        private string _sdkKey;
        private int _requestId;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Sdk_init(object sender, RoutedEventArgs e)
        {
            _appId = this.appId.Text;
            _sdkKey = this.sdkKey.Text;
         
            BhapticsSDK2Wrapper.registryAndInit(_sdkKey, _appId, "");
        }

        private void Sdk_load_event(object sender, RoutedEventArgs e)
        {
            var res = BhapticsSDK2Wrapper.bHapticsGetHapticMappings(_sdkKey, _appId, -1, out var status);
            var msg = PtrToStringUtf8(res);
            Debug.WriteLine(msg);
            Debug.WriteLine(status);

            var apiResult = JsonConvert.DeserializeObject<ApiResponse<List<MappingMetaData>>>(msg);
            var eventList = apiResult.Message;
            Debug.WriteLine(eventList.Count);
            this.event_list.ItemsSource = eventList.Select(x => x.Key);
        }

        private static string PtrToStringUtf8(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                return "";
            }

            var len = 0;
            while (Marshal.ReadByte(ptr, len) != 0)
                len++;
            if (len == 0)
            {
                return "";
            }

            var array = new byte[len];
            Marshal.Copy(ptr, array, 0, len);
            return System.Text.Encoding.UTF8.GetString(array);
        }

        private void Sdk_play(object sender, RoutedEventArgs e)
        {
            if (this.event_list.SelectedValue is string eventName)
            {
                _requestId = BhapticsSDK2Wrapper.play(eventName);
            }
        }

        private void Sdk_stop(object sender, RoutedEventArgs e)
        {
            BhapticsSDK2Wrapper.stop(_requestId);
        }

        private void Sdk_stop_all(object sender, RoutedEventArgs e)
        {
            BhapticsSDK2Wrapper.stopAll();
        }
    }
    public class MappingMetaData
    {
        public int DurationMillis { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public bool IsAudio { get; set; }
        public long UpdateTime { get; set; }
        public string[] Positions { get; set; }
    }

    public class ApiResponse<T>
    {
        public string Status { get; set; }
        public T Message { get; set; }
    }
}
