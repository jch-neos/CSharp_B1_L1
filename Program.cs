// exercise 3: Manage exceptions 
Random r=new Random(2321);
async Task RunLongProcessExceptions(int milliseconds, CancellationToken ct=default){
    if(r.NextDouble()>0.9) {
        throw new Exception("Random Exception");
    }
    await Task.Delay(milliseconds, ct);
}
