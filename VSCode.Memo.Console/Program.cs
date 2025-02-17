args = new string[] { "VSCode", "Test" };
if (args.Length > 0)
{
  foreach (var arg in args)
  {
    Console.WriteLine($"Hello, {arg}!");
  }
}
else
{
  Console.WriteLine("Hello!");
}