using System;
using System.Threading.Tasks;
using KafkaCsharp;

Console.WriteLine("Starting Producer ...");
await HTTPProducer.RunAsync();

Console.WriteLine();
Console.WriteLine("Done...");