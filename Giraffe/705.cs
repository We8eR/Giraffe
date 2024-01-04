public void WinRTAsyncIntro()
{
    IAsyncOperatiom<StorageFile> asyncOp = KnownFolders.MusicLibrary.GetFileAsync("Song.mp3");
    asyncOp.Completed = OpCompleted;

}
private void OpCompleted(IAsyncOperation<StorageFile> asyncOp, AsyncStatus status)
{
    switch (status)
    {
        case AsyncStatus.Completed;
            StorageFile file = asyncOp.GetResults();

        case AsyncStatus.Canceled:
            break;

        case AsyncStatus.Error:
            Exception exception = asyncOp.ErrorCode;
            break;
    }
    asyncOp.Close();        
}