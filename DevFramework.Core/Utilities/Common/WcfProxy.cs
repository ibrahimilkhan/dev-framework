using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Utilities.Common
{
    public class WcfProxy<T>
    {
        // Clientımızın (MVC, WPF, Consoleun) ulasacagi nesnenin ait oldugu sinif.
        public static T CreateChannel()
        {
            // Bir clientın herhangi bir servise ulasabilmesi icin servisin üc harfine ihtiyacı var.
            //A => Address B => Binding C => Contrat

            //Address => MVC'nin webconfiginden okuyacagiz.
            string baseAddress = ConfigurationManager.AppSettings["ServiceAddress"];
            string address = string.Format(baseAddress, typeof(T).Name.Substring(1));

            // Binding
            var binding = new BasicHttpBinding();

            var channel = new ChannelFactory<T>(binding, address);

            return channel.CreateChannel();
        }
    }
}
