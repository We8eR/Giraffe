internal sealed class AClass
{
    public static void UsingLocalVariablesInTheCallbackCode(Int32 numToDo)
    {
        Int32[] squares = new Int32[numToDo];
        AutoResetEvent done = new AutoResetEvent(false);

        for (Int32 n = 0; n < squares.Length; n++)
        {
            ThreadPool.QueueUserWorkItem(obj =>
            {
                Int32 num = (Int32)obj;
                squares[num] = num * num;
                if (Interlocked.Decrement(ref numToDo) == 0) done.Set();
            }, n);
        }
        done.WaitOne();
        for (Int32 n = 0; n < squares.Length; n++)
            Console.WriteLine("Index {0}, Square - {1}", n, squares[n]);    
    }
}