using DocumentFormat.OpenXml.Presentation;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Speech.V1;
using Google.Cloud.Storage.V1;
using Grpc.Auth;
using GSF.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using static Google.Cloud.Speech.V1.RecognitionConfig.Types;

namespace DISTODMH2 { 

    class Program
    {
        
        public static void Main(string[] args)
        {
  
            string key = "disto-dmh";
            AuthImplicit(key);
            string jsonPath = @"C:\Users\di_eg\Desktop\Credenciales Google\key.json";
            RecognitionAudio audio = RecognitionAudio.FromFile(@"C:\Users\di_eg\Desktop\Ejemplos\output.flac");
           
            
            SpeechClientBuilder speechClientBuilder = new SpeechClientBuilder
            {
                CredentialsPath = jsonPath
            };
            SpeechClient cliente = speechClientBuilder.Build();

            RecognitionConfig config = new RecognitionConfig
            {
                Encoding = AudioEncoding.Flac,
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

            StreamingRecognitionResult streamingRes = new StreamingRecognitionResult()
            {
                
            };

            StreamingRecognizeResponse streamingResponse = new StreamingRecognizeResponse()
            {
                 
            };




            RecognizeResponse response = cliente.Recognize(config, audio);
            Console.WriteLine(response);







            //RecognizeResponse reconocimiento = cliente.StreamingRecognize
            //Console.WriteLine(reconocimiento);


            /*RecognitionConfig config = new RecognitionConfig
            {
                Encoding = AudioEncoding.Linear16,
                SampleRateHertz = 16000,
                LanguageCode = LanguageCodes.English.UnitedStates
            };
            RecognizeResponse response = client.Recognize(config, audio1);
            Console.WriteLine(response);*/
        }

      

        public static object AuthImplicit(string projectId)
        {
            // If you don't specify credentials when constructing the client, the
            // client library will look for credentials in the environment.
            var credential = GoogleCredential.GetApplicationDefault();
           
            var storage = StorageClient.Create(credential);
            // Make an authenticated API request.
            var buckets = storage.ListBuckets(projectId);
            Console.WriteLine("Entra");
            foreach (var bucket in buckets)
            {
                Console.WriteLine(bucket.Name);
            }
            return null;
        }
    }
}
