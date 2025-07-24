using Azure.Identity;
using Microsoft.Graph.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garry_Net
{
    public class GarryMeetingJoiner
    {
        private readonly IConfiguration _config;

        public GarryMeetingJoiner(IConfiguration config)
        {
            _config = config;
        }

        public async Task RunAsync()
        {
            var appSettings = _config.Get<AppSettings>();

            var credential = new ClientSecretCredential(
                appSettings.AzureAd.TenantId,
                appSettings.AzureAd.ClientId,
                appSettings.AzureAd.ClientSecret
            );


            var graphClient = new Microsoft.Graph.GraphServiceClient(credential, new[] { "https://graph.microsoft.com/.default" });

            var joinMeetingId = "4934932038258";
            var passcode = "9Hw9vS7q";

            var meetingInfo = new JoinMeetingIdMeetingInfo
            {
                JoinMeetingId = joinMeetingId,
                Passcode = string.IsNullOrWhiteSpace(passcode) ? null : passcode
            };

            var mediaConfig = new ServiceHostedMediaConfig();

            var call = new Call
            {
                CallbackUri = appSettings.Bot.CallbackUrl,
                Source = new ParticipantInfo
                {
                    Identity = new IdentitySet
                    {
                        Application = new Identity
                        {
                            Id = appSettings.AzureAd.ClientId,
                            DisplayName= "project-garry"
                        }
                    }
                },
                TenantId = appSettings.AzureAd.TenantId,
                RequestedModalities = new List<Modality?> { Modality.Audio},
                MediaConfig = mediaConfig,
                MeetingInfo = meetingInfo
            };

            var response = await graphClient.Communications.Calls.PostAsync(call);

            Console.WriteLine($"✅ Garry joined the meeting. Call ID: {response?.Id}");
        }
    }
}
