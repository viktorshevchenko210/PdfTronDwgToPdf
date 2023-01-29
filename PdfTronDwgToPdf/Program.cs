using pdftron;

string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "in");
string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "out");
if (!Directory.Exists(outputDirectory))
    Directory.CreateDirectory(outputDirectory);

foreach (var file in Directory.GetFiles(outputDirectory))
    File.Delete(file);

var inputFile = Directory.GetFiles(inputDirectory)[0];


PDFNet.Initialize("demo:1638727123163:7b63556e0300000000e733b5223644478c184cc841cc180fb5c16d6939");
PDFNet.AddResourceSearchPath(Path.Combine(Directory.GetCurrentDirectory(), "CADModuleLinux/Lib"));

using (var doc = new pdftron.PDF.PDFDoc())
{
    var options = new pdftron.PDF.CADConvertOptions();
    options.SetAllowThinLines(false);
    options.SetPageWidth(800);
    options.SetPageHeight(600);

    pdftron.PDF.Convert.FromCAD(doc, inputFile, options);
    doc.Save(Path.Combine(outputDirectory, $"PDFTron_{Guid.NewGuid()}.pdf"), pdftron.SDF.SDFDoc.SaveOptions.e_linearized);
}