using Android.App;
using Android.OS;
using Android.Speech.Tts;
using GreatQuotes.Services;

// Note: this class requires at least Android SDK 5.0 (Lollypop)
// to build due to changes in the TTS APIs.

namespace GreatQuotes.Droid.Services
{
    public class TextToSpeechService : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        private string lastText;
        private TextToSpeech speech;

        public void OnInit(OperationResult status)
        {
            if (status == OperationResult.Success)
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                    speech.Speak(lastText, QueueMode.Flush, null, null);
                else
                {
#pragma warning disable 0618
                    speech.Speak(lastText, QueueMode.Flush, null);
#pragma warning restore 0618
                }
                lastText = null;
            }
        }

        public void Speak(string text)
        {
            if (speech == null)
            {
                lastText = text;
                speech = new TextToSpeech(Application.Context, this);
            }
            else
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                    speech.Speak(text, QueueMode.Flush, null, null);
                else
                {
#pragma warning disable 0618
                    speech.Speak(text, QueueMode.Flush, null);
#pragma warning restore 0618
                }
            }
        }
    }
}