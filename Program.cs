class C {

  static async Task<int> Except() {
    await Task.Delay(100);
    throw new Exception();
  }

  static Task<int> A() {
    return Except();
  }

  static async Task<int> B() {
    return await Except();
  }
  static async Task Main() {

    try {
      await A();
    } catch (Exception e) {
      Console.WriteLine(e);
    }

    try {
      await B();
    } catch (Exception e) {
      Console.WriteLine(e);
    }
  }
}