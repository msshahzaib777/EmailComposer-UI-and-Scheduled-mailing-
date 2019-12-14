using System.ServiceProcess;

namespace k163810_Q3
{
    static class Program
    {
        static void Main()
        {

#if DEBUG
            EmailSender es = new EmailSender();
            es.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new EmailSender()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
