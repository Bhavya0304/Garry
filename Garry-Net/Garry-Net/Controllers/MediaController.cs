using Microsoft.Skype.Bots.Media;
using System;

public class AudioSocketHandler
{
    public AudioSocketHandler(AudioSocket socket)
    {
        socket.AudioMediaReceived += OnAudioMediaReceived;
    }

    private void OnAudioMediaReceived(object sender, AudioMediaReceivedEventArgs e)
    {
        var buffer = e.Buffer;
        Console.WriteLine($"📥 Received audio stream of {buffer.Length} bytes");
        // TODO: Send to Speech-to-Text service
    }
}