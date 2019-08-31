using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Delegates 
// Agreement or Contract between Publisher and Subscriber
// Determines the signature of the event handler method in Subscriber

namespace EventAndDelegate
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }

    public class VideoEncoder
    {
        // Step 1 - Define a degelate
        // Step 2 - Define an event based on that delegate
        // Step 3 - Raise the event

        // Step 1
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

        // Step 2
        public event VideoEncodedEventHandler VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);

            // Step 3
            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs() { Video = video } );
        }
    }
}
