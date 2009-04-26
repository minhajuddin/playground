class RenameFiles {
    public static void Main() {
        var files = System.IO.Directory.GetFiles(@"D:\_essentials\_utilities\shortcuts");

        foreach (var file in files) {
            var newname = file.Replace("Shortcut to ", "");
            System.IO.File.Move(file, newname);
        }
    }
}
