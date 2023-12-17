internal sealed class AClass
{
    public static void UsingLocalVariablesInTheCallbackCode(Int32 numToDo)
    {
        WaitCallback callback1 = null;

        <> c_DisplayClass2 class1 = new <> c_DisplayClass2();

        class1.numToDo = numToDo;
        class1.squares = new Int32[class1.numToDo];
        class1.done = new AutoResetEvent(false);

        for (Int32 n = 0; n < class1.sqares.Length; n++)
        {
            if (callback1 == null)
            {
                callback1 = new WaitCallback(class1.< UsingLocalVariablesInTheCallbackCode > b_0);

            }
            ThreadPool.QueueUserWorkItem(callback1, n);
        }
        class1.done.WaitOne();
        for (Int32 n = 0; n < class1.squares.Length; n++)
            Console.WriteLine("Index {0}, Square={1}", n, class1.squares[n]);
    }
    private sealed class <>c_DisplayClass2: Object{
        public Int32[] squares;
    public Int32 numToDo;
    public AutoResetEvent done;
    public <>c_DisplayClass2{ }
    public void <UsingLocalVariablesInTheCallbackCode>b_0(Object obj){
        Int32 num = (Int32) obj;
        squares[num] = num * num;
    if (Interlocked.Decrement(ref numToDo) == 0)
        done.Set();

}
}
}