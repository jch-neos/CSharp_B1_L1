// exercise 2 : Make the following local function cancellable

async Task RunLongProcess(int milliseconds){
    await Task.Delay(milliseconds);
}
