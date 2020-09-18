using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 * Key points for this example:
 *  - creating and starting Tasks
 *  - waiting on results
 *  - continue with
 */

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("dowload url...");
            int aantal = DownLoadLaatsteNieuws().Result;
            Console.WriteLine("Aantal bytes gedownload:{0}", aantal);
            Console.WriteLine("klaar");

            #region async calls to parallel tasks for booking...
            //Stopwatch sw = Stopwatch.StartNew();
            //Task<int> planeTask = new Task<int>(BookPlane); //Task.Factory.StartNew<int>(BookPlane);
            //Task<int> hotelTask = new Task<int>(BookHotel); //Task.Factory.StartNew<int>(BookHotel);
            //Task<int> carTask = new Task<int>(BookCar);     //Task.Factory.StartNew<int>(BookCar);

            //planeTask.Start(); hotelTask.Start(); carTask.Start();

            //Task hotelFollowUp = hotelTask.ContinueWith(taskPrev => Console.WriteLine("Regel aanvullende zaken voor hotel-booking:{0}", taskPrev.Result));
            //hotelFollowUp.Wait(); // onnodig!?

            //// Task.WaitAll(planeTask, hotelTask, carTask);
            //Console.WriteLine("Booking is klaar met planeId:{0}, hotelId:{1} en carId:{2}", planeTask.Result, hotelTask.Result, carTask.Result);
            //Console.WriteLine("Finished in {0} milliseconds", sw.ElapsedMilliseconds);

            #endregion
            #region Serial calls for booking...
            //Stopwatch sw = Stopwatch.StartNew();

            //int carId = BookCar();
            //int hotelId = BookHotel();
            //int planeId = BookPlane();

            //sw.Stop();


            #endregion
        }

        private static async Task<int> DownLoadLaatsteNieuws()
        {
            WebClient wc = new WebClient();
            string nu = await wc.DownloadStringTaskAsync("www.nu.nl");
            string trouw = await wc.DownloadStringTaskAsync("www.trouw.nl");

            Console.WriteLine("Totale lengte: {0}", nu.Length+trouw.Length);

            return nu.Length + trouw.Length;

        }

        static Random rand = new Random();

        private static int BookPlane()
        {
            Console.WriteLine("Booking plane...");
            Thread.Sleep(1000);
            Console.WriteLine("Done with plane!");
            return rand.Next(100);
        }

        private static int BookHotel()
        {
            Console.WriteLine("Booking hotel...");
            Thread.Sleep(200);
            Console.WriteLine("Done with hotel!");

            return rand.Next(1000, 2000);
        }

        private static int BookCar()
        {
            Console.WriteLine("Booking car...");
            Thread.Sleep(500);
            Console.WriteLine("Done with car!");
            return rand.Next(10000, 20000);
        }
    }
}
