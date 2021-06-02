using DocumentFormat.OpenXml.Presentation;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Speech.V1;
using Google.Cloud.Storage.V1;
using Grpc.Auth;
using GSF.IO;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using static Google.Cloud.Speech.V1.RecognitionConfig.Types;

using Google.Cloud.TextToSpeech.V1;
using Newtonsoft.Json;
using WMPLib;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace DISTODMH2 {

    class Program
    {

        public static void Main(string[] args)
        {

            //string key = "disto-dmh";
            //AuthImplicit(key);
            string jsonPath = @"C:\Users\di_eg\Desktop\Credenciales Google\key.json";
            string jsonPathTextSpeech = @"C:\Users\di_eg\Desktop\Credenciales Google\keyTextToSpeech\key.json";
            RecognitionAudio audio = RecognitionAudio.FromFile(@"C:\Users\di_eg\Desktop\Ejemplos\output.flac");
            var credencial = GoogleCredential.FromStream(File.OpenRead(jsonPathTextSpeech));
            var json = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(jsonPathTextSpeech));

            
            TextToSpeechClientBuilder textToSpeechClientBuilder = new TextToSpeechClientBuilder()
            {
                CredentialsPath = jsonPathTextSpeech
            };
            var cliente2 = textToSpeechClientBuilder.Build();


            var input = new SynthesisInput
            {
                Text = "El perro estaba corriendo en la plaza"
            };
            // Build the voice request.
            var voiceSelection = new VoiceSelectionParams
            {
                LanguageCode = "es-ES",
                SsmlGender = SsmlVoiceGender.Female
            };
            // Specify the type of audio file.
            var audioConfig = new AudioConfig
            {
                AudioEncoding = Google.Cloud.TextToSpeech.V1.AudioEncoding.Linear16
            };

            // Perform the text-to-speech request.
            var response2 = cliente2.SynthesizeSpeech(input, voiceSelection, audioConfig);
            using (var output = File.Create("output.wav"))
            {
                response2.AudioContent.WriteTo(output);
            }

            Console.WriteLine("Audio content written to file \"output.wav\"");
            

            //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            
            //player.SoundLocation = @"C:\Users\di_eg\source\repos\DISTODMH2\DISTODMH2\bin\Debug\netcoreapp3.1\output.wav";
            //player.Play();


        }
            
            
            
            //Thread thr = new Thread(new ThreadStart(metodo));
            //thr.Start();





            /*
            SpeechClientBuilder speechClientBuilder = new SpeechClientBuilder
            {
                CredentialsPath = jsonPath
            };
            SpeechClient cliente = speechClientBuilder.Build();

            RecognitionConfig config = new RecognitionConfig
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Flac,
                SampleRateHertz = 48000,
                LanguageCode = LanguageCodes.Spanish.Chile
            };
            

            StreamingRecognitionConfig streamingConf = new StreamingRecognitionConfig()
            {
                Config = config,
                SingleUtterance = true
            };
            StreamingRecognizeRequest streamingReq = new StreamingRecognizeRequest()
            {
                StreamingConfig = streamingConf,
            };
            //Stream stream = null;
            //ecognitionAudio.FromStream(stream);
            StreamingRecognitionResult streamingRes = new StreamingRecognitionResult()
            {
                
            };
          

            StreamingRecognizeResponse streamingResponse = new StreamingRecognizeResponse()
            {
                 
            };

            RecognitionMetadata recognitionMetadata = new RecognitionMetadata()
            {

            };

            


            RecognizeResponse response = cliente.Recognize(config, audio);
            Console.WriteLine(response);

            */





            //RecognizeResponse reconocimiento = cliente.StreamingRecognize
            //Console.WriteLine(reconocimiento);
            /*

            RecognitionConfig config = new RecognitionConfig
            {
                Encoding = AudioEncoding.Linear16,
                SampleRateHertz = 16000,
                LanguageCode = LanguageCodes.English.UnitedStates
            };
            RecognizeResponse response = client.Recognize(config, audio1);
            Console.WriteLine(response);
        }
*/

    }
}
