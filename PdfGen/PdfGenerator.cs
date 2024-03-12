using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;


namespace PdfGen
{
    public class PdfGenerator
    {
        public static void GenerateSimpleReport(string filePath)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Size(PageSizes.A4); // Correct usage of PageSize

                    // Assuming DefaultTextStyle method requires a direct TextStyle object or has been updated
                    page.DefaultTextStyle(new TextStyle
                    {
                        //FontSize = 14 // Ensure this matches the actual property to set font size
                    });

                    page.Header().Text("Simple QuestPDF Report");
                    page.Content().Column(column =>
                    {
                        column.Item().Text("Hello, World!");
                        column.Item().Text("QuestPDF makes PDF generation in .NET straightforward.");
                    });

                    // Correct usage of PageNumber if part of a text component
                    page.Footer().AlignRight().Text(text =>
                    {
                        //text.Span("Page ").CurrentPageNumber(); // Adjusted method call for page number
                    });
                });
            });

            document.GeneratePdf(filePath);
        }
    }
}




