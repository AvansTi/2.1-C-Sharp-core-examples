using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public class ExampleTaskRun
{
    public static void Main() {
        List<Task> tasks = new List<Task>();
        var list = new ConcurrentBag<string>();

        string mydocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string[] dirNames = { mydocs, ".", "../..", "C:/", "C:/program files/" };

        foreach (var dirName in dirNames)
        {
            Task t = Task.Run(() =>
            {
                foreach (var path in Directory.GetFiles(dirName))
                    list.Add(path);
            });
            tasks.Add(t);
        }

        Task.WaitAll(tasks.ToArray());

        foreach (Task t in tasks)
            Console.WriteLine("Task {0} Status: {1}", t.Id, t.Status);

        foreach (var path in list) {
            Console.WriteLine(path);
        }

        Console.WriteLine("Number of files read: {0}", list.Count);
        Console.ReadKey();
    }
}