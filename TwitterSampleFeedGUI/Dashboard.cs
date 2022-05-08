using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jasonphos.SharedUtil.Data;
using Jasonphos.TwitterSampleFeedLogic;

namespace Jasonphos.TwitterSampleFeedGUI {

    public partial class Dashboard:Form {
        private SampleFeedProcessor _processor;

        System.Windows.Forms.Timer? timerStartProcessor;
        System.Windows.Forms.Timer? timerUpdateView;

        bool isProcessorStarted=false;
        public Dashboard(ConfigData configData) {
            InitializeComponent();
            this.Load += new EventHandler(frmDashboard_Load);
            _processor = new SampleFeedProcessor(new SampleFeedAppData(configData));
        }

        private void frmDashboard_Load(object? sender, EventArgs e) {
            timerStartProcessor = new System.Windows.Forms.Timer {
                Interval = 250 //just giving some time before we start the process, not sure amount even matters, could re-evaluate in future: 1ms might be fine.
            };
            timerStartProcessor.Tick += new EventHandler(timerTick_StartProcessor);
            timerStartProcessor.Start();

            int refreshPeriod = (int) (Double.Parse(_processor._ApplicationData.Config.GetValue("cfg_FormRefreshPeriodInSeconds")) * 1000);

            timerUpdateView = new System.Windows.Forms.Timer {
                Interval = refreshPeriod
            };
            timerUpdateView.Tick += new EventHandler(timerTick_UpdateView);
            timerUpdateView.Start();
        }

        /// <summary>
        /// This is only used to start the threads that do the work.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerTick_StartProcessor(object? sender, EventArgs e) {
            if (_processor._ApplicationData.IsStarted == false && isProcessorStarted == false) {

                int numberThreads = _processor._ApplicationData.ProcessorThreadCount;
                Task.Run(async () => { //Can only do a single receive Thread, since StreamReader is not threadsafe! I think that should be fine for any program that reads the Twitter Sample Stream API
                    await _processor.StartReceivingAsync();
                });
                
                for(int i = 0; i < numberThreads; i++) { //I also am using semaphoreslim to set the maximum number of threads, based upon some async examples I read. One of the two might not be needed, I'm not certain, but even if semaphoreslim isn't strictly needed, I don't think it causes any harm and in fact it could be useful to throttle up and down the number of threads, if we ever wanted to do that.
                    int threadNumber = i + 1;
                    Task.Run(async () => {
                        await _processor.StartProcessingAsync(threadNumber);
                    });
                }
                isProcessorStarted = true;
            }
#pragma warning disable CS8602 // /Warning Disabled by JasonFoster on 5/5/2022. Cannot be null because only timerStartProcessor has a reference to this method, therefore timerStartProcessor is not null inside this method.
            //timerStartProcessor.Stop();
#pragma warning restore CS8602
        }

        private async void timerTick_UpdateView(object? sender,EventArgs e) {
            SampleFeedAppData appData = _processor._ApplicationData;
            if (appData.IsRunning == false && appData.IsStarted && isProcessorStarted == true) {
                //Note: Ideally we should use the CancellationToken pattern here, but for now I am writing a simpler version
                //where we have an "IsRunning" volatile boolean that all the processes are using to indicate that the process should stop.
                //Consider this blog post: https://johnthiriet.com/efficient-api-calls/
                isProcessorStarted = false;
                txtEndTimestamp.Text = determineCurrentDateTime();
                await Task.Delay(2000); //Give the Process some time to finish up. Not sure the ideal value here. Could make it configurable in the future. Also, this would be made unnecessary if we changed to a CancellationToken
                
            }
            txtCurrentDateTime.Text = determineCurrentDateTime();
            txtTotalTweetsReceived.Text = appData.TweetsReceivedCount.ToString();
            txtTotalTweetsProcessed.Text = appData.TweetsProcessedCount.ToString();
            txtTweetsReceivedPerMin.Text = appData.TweetsReceivedPerMin.ToString();
            txtStartTimestamp.Text = appData.StartProcessTimestamp.ToString();
            txtEndTimestamp.Text = appData.EndProcessingTimestamp.ToString();
            txtLastReceivedTimestamp.Text = appData.LastReceivedDateTime.ToString();
            txtLog.Text = appData.LogMessages;
            if(appData.LastReceivedDateTime == null)
                txtLastReceivedTimestamp.Text = "";
            else 
                txtLastReceivedTimestamp.Text = ((DateTime)appData.LastReceivedDateTime).ToString("MM/dd HH:mm:ss");
        }
        private String determineCurrentDateTime() {
            return DateTime.Now.ToString("MM/dd HH:mm:ss");
        }
    }
}
