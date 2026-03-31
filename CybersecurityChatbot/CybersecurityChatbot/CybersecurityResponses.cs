using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class CybersecurityResponses
    {
        private Dictionary<string, string> responses;

        public CybersecurityResponses()
        {
            responses = new Dictionary<string, string>();
            InitializeResponses();
        }

        private void InitializeResponses()
        {
            // General questions
            responses.Add("how are you", "I'm doing great! Thanks for asking! I'm here to help you stay safe online. 😊");
            responses.Add("what's your purpose", "My purpose is to educate South African citizens about cybersecurity and help them stay safe online!");
            responses.Add("what can i ask you about", "You can ask me about passwords, phishing, safe browsing, or general cybersecurity tips!");

            // Password safety
            responses.Add("password", "🔐 PASSWORD SAFETY:\n• Use 12+ characters\n• Mix uppercase, lowercase, numbers, symbols\n• Don't reuse passwords\n• Use a password manager\n• Enable two-factor authentication!");
            responses.Add("password safety", "🔐 PASSWORD SAFETY:\n• Use 12+ characters\n• Mix uppercase, lowercase, numbers, symbols\n• Don't reuse passwords\n• Use a password manager\n• Enable two-factor authentication!");

            // Phishing
            responses.Add("phishing", "🎣 PHISHING WARNING!\nWatch out for:\n• Urgent emails\n• Suspicious links\n• Requests for personal info\n• Poor grammar\n• Unexpected attachments\n\nAlways verify before clicking!");
            responses.Add("phishing scam", "🎣 PHISHING WARNING!\nWatch out for:\n• Urgent emails\n• Suspicious links\n• Requests for personal info\n• Poor grammar\n• Unexpected attachments\n\nAlways verify before clicking!");

            // Safe browsing
            responses.Add("safe browsing", "🌐 SAFE BROWSING TIPS:\n• Look for 'https://' and padlock\n• Don't click suspicious pop-ups\n• Keep browser updated\n• Avoid public Wi-Fi for banking\n• Clear cookies regularly!");
            responses.Add("browsing", "🌐 SAFE BROWSING TIPS:\n• Look for 'https://' and padlock\n• Don't click suspicious pop-ups\n• Keep browser updated\n• Avoid public Wi-Fi for banking\n• Clear cookies regularly!");

            // Tips
            responses.Add("tip", "💡 CYBERSECURITY TIP:\nAlways think before you click! When in doubt, don't click the link.");
            responses.Add("tips", "💡 TOP TIPS:\n1. Strong passwords\n2. Two-factor authentication\n3. Update software\n4. Be email cautious\n5. Backup data!");
        }

        public string GetResponse(string userInput)
        {
            // Check for exact matches
            if (responses.ContainsKey(userInput))
                return responses[userInput];

            // Check for partial matches
            foreach (var key in responses.Keys)
            {
                if (userInput.Contains(key))
                    return responses[key];
            }

            return null; // No match
        }
    }
}