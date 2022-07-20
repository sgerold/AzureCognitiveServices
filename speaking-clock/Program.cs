using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System;
using System.Threading.Tasks;

namespace speaking_clock
{
    class Program
    {

            private static SpeechConfig speechConfig;
            static async Task Main(string[] args)
            {
                try
                {

                string cogSvcKey = "xxxxxxxxxxxxxxxxxxxxxxxxxxb793";
                string cogSvcRegion = "southcentralus";

                    // Configure speech service
                    speechConfig = SpeechConfig.FromSubscription(cogSvcKey, cogSvcRegion);
                    Console.WriteLine("Ready to use speech service in " + speechConfig.Region);

                    // Configure voice
                    speechConfig.SpeechSynthesisVoiceName = "en-US-AriaNeural";


                    // Get spoken input
                    string command = "";
                    command = TranscribeCommand();
                    if (command.ToLower() == "what time is it?")
                     {
                        await TellTime();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            static  string TranscribeCommand()
            {
                string command = "";

                // Configure speech recognition
                speechConfig.SpeechRecognitionLanguage = "en-US";

                using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
                using var speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);

                Console.WriteLine("Speak into your microphone.");
                var speechRecognitionResult = speechRecognizer.RecognizeOnceAsync().Result;


                switch (speechRecognitionResult.Reason)
                {
                    case ResultReason.RecognizedSpeech:
                       return speechRecognitionResult.Text;
                        break;

                default:
                    return "";
                    break;
                }
            }

            static async Task TellTime()
            {
                var now = DateTime.Now;
                string responseText = "The time is " + now.Hour.ToString() + ":" + now.Minute.ToString("D2");

                // Configure speech synthesis


                // Synthesize spoken output


                // Print the response
                Console.WriteLine(responseText);
            }


    }
}
