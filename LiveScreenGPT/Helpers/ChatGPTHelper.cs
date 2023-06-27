using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Data;
using System.Reflection.Metadata;
using System.Net.Http.Json;

namespace LiveScreenGPT.Helpers
{
    public class ChatGPTHelper
    {
        private readonly HttpClient httpClient;
        private readonly string chatGptApiKey;

        public ChatGPTHelper()
        {
            this.httpClient = new HttpClient();
            this.chatGptApiKey = Properties.Settings.Default.GPTKey;
        }

        public async Task<string> GenerateChatGptResponse(string inputText, string job)
        {
            string apiUrl = "https://api.openai.com/v1/chat/completions";
            string model = "gpt-3.5-turbo"; // or specify the desired model

            var requestData = new
            {
                model = model,
                temperature = 0,
                messages = new[]
                {
                    new
                    {
                        role = "system",
                        content =  job
                    },
                    new
                    {
                        role = "assistant",
                        content =  job
                    },
                    new
                    {
                        role = "user",
                        content = inputText
                    },

                }
            };

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {chatGptApiKey}");

            var response = await httpClient.PostAsJsonAsync(apiUrl, requestData);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ChatGptResponse>(responseContent);
            return responseData.choices[0].message.content.Trim();
        }

    }

    public class ChatGptResponse
    {
        public ChatGptChoice[] choices { get; set; }
    }

    public class ChatGptChoice
    {
        public string index { get; set; }
        public ChatGptMessage message { get; set; }
        public string finish_reason { get; set; }
    }

    public class ChatGptMessage
    {
        public string role { get; set; }
        public string content { get; set; }
    }
}
