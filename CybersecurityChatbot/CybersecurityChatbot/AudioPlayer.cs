using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CybersecurityChatbot
{
    public class AudioPlayer
    {
        public AudioPlayer() { }

        public void PlayGreeting()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string[] candidates = new[]
                {
                    Path.Combine(baseDir, "greeting.wav"),
                    Path.Combine(baseDir, "resources", "greeting.wav"),
                    Path.Combine(baseDir, "Resources", "greeting.wav")
                };

                string? audioPath = null;
                foreach (var c in candidates)
                {
                    if (File.Exists(c))
                    {
                        audioPath = c;
                        break;
                    }
                }

                if (string.IsNullOrEmpty(audioPath))
                {
                    ConsoleFormatter.WriteWarning("⚠ greeting.wav not found in output. Make sure resources\\greeting.wav is included in the project and copied to output.");
                    return;
                }

                ConsoleFormatter.WriteInfo($"Found audio at: {audioPath}");
                ConsoleFormatter.WriteInfo($"OS: {RuntimeInformation.OSDescription}");

                // Windows: use PowerShell to play WAV synchronously (avoids adding Windows-only packages)
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    string psCmd = $"(New-Object Media.SoundPlayer \"{audioPath}\").PlaySync()";
                    if (TryPlayWithCommand("powershell", $"-NoProfile -Command \"{psCmd}\""))
                    {
                        ConsoleFormatter.WriteSuccess("✓ Voice greeting played!");
                        return;
                    }
                }

                // macOS
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    if (TryPlayWithCommand("afplay", $"\"{audioPath}\""))
                    {
                        ConsoleFormatter.WriteSuccess("✓ Voice greeting played!");
                        return;
                    }
                }

                // Linux
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    string[] linuxPlayers = { "aplay", "paplay", "ffplay -nodisp -autoexit", "play" };
                    foreach (var cmd in linuxPlayers)
                    {
                        var parts = cmd.Split(new[] { ' ' }, 2);
                        var command = parts[0];
                        var args = parts.Length > 1 ? parts[1] + " \"" + audioPath + "\"" : "\"" + audioPath + "\"";

                        if (TryPlayWithCommand(command, args))
                        {
                            ConsoleFormatter.WriteSuccess("✓ Voice greeting played!");
                            return;
                        }
                    }
                }

                // Fallback: try to open with default app
                if (TryOpenWithShell(audioPath))
                {
                    ConsoleFormatter.WriteSuccess("✓ Voice greeting opened with default app.");
                    return;
                }

                ConsoleFormatter.WriteWarning("⚠ Could not play audio on this platform.");
            }
            catch (Exception ex)
            {
                ConsoleFormatter.WriteError($"⚠ Could not play audio: {ex.Message}");
            }
        }

        private static bool TryPlayWithCommand(string command, string arguments)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = command,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                };

                using (var p = Process.Start(psi))
                {
                    if (p == null) return false;
                    if (!p.WaitForExit(8000))
                    {
                        try { p.Kill(); } catch { }
                        return false;
                    }
                    return p.ExitCode == 0;
                }
            }
            catch
            {
                return false;
            }
        }

        private static bool TryOpenWithShell(string path)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true,
                };
                using (var p = Process.Start(psi))
                {
                    return p != null;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}