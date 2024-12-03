using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ProxyChatWriter
{
    private Process proxyProcess;
    private string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "pipe.exe");
    private StreamWriter proxyInputWriter;
    private readonly SemaphoreSlim _writeSemaphore = new SemaphoreSlim(1, 1);

    public async Task LaunchProxyChat()
    {
        try
        {
            proxyProcess = new Process();
            proxyProcess.StartInfo.FileName = filePath;
            proxyProcess.StartInfo.RedirectStandardInput = true;
            proxyProcess.StartInfo.RedirectStandardOutput = true;
            proxyProcess.StartInfo.UseShellExecute = false;
            proxyProcess.StartInfo.CreateNoWindow = true;

            proxyProcess.Start();

            proxyInputWriter = proxyProcess.StandardInput;

            await WriteToProxy("Proxy Chat Initialized. Move this to your second monitor.");
        }
        catch (System.Exception ex)
        {
            UnityEngine.Debug.LogException(ex);
        }
    }

    public async Task WriteToProxy(string message)
    {
        await _writeSemaphore.WaitAsync();
        try
        {
            if (proxyInputWriter != null && proxyInputWriter.BaseStream.CanWrite)
            {
                await proxyInputWriter.WriteLineAsync(message);
                await proxyInputWriter.FlushAsync();
            }
        }
        catch (System.Exception ex)
        {
            UnityEngine.Debug.LogError($"Failed to write to proxy: {ex.Message}");
        }
        finally
        {
            _writeSemaphore.Release();
        }
    }
}
