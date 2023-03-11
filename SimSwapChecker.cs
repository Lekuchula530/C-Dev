using System;
using System.Net;

namespace SimSwapChecker
{
    class SimSwap
    {
        static void Main(string[] args)
        {
            // URL to check the SIM swap status
            string url = "MNOUrl";

            // Create a request object
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // Set the request method to POST
            request.Method = "POST";

            // Add the necessary headers
            request.Headers["Authorization"] = "Bearer <your_access_token>";
            request.ContentType = "application/json";

            // Add the request body
            string requestBody = "{ \"msisdn\": \"<phone_number>\", \"iccid\": \"<sim_card_number>\" }";
            byte[] requestBodyBytes = System.Text.Encoding.UTF8.GetBytes(requestBody);
            request.ContentLength = requestBodyBytes.Length;

            using (var streamWriter = request.GetRequestStream())
            {
                streamWriter.Write(requestBodyBytes, 0, requestBodyBytes.Length);
            }

            // Send the request and get the response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Read the response body
            string responseBody = string.Empty;
            using (var streamReader = new System.IO.StreamReader(response.GetResponseStream()))
            {
                responseBody = streamReader.ReadToEnd();
            }

            // Display the response
            Console.WriteLine(responseBody);
        }
    }
}



In this code, you need to replace <your_access_token> with your actual access token and <phone_number> and <sim_card_number> with the phone number and SIM card number you want to check, respectively. You also need to replace the url variable with the actual URL of the mobile network operator's SIM swap checker API.