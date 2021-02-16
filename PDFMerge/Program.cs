using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using System;
using System.IO;
using System.Linq;

namespace PDFMerge
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(@"Program uses iText7 library under GNU Public licence. Go to 'https://www.gnu.org/licenses/agpl-3.0.html' for Licence details");
            Console.WriteLine();
            args.ToList().ForEach((x) => Console.WriteLine(x));
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var TargetFilename = Path.Combine(documents, "Merged.pdf");

            PdfDocument pdf = new PdfDocument(new PdfWriter(TargetFilename));
            PdfMerger merger = new PdfMerger(pdf);

            try
            {
                

                foreach (var file in args)
                {
                    Console.WriteLine($"\tProcess file {file}");
                    PdfDocument source = new PdfDocument(new PdfReader(file));
                    merger.Merge(source, 1, source.GetNumberOfPages());
                    source.Close();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error processing files");
            }
            finally
            {
                pdf.Close();
            }
           


            
            Console.WriteLine($"File processed to {TargetFilename}");
            Console.WriteLine();
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
